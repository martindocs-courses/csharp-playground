
namespace OOP_Encapsulation.Password_Manager
{
    public class Password_Manager
    {
        private string _password { get; set; }

        public void SetPassword(){
            const int PASSWORD_LENGTH = 8;

            while (true) { 
                string newPassword = InputValidator("Please provide a password: ");

                if (newPassword.Length < PASSWORD_LENGTH)
                {
                    Console.WriteLine($"Password length need to be at least {PASSWORD_LENGTH} characters or longer.");
                }else{
                    ValidatePassword(_password, newPassword);
                    Console.WriteLine("Password set!");
                    return;
                }
            }
        }

        public void ValidatePassword(string current_password, string new_password){                        
                if(current_password == new_password){
                    Console.WriteLine("New password cannot be the same as previous one!");
                }else{
                    _password = new_password;
                }
        }

        public string InputValidator(string text){
            while (true) { 
                Console.Write(text);
                string? input = Console.ReadLine();

                if (!string.IsNullOrEmpty(input))
                {
                    return input;
                }else{
                    Console.WriteLine("\nText cannot be empty!\n");
                }
            }
        }        
    }
}
