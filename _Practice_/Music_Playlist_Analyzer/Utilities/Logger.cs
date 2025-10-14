
namespace MusicPlaylistAnalyzer.Utilities
{
    public class Logger
    {
        private static readonly string LogFilePath = FileConstants.LOGGER_FILE_PATH;

        public static void Log(Exception ex){
            var logMessage = $"[{DateTime.Now}] ERROR: {ex.Message} {new string('\n', 2)}";
            File.AppendAllText(LogFilePath, logMessage);
        }
    }
}
