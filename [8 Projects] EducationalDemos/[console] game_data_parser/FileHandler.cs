using System.Text.Json;

namespace gameDataParser
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
                    _logger.LogError(ex.ToString());

                    Console.WriteLine($"JSON in the {FilePath} was not in a valid format. JSON body:{Environment.NewLine}{existingContent}");

                    Console.WriteLine($"{Environment.NewLine}Sorry! The application has experienced an unexpected error and will have to be closed.");
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
