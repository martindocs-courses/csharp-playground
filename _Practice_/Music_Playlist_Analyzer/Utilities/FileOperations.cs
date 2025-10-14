
using System.Text.Json;
using MusicPlaylistAnalyzer.Models;

namespace MusicPlaylistAnalyzer.Utilities
{
    public static class FileOperations
    {
        private static readonly string path = FilePath.GetPath(FileConstants.SONGS_FILE_PATH);
        public static List<Songs> ReadJson(){

            try
            {
                string json = File.ReadAllText(path);
                var getJsonFile = JsonSerializer.Deserialize<List<Songs>>(json);

                return getJsonFile;
            }
            catch (JsonException ex)            {
                Logger.Log(ex); // Log into file
                Console.WriteLine("There is a problem with JSOn file. Please ensure that file exist or is not empty. For more information about error please check Output/logger.txt");
            }

            return new List<Songs>();
        }

        public static void SaveToJson(Songs song){
            try
            {
                string json = File.ReadAllText(path);
                var getJsonFile = JsonSerializer.Deserialize<List<Songs>>(json);

                int newIndex = getJsonFile.Count + 1;

                getJsonFile.Add(song);

                var updateJsonFile = JsonSerializer.Serialize(getJsonFile);

                File.WriteAllText(path, updateJsonFile);
            }
            catch (JsonException ex)
            {
                Logger.Log(ex);
                Console.WriteLine("There is a problem with JSOn file. Please ensure that file exist or is not empty. For more information about error please check Output/logger.txt");
            }
        
        }
    
    }

    public static class FilePath{
        
        public static string GetPath(string path){
            if(!File.Exists(path)){
                File.WriteAllText(path, string.Empty);
            }

            return path;
        }
    }

}
