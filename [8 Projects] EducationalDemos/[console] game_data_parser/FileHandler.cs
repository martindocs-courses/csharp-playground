using System.Text.Json;

namespace game_data_parser
{
    public interface IFile{
        public string FilePath{ get; }
    }
    public interface IReadable<T>: IFile {
        List<T> ReadFromFile();
    }     
               
    public class JSONFileReader : IReadable<GameData>
    {
        private readonly LogHandler logger = new LogHandler();
        public string FilePath { get; }
        
        public JSONFileReader(string path)
        {
            FilePath = path;
        }
                
        public List<GameData> ReadFromFile() {

            if(File.Exists(FilePath)){

                string existingContent = File.ReadAllText(FilePath);                              

                try
                {
                    var parser = new JsonDataParser();
                    return parser.Parse(existingContent);                   
                }
                catch (JsonException ex)
                {
                    logger.LogError(ex.ToString());
                    Console.WriteLine($"JSON in the {FilePath} was not in a valid format. JSON body:\n{existingContent}");
                    Console.WriteLine("Sorry! The application has experienced an unexpected error and will have to be closed.");
                    throw; 
                }
                catch (Exception ex)
                {
                    logger.LogError(ex.ToString());
                    Console.WriteLine($"Unexpected error: {ex.Message}");
                    throw;
                }                
            }

            throw new FileNotFoundException($"File '{FilePath}' was not found.");
        }
    }
}
