using gameDataParser.Logging;
using gameDataParser.Model;
using System.Text.Json;

namespace gameDataParser.DataAccess
{
    public interface IFile
    {
        public string FilePath { get; }
    }
    public interface IFileReader<T> : IFile
    {
        List<T> ReadFromFile();
    }

    public class JSONFileReader : IFileReader<GameData>
    {
        private readonly LogHandler _logger = new LogHandler();
        public string FilePath { get; }

        public JSONFileReader(string path)
        {
            FilePath = path;
        }

        public List<GameData> ReadFromFile()
        {

            if (File.Exists(FilePath))
            {

                string existingContent = File.ReadAllText(FilePath);

                try
                {
                    var parser = new JsonDataParser();
                    return parser.Parse(existingContent);
                }
                catch (JsonException ex)
                {
                    var orginalColor = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Red;

                    _logger.LogError(
                        @$"{ex.Message}
File name is: {FilePath} 
Stack trace: {ex.StackTrace}");

                    Console.WriteLine($"JSON in the {FilePath} was not in a valid format. JSON body:{Environment.NewLine}{existingContent}");

                    Console.WriteLine($"{Environment.NewLine}Sorry! The application has experienced an unexpected error and will have to be closed.");

                    Console.ForegroundColor = orginalColor;
                    throw;
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex.ToString());

                    Console.WriteLine($"Unexpected error: {ex.Message}");
                    throw;
                }
            }

            throw new FileNotFoundException($"File '{FilePath}' was not found.");
        }
    }
}
