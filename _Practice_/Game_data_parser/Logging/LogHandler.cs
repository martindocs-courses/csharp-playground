namespace gameDataParser.Logging
{
    class LogHandler
    {
        private const string PATH = "logger.txt";

        public void LogError(string message)
        {
            string logEntry = $"[{DateTime.Now}]{Environment.NewLine}Exception message: {message}{string.Concat(Enumerable.Repeat(Environment.NewLine, 2))}";
            File.AppendAllText(PATH, logEntry);
        }
    }
}
