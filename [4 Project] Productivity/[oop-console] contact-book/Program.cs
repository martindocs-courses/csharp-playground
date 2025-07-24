// USING COMPOSITION
using System.Threading.Channels;
var validNumericInput = new NumericInputValidator();
var validStringInput = new StringInputValidator();
var contactBook = new ContactBook();
var userInteraction = new UserInteraction(contactBook, validStringInput, validNumericInput);
ContactBookMenu menu = new ContactBookMenu(validNumericInput, userInteraction);
menu.BooksMenu();

public class Contact{

    //public string Name { get; private set; } // other option to access prop in other class is by set prop to public , but restrict access to only get prop but not private set. so we do not need ovveride the ToString method
    public string Name { get; set; } 
    public string PhoneNumber { get; set; }
    public string Email { get; set; }

    public Contact(string name, string phone, string email)
    {
        Name = name;
        PhoneNumber = phone;
        Email = email;
    }

    // If we use private prop, the only way to access/show props in other class is by override ToString method
    public override string ToString() => $"{Name.PadRight(10)} | {PhoneNumber.PadRight(10)} | {Email.PadRight(10)}";
}

public class ContactBook 
{
    private List<Contact> _contacts = new List<Contact>();
    private StringInputValidator _inputValidator = new StringInputValidator();
        
    public void AddContact(string name, string phone, string email){
        _contacts.Add(new Contact(name, phone, email));       
    }

    public void EditContact(int id)
    {

        if (_contacts.Count > 0) {
            string name = "";
            string phone = "";
            string email = "";

            for (int i = 0; i < _contacts.Count; i++)
            {
                if(i+1 == id){                    
                    
                    Console.WriteLine($"Current contact: {string.Join(" ", $"Name: {_contacts[i].Name}, Phone Number: {_contacts[i].PhoneNumber}, Email: {_contacts[i].Email}")}");

                    name = _inputValidator.UserInput("Please provide new Name: ");
                    phone = _inputValidator.UserInput("Please provide new Phone Number: ");
                    email = _inputValidator.UserInput("Please provide new Email: ");

                    if (name != "" || phone != "" || email != "")
                    {
                        _contacts[i].Name = name;
                        _contacts[i].PhoneNumber = phone;
                        _contacts[i].Email = email;
                    }
                }
            }            

            Console.WriteLine(Environment.NewLine + "Contact updated!" + Environment.NewLine);
        }else{
            Console.WriteLine("No contacts.");
        }
    }

    public void RemoveContact(int id)
    {
        if (_contacts.Count > 0)
        {
            // We need to use for loop as when using foreach we getting error collection is changing during looping, which break internal structure that foreach relies on.
            for (int i = 0; i < _contacts.Count; i++)
            {
                if ((i+1) == id)
                {
                    _contacts.Remove(_contacts[i]);
                    break;
                }
            }
            Console.WriteLine(Environment.NewLine + "Contact removed!" + Environment.NewLine);
        }else{
            Console.WriteLine("No contacts.");
        }
    }

    public void ShowAllContact() {
        if(_contacts.Count > 0){
            string contactBookHeading = $"{"ID".PadRight(3)} | {"Name".PadRight(10)} | {"Phone".PadRight(10)} | {"Email".PadRight(20)}";            
            
            Console.WriteLine(contactBookHeading);
            Console.WriteLine(string.Concat(Enumerable.Repeat("-", contactBookHeading.Length)));

            for (int i = 0; i < _contacts.Count; i++)
            {
                Console.WriteLine($"{(i+1).ToString().PadRight(3)} | {_contacts[i]}");
                //Console.WriteLine(contact[i].Name); we using if the prop in Contact class GET is public
            }            
        }
        else{
            Console.WriteLine("No contacts.");
        }
    }    
}

public class ContactBookMenu{
    private readonly NumericInputValidator _userInput;
    private readonly UserInteraction _userInteraction;

    public ContactBookMenu(NumericInputValidator isInputValid, UserInteraction userInteraction)
    {
        _userInput = isInputValid;
        _userInteraction = userInteraction;
    }

    public void BooksMenu(){
        Console.WriteLine("== Menu ==");
        foreach (var value in Enum.GetValues(typeof(Menu)))
        {
            Console.WriteLine($"{(int)value}.{value}");
        }

        while(true){

            bool inputValid = _userInput.UserInput("> ", out int output);
            
            if(inputValid){
                _userInteraction.UserChoice(output);
            }else{
                Console.WriteLine($"Please select numbers from 1 to {(int)Menu.Edit}");
            }         
        }                
    }
}

public class UserInteraction{
    private readonly ContactBook _contacts;
    private readonly StringInputValidator _stringInput;
    private readonly NumericInputValidator _numericInput;

    public UserInteraction(ContactBook contact, StringInputValidator inputValid, NumericInputValidator numericInput)
    {
        _contacts = contact;
        _stringInput = inputValid;
        _numericInput = numericInput;
    }

    public void UserChoice(int value){
        switch(value){
            case (int)Menu.Add:
                string name = _stringInput.UserInput("Name: ");
                string phone = _stringInput.UserInput("Phone Number: ");
                string email = _stringInput.UserInput("Email: ");
                _contacts.AddContact(name, phone, email);
                break;
            case (int)Menu.Remove:
                var contactToRemove = _stringInput.UserInput("Please provide contact ID: ");
                
                if(int.TryParse(contactToRemove, out int removeID)){
                    _contacts.RemoveContact(removeID);
                }
                break;
            case (int)Menu.Display:
                _contacts.ShowAllContact();
                break;            
            case (int)Menu.Edit:
                var contactToEdit = _stringInput.UserInput("Please provide contact ID: ");

                if (int.TryParse(contactToEdit, out int editID))
                {
                    _contacts.EditContact(editID);
                }

                break;            
        }        
    }
}

public class NumericInputValidator{
    
    public bool UserInput(string text, out int output){
        output = 0;

        Console.Write(text);
        var input = Console.ReadLine();

        if(int.TryParse(input, out output) && Enum.IsDefined(typeof(Menu), output)){            
            return true;
        }
        return false;
    }
}

public class StringInputValidator{

    public string UserInput(string text){

        while(true){
            Console.Write(text);
            var input = Console.ReadLine();

            if(!string.IsNullOrEmpty(input)){
                return input;
            }else{
                Console.WriteLine(Environment.NewLine + "Please provide correct value." + Environment.NewLine);
            }
        }
    }
}

public enum Menu{
    Add = 1,
    Remove,
    Display,    
    Edit   
}
