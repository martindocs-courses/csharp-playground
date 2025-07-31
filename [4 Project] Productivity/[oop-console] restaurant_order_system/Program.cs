
using System.Reflection.Metadata;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using System.Xml.Linq;

var menu = new Menu();
menu.LoadFileData();
var inputIntegerValidator = new IntegerInputValidator();
var inputStringValidator = new StringInputValidator();
var order = new Order(menu.MenuItems, inputIntegerValidator, inputStringValidator);
var userInteraction = new UserInteraction(menu, order);
ConsoleUI start = new ConsoleUI(inputIntegerValidator, userInteraction);
start.UI();

public static class Constants{
    public const string Menu = "../../../Menu/menu-list.json";
    public const string Yes = "y";
    public const string No = "n";
}

public static class TextFormatting{

    public static void ConsoleMessage(string text = "") => Console.WriteLine(text);
}

public static class FileOperation{
    private static readonly StringInputValidator _inputValidator = new StringInputValidator();

    public static string GetFilePath(){
        
        if(!File.Exists(Constants.Menu)){
            ResetFile();
        }

        return Constants.Menu;
    }

    public static void ResetFile()
    {
        bool resetFile = false;
        while(!resetFile){
            TextFormatting.ConsoleMessage("The file is corrupted or missing file. Do you want reset the file [y/n]");

            string input = _inputValidator.IsStringValid("> ");

            if(input == Constants.Yes){
                File.WriteAllText(Constants.Menu, JsonSerializer.Serialize(new List<MenuItem>()));
                resetFile = true;
            } else if (input == Constants.No) {
                Environment.Exit(0);
            }else{
                TextFormatting.ConsoleMessage($"Please enter {Constants.Yes} or {Constants.No}.");
            }
        }
    }

    public static List<MenuItem> ReadFile(){
        string currentFileContent = File.ReadAllText(GetFilePath());
        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        // Object usage via property access
        try{
            var convertExistingDataToObject = JsonSerializer.Deserialize<List<MenuItem>>(currentFileContent, options);

            if(convertExistingDataToObject != null && convertExistingDataToObject.Count != 0){
                return convertExistingDataToObject;
            }
            
            return new List<MenuItem>();
            
        }catch(JsonException ex)
        { 
            throw;
        }       
    }
}


public class Menu{
    private List<MenuItem> _menuItem = new List<MenuItem>();

    // readonly prop, exposed the _menuItem, so Order class can read it
    public List<MenuItem> MenuItems
    {
        get { return _menuItem; }
    }

    public void LoadFileData(){
        try
        {
            _menuItem = FileOperation.ReadFile();
        }
        catch (JsonException ex)
        {
            FileOperation.ResetFile();
            _menuItem = new List<MenuItem>();
        }
    }

    public void MenuList(){
        
        if(_menuItem == null){
            LoadFileData();
        }

        if (_menuItem.Count > 0)
        {            
            // Heading
            Console.Write($"{("ID".PadLeft(3).PadRight(4))}|{("Name".PadLeft(12)).PadRight(20)}|{("Toppings".PadLeft(24)).PadRight(44)}|{("Description".PadLeft(28)).PadRight(47)}|{("Price (£)".PadLeft(10)).PadRight(11)}|{("Category".PadLeft(10)).PadRight(18)}");

            TextFormatting.ConsoleMessage();
            // separator "-"
            TextFormatting.ConsoleMessage(string.Join("", Enumerable.Repeat("-", (4 + 20 + 44 + 47 + 11 + 11 + 4))));
            foreach (var item in _menuItem)
            {
                string id = item.ID.ToString();
                string name = item.Name;
                string description = item.Description;
                string price = item.Price.ToString();
                string category = item.Category;

                Console.Write($"{(id.PadLeft(3)).PadRight(4)}|{name.PadRight(20)}|");
                                
                int i = 1;
                if (item.Toppings != null)
                {
                    string output = "";
                    foreach (var topping in item.Toppings)
                    {
                        output += $"({i}) {topping} ";
                        i++;
                    }

                    Console.Write(output);

                    int toppingsHeaderWidth = 44;
                    Console.Write("".PadLeft(toppingsHeaderWidth - output.Length));
                }

                Console.Write($"|{description.PadRight(47)}|{(price.PadLeft(8)).PadRight(11)}|{category.PadLeft(10)}");

                TextFormatting.ConsoleMessage();
            }
        }
        else
        {
            TextFormatting.ConsoleMessage("No menu today!");
        }
    }    
}

// Data Model, use get and set so System.Text.Json can populate it during deserialization.
public class MenuItem
{
    public List<string> Toppings { get; } = new List<string>();
    public int ID { get; }
    public string Name { get; }
    public string Description { get; }
    public decimal Price { get; }
    public string Category { get; }

