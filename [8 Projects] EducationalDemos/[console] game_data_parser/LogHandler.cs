namespace game_data_parser
{    
    class LogHandler 
    {
        const string PATH = "logger.txt";

        public void LogError(string message){            

            string logEntry = $"[{DateTime.Now}]\nException message: {message}\n\n";
            File.AppendAllText(PATH, logEntry);
        }
    }
}
