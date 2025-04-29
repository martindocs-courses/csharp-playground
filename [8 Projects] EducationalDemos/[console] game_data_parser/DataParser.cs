using System.Text.Json;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace game_data_parser
{
    // Generic interface for data parsing. Allows different parsing (e.g., JSON, XML, CSV) to be used interchangeably.
    // 'T' is the type of object the parser should produce from a raw data string.
    public interface IDataPaser<T>
    {
        // Parses the given string and returns a list of objects of type T.
        public List<T> Parse(string data);
    }

    // JSON-specific implementation of the IDataPaser interface
    // This parser uses System.Text.Json to convert a JSON string into a list of GameData objects.
    public class JsonDataParser : IDataPaser<GameData>{

        // Deserialize the raw JSON into a list of GameData objects.
        // This method may throw JsonException if the input is not valid JSON.
        public List<GameData> Parse(string rawData) =>  JsonSerializer.Deserialize<List<GameData>>(rawData);
    }
}