    /*
        Constructor Deserialization:

        Normally, JSON serializers (like System.Text.Json) create objects by using the parameterless constructor and setting properties via their public setters. aka: 
    
            public int ID { get; set; }

        Constructor deserialization allows the serializer to create an object by calling a constructor directly with parameters that match JSON property names. This is useful for immutable objects or when you want to enforce that certain values are provided at creation time.

        To enable constructor deserialization:
        - Define a constructor with parameters matching the JSON properties.
        - Optionally, decorate the constructor with [JsonConstructor] attribute (for clarity and control).
        - Properties can be read-only (get-only) because values are set via constructor parameters.

        This approach improves immutability and ensures objects are always fully initialized.
     */

    [JsonConstructor]
    public MenuItem(int id, string name, string description, decimal price, string category, List<string> toppings)
    {
        ID = id;
        Name = name;
        Description = description;
        Price = price;
        Category = category;
        Toppings = toppings;
    }

}

public class Order{
    private readonly IntegerInputValidator _integerValidator = new IntegerInputValidator();
    private readonly StringInputValidator _stringValidator = new StringInputValidator();
    private List<OrderItem> _orderItem = new List<OrderItem>();
    private List<MenuItem> _menuItem; // ref to Menu
    private decimal _orderTotal { get; set; }

    public Order(List<MenuItem> menuItem, IntegerInputValidator integerValidator, StringInputValidator stringValidator) // pass menuItem, so we do not need read the file again
    {
        _menuItem = menuItem;
        _integerValidator = integerValidator;
        _stringValidator = stringValidator;
    }

    public void PlaceOrder(){
        // Reset the order
        _orderItem.Clear();
        _orderTotal = 0;
        string id = "";
        int quantity = 0;
        string continueOrder = Constants.Yes;

        while (true)
        {
            if(continueOrder.ToLower() == Constants.Yes){

                id = _stringValidator.IsStringValid("\nAdd item(ID or type 'menu'): ");

                if (id == "menu") {
                    ReviewMenu();                    
                } else if (Regex.IsMatch(id, @"^\d+$")){
                    var selectedOrder = _menuItem.FirstOrDefault(x => x.ID == Convert.ToInt32(id));                    

                    if(selectedOrder != null){
            
                        _integerValidator.IsIntegerValid("Choose quantity: ", out quantity);
                        decimal orderPrice = selectedOrder.Price;

                        _orderItem.Add(new OrderItem { OrderQty = quantity, MenuItem = selectedOrder });
                        _orderTotal += (orderPrice * quantity);
                        TextFormatting.ConsoleMessage("\nOrder added!");
                    }
                    else
                    {
                        TextFormatting.ConsoleMessage("No menu available with this ID!");
                        continue;
                    }
                }
            }

            if(id != "" && id != "menu" && id.Length == 1){
                continueOrder = _stringValidator.IsStringValid("Do you want place another order? [y/n].\n> ");

                if (continueOrder.ToLower() == Constants.Yes) {
                    continue;
                }else if (continueOrder == Constants.No) { 
                    break; 
                }else{
                    continueOrder = "";
                    TextFormatting.ConsoleMessage("Please enter [y] or [n].");
                }
            }
        }
    }

    public void ReviewMenu(){

        // Heading
        Console.Write($"{("ID".PadLeft(3).PadRight(4))}|{("Name".PadLeft(12)).PadRight(20)}|{("Toppings".PadLeft(24)).PadRight(44)}");
        TextFormatting.ConsoleMessage();
        // separator "-"
        TextFormatting.ConsoleMessage(string.Join("", Enumerable.Repeat("-", (4 + 20 + 44))));
        foreach (var item in _menuItem)
        {
            string tableID = item.ID.ToString();
            string name = item.Name;

            Console.Write($"{(tableID.PadLeft(3)).PadRight(4)}|{name.PadRight(20)}|");

            int i = 1;
            if (item.Toppings != null)
            {
                string output = "";
                foreach (var topping in item.Toppings)
                {
                    output += $"({i}) {topping} ";
                    i++;
                }

                Console.Write(output);

                int toppingsHeaderWidth = 44;
                Console.Write("".PadLeft(toppingsHeaderWidth - output.Length));
            }

            TextFormatting.ConsoleMessage();
        }
    }

    public void ViewOrder(){

        if (_orderItem.Count > 0){

            TextFormatting.ConsoleMessage("Added order(s)");
            // Heading  
            Console.Write($"{("Order".PadLeft(12).PadRight(20))}|{("Qty".PadLeft(3)).PadRight(4)}|{"Price (£)".PadRight(11)}");
            TextFormatting.ConsoleMessage();
            // separator "-"
            TextFormatting.ConsoleMessage(string.Join("", Enumerable.Repeat("-", (20 + 4 + 11))));

            foreach (var item in _orderItem)
            {
                Console.Write($"{item.MenuItem.Name.PadRight(20)}|{item.OrderQty.ToString().PadRight(4)}|{item.MenuItem.Price.ToString().PadRight(11)}");
                TextFormatting.ConsoleMessage();
            }
            // Footer
            TextFormatting.ConsoleMessage(string.Join("", Enumerable.Repeat("-", (20 + 4 + 11))));

            TextFormatting.ConsoleMessage($"Total: £{_orderTotal}");

        }else{
            TextFormatting.ConsoleMessage("No order selected.");
        }         
    }

