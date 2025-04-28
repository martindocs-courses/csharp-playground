namespace game_data_parser
{
    public class ConsoleUI
    {
       

        public void AskUser()
        {

            while (true)
            {
                Console.Write("Enter the name of the file you want to read: ");
                var userInput = Console.ReadLine();
                
                //if (userInput == "")
                //{
                //    Console.WriteLine("File name cannot be empty.");                
                //    break;
                //}
                
                //if (string.IsNullOrEmpty(userInput))
                //{
                //    Console.WriteLine("File name cannot be null.");                
                //    break;
                //}                

            }
        }
    }
}
