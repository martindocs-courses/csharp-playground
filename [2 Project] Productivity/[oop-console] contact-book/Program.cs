// USING COMPOSITION
using System.Threading.Channels;
var validNumericInput = new NumericInputValidator();
var validStringInput = new StringInputValidator();
var contactBook = new ContactBook();
var userInteraction = new UserInteraction(contactBook, validStringInput, validNumericInput);
ContactBookMenu menu = new ContactBookMenu(validNumericInput, userInteraction);
menu.BooksMenu();

//ContactBook contacts = new ContactBook();
//contacts.AddContact("Martin", "1223403", "martin@gmail.com");
//contacts.AddContact("Adam", "5615445", "adam@gmail.com");
//contacts.AddContact("Bob", "9468415", "bob@gmail.com");

//contacts.ShowAllContact();

//contacts.RemoveContact("bob@gmail.com");
//contacts.ShowAllContact();

//contacts.EditContact(1, "Magda", "1223403", "magda@gmail.com");
//contacts.ShowAllContact();

public class Contact{

    //public string Name { get; private set; } // other option to access prop in other class is by set prop to public , but restrict access to only get prop but not private set. so we do not need ovveride the ToString method
    public string Name { get; private set; } 
    public string PhoneNumber { get; private set; }
    public string Email { get; private set; }

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
        
    public void AddContact(string name, string phone, string email){
        _contacts.Add(new Contact(name, phone, email));       
    }

    public void EditContact(int id, string name, string phone, string email){

        if (_contacts.Count > 0) { 
            for (int i = 0; i < _contacts.Count; i++)
            {
                if(i+1 == id){
                    _contacts[i] = new Contact(name, phone, email);
                }
            }

            Console.WriteLine(Environment.NewLine + "Contact updated!" + Environment.NewLine);
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
                }else{
                    Console.WriteLine("Contact not found.");
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
                var input = _stringInput.UserInput("Please provide contact ID: ");
                
                if(int.TryParse(input, out int id)){
                    _contacts.RemoveContact(id);
                }
                break;
            case (int)Menu.Display:
                _contacts.ShowAllContact();
                break;            
            case (int)Menu.Edit:
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
