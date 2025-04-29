using System.Text.Json;

namespace game_data_parser
{
    public class GameConsoleUI
    {        
        public void AskUser()
        {
            while (true)
            {
                Console.Write("Enter the name of the file you want to read: ");
                var userInput = Console.ReadLine();

                if (userInput == "")
                {
                    Console.WriteLine("Filename cannot be empty.");
                }
                else if (string.IsNullOrEmpty(userInput))
                {
                    Console.WriteLine("Filename cannot be null.");
                }else{
                    var newPath = new JSONFileReader(userInput);

                    try
                    {
                        var data = newPath.ReadFromFile();
                        
                        Console.WriteLine("\nLoaded games are:");

                        for (var i = 0; i < data.Count; i++)
                        {
                            /*
                                    * Console.WriteLine(convertExistingDataObject[i]) will only print the type name: game_data_parser.DataModel. 
                                    * Because Console.WriteLine(object) calls .ToString()
                                    * to be able to print individual props we need override DataModel toString() method or use here directly convertExistingDataObject[i].Title etc.

                                */
                            Console.WriteLine(data[i]);
                        }
                        break;                       

                    }
                    catch (FileNotFoundException ex)
                    {                        
                        Console.WriteLine(ex.Message);
                    }catch(JsonException){
                        break;
                    }catch(Exception ex){
                        Console.WriteLine("General error: " + ex.Message);
                    }
                }
            }

            Console.WriteLine("\nPress any key to close");
        }
    }
}