    public void SubmitOrder(){
        
        if(_orderItem.Count > 0){

            while(true){
                string input = _stringValidator.IsStringValid("Are you sure you want place the order? Press [y] to confirm or any other button to cancel.\n> ");
                
                if(input.ToLower() == Constants.Yes){
                    _orderItem.Clear();
                    _orderTotal = 0;

                    TextFormatting.ConsoleMessage("\nOrder Placed. We'll deliver it to you shortly!");                    
                }

                break;
            }
        }
        else{
            TextFormatting.ConsoleMessage("No order selected.");
        }
    }
}

public class OrderItem
{
    public MenuItem MenuItem { get; set; } // ref to MenuItem props
    public int OrderQty { get; set; } 
}

public class ConsoleUI{
    private readonly IntegerInputValidator _inputValidator;
    private readonly UserInteraction _userInteraction;

    public ConsoleUI(IntegerInputValidator inputValidator, UserInteraction userInteraction)
    {
        _inputValidator = inputValidator;
        _userInteraction = userInteraction;
    }

    public void UI(){
        bool showMenu = true;
        TextFormatting.ConsoleMessage(); // additional new line to align with scrollback buffer clears 

        while (true){
            if(showMenu)
            {
                TextFormatting.ConsoleMessage("Welcome to The Console Café!\n");
                int menuOrder = 1;
                foreach (var option in Enum.GetNames(typeof(MenuOptions)))
                {
                    // Split before each capital letter (but not at the beginning)
                    // (?< !^) = Negative lookbehind: don’t match at the beginning of the string.
                    // (?= [A - Z]) = Positive lookahead: match a position before a capital letter.
                    string[] words = Regex.Split(option, @"(?<!^)(?=[A-Z])");
                    TextFormatting.ConsoleMessage($"{menuOrder}.{string.Join(" ", words)}");
                    menuOrder++;          
                }
            }
            showMenu = false;
                
            _inputValidator.IsIntegerValid("> ", out int input);
            _userInteraction.ViewMenu(input);

            if (input >= (int)MenuOptions.ViewMenu && input <= (int)MenuOptions.Exit){
                showMenu = true;
                TextFormatting.ConsoleMessage("\nPress to continue...");
                Console.ReadKey();
                Console.Clear(); // clears the visible screen
                TextFormatting.ConsoleMessage("\x1b[3J"); // clears the scrollback buffer, so you can't scroll up to see previous output. 
                /*
                 
                   \x1b - is the escape character (ESC, ASCII 27).
                   [3J  - is a specific ANSI escape sequence.
                    
                   \x1b[3J - It's the "Erase in Display" ANSI code with argument 3
                   \u001bc\x1b[3J - if above is not working, this one might work

                On Windows, classic CMD.exe doesn't support it. But Windows Terminal, PowerShell, and Unix terminals they usually do.

                 */
            }
        }       
    }
}

public class IntegerInputValidator{    
    public void IsIntegerValid(string text, out int result){
        result = 0;
        bool nonValidInput = false;
        while(!nonValidInput){
            Console.Write(text);
            var userInput = Console.ReadLine();

            if(!string.IsNullOrEmpty(userInput) && int.TryParse(userInput, out int value)){
                result = value;
                nonValidInput = true;
            }else{
                TextFormatting.ConsoleMessage("Please ensure the value is a number.");
            }
        }                   
    }
}

public class StringInputValidator{

    public string IsStringValid(string text)
    {
        var userInput = "";
        bool nonValidInput = false;
        while (!nonValidInput)
        {
            Console.Write(text);
            userInput = Console.ReadLine();

            if (!string.IsNullOrEmpty(userInput))
            {
                nonValidInput = true;
            }else{
                TextFormatting.ConsoleMessage("Please ensure the value is a string.");
            }
        }

        return userInput;
    }
}

public class UserInteraction{
    private readonly Menu _menu;
    private readonly Order _order;
    public UserInteraction(Menu menu, Order order)
    {
        _menu = menu;
        _order = order;
    }

    public void ViewMenu(int option){        
            switch(option){
                case (int)MenuOptions.ViewMenu:
                    _menu.MenuList();
                    break;
                case (int)MenuOptions.PlaceOrder:
                    _order.PlaceOrder();
                    break;
                case (int)MenuOptions.ViewOrderSummary:
                    _order.ViewOrder();
                    break;
                case (int)MenuOptions.SubmitOrder:
                    _order.SubmitOrder();
                    break;
                case (int)MenuOptions.Exit:
                    TextFormatting.ConsoleMessage("Goodbye! Thank you for visiting us!");
                    Environment.Exit(0);
                    break;
                default:
                    TextFormatting.ConsoleMessage($"Please choose between {(int)MenuOptions.ViewMenu} and {(int)MenuOptions.Exit}");
                    break;
            }
    }
}

enum MenuOptions{    
    ViewMenu = 1,
    PlaceOrder,
    ViewOrderSummary,
    SubmitOrder,
    Exit
}