using System.Text.Json;

namespace gameDataParser
{
    public class GameConsoleUI
    {
        public void AskUser()
        {
            bool continueAskUser = true;
            while (continueAskUser)
            {
                string? fileName = PromptForFilename();

                if (string.IsNullOrWhiteSpace(fileName))
                {
                    Console.WriteLine("Filename cannot be null or empty.");
                    continue;
                }

                try
                {
                    if (ReadGameData(fileName, out var data))
                    {
                        DisplayGameData(data);
                        continueAskUser = false;
                    }
                }
                catch (JsonException)
                {
                    continueAskUser = false;
                }
            }

            Console.WriteLine($"{Environment.NewLine}Press any key to close");
        }

        public string? PromptForFilename()
        {
            Console.Write("Enter the name of the file you want to read: ");
            return Console.ReadLine()?.ToLower();
        }

        public bool ReadGameData(string fileName, out List<GameData> data)
        {
            data = new List<GameData>();

            try
            {
                var reader = new JSONFileReader(fileName);
                data = reader.ReadFromFile();
                return true;

            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (JsonException)
            {
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine("General error: " + ex.Message);
            }

            return false;
        }

        public void DisplayGameData(List<GameData> data)
        {
            Console.WriteLine($"{Environment.NewLine}Loaded games are:");

            for (var i = 0; i < data.Count; i++)
            {
                /*
                        * Console.WriteLine(convertExistingDataObject[i]) will only print the type name: game_data_parser.DataModel. 
                        * Because Console.WriteLine(object) calls .ToString()
                        * to be able to print individual props we need override DataModel toString() method or use here directly convertExistingDataObject[i].Title etc.

                    */
                Console.WriteLine(data[i]);
            }
        }
    }
}

