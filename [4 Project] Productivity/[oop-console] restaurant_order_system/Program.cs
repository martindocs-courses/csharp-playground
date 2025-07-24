using System.Text.RegularExpressions;

var inputValidator = new InputValidator();
ConsoleUI start = new ConsoleUI(inputValidator);
start.UI();

public class Menu{
    private readonly List<MenuItem> menuItem;
}

public class Order{
    private readonly List<OrderItem> orderItem;
    private decimal _orderTotal { get; set; }
}

public class OrderItem
{
    private MenuItem menuItem; // ref to MenuItem
    private int _orderQty { get; set; } 
    private readonly List<CustomizationOption> customizationOption;
}

public class MenuItem{
    private readonly List<CustomizationOption> customizationOptions;
    private string _name { get; set; }  
    private string _description { get; set; }
    private decimal _price { get; set; }
    private string _category { get; set; }
}

public class CustomizationOption{
    private string _toppings { get; set; }
    private int _spiceLevel { get; set; }
}

public class ConsoleUI{
    private readonly InputValidator _inputValidator;

    public ConsoleUI(InputValidator inputValidator)
    {
        _inputValidator = inputValidator;
    }

    public void UI(){

        Console.WriteLine("Welcome to The Console Café!\n");
        int menuOrder = 1;
        foreach (var option in Enum.GetNames(typeof(MenuOptions)))
        {
            // Split before each capital letter (but not at the beginning)
            // (?< !^) = Negative lookbehind: don’t match at the beginning of the string.
            // (?= [A - Z]) = Positive lookahead: match a position before a capital letter.
            string[] words = Regex.Split(option, @"(?<!^)(?=[A-Z])");
            Console.WriteLine($"{menuOrder}.{string.Join(" ", words)}");
            menuOrder++;          
        }
        _inputValidator.IsStringValid("> ", out int input);
    }
}

public class InputValidator{
    
    public void IsStringValid(string text, out int result){
        result = 0;
        bool nonValidInput = false;
        while(!nonValidInput){
            Console.Write(text);
            var userInput = Console.ReadLine();

            if(!string.IsNullOrEmpty(userInput) && int.TryParse(userInput, out int value)){
                result = value;
                nonValidInput = true;
            }
        }                   
    }
}

public class UserInteraction{
    /*
        During ordering:

        * Add item(s)

        * Choose quantity

        * Maybe select optional modifiers (e.g., extra cheese)

        * View running total

     */

}

enum MenuOptions{    
    ViewMenu = 1,
    PlaceOrder,
    ViewOrderSummary,
    SubmitOrder,
    Exit
}