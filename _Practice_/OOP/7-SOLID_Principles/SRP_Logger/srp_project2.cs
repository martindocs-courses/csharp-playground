
using System.IO;

    namespace OOP_SOLID_Principles.SRP_Logger
    {    
        public class FormatLogMessage{    
            public string FormatMessage(string message) => message.ToLower();
        }

        public class WriteToFile{
            private readonly FormatLogMessage _formatMessage;

            public WriteToFile(FormatLogMessage formatMessage)
            {
                _formatMessage = formatMessage;
            }

            public void SaveLog(string log){

                try
                {
                    string path = FileOperations.GetPath();
                    File.AppendAllText(path, _formatMessage.FormatMessage(log));

                    Console.WriteLine("Log saved!");
                }
                catch (FileNotFoundException ex)
                {
                    Console.WriteLine($"Error message: " + ex.Message);
                }
                catch (DirectoryNotFoundException ex)
                {
                    Console.WriteLine($"Error message: " + ex.Message);
                }
            }
        }

        public interface ILogMessage{
            public void Send(string message);    
        }

        public class ViaEmail : ILogMessage
        {
            public void Send(string message) => Console.WriteLine($"{message} sent via email");
        }
        public class ViaLogServer : ILogMessage
        {
            public void Send(string message) => Console.WriteLine($"{message} sent via log server");
        }
        public class ViaCloud : ILogMessage
        {
            public void Send(string message) => Console.WriteLine($"{message} sent via cloud server");
        }

        public class SendMessage {        
            public void Sent(ILogMessage logMessage){
                logMessage.Send("message");
            }
        }

        public static class FileOperations{

            public static string GetPath()
            {
                if (!File.Exists(Constant.PATH))
                {
                    File.WriteAllText(Constant.PATH, string.Empty);
                }
                return Constant.PATH;
            }

            public static string ReadFile(){

                try
                {
                    var path = File.ReadAllText(GetPath());           
                    return path;            

                }
                catch(FileNotFoundException ex){
                    throw;
                }
                catch (DirectoryNotFoundException ex)
                {
                    throw;
                }            
            }        
        }

        public static class Constant{
            public const string PATH = "../../../SRP_Logger/Log/log.txt";
        }
    }
