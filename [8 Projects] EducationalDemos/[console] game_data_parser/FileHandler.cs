using System.Reflection.Metadata;

namespace game_data_parser
{
    public interface IFile{
        public string FilePath{ get; set; }
    }
    public interface IReadable: IFile {
        void ReadFromFile();
    }     
    public interface IWriteable: IFile {
        void WriteToFile();
    }
        
       
    public class JSONFile : IReadable
    {

        public string FilePath { get; set; }

        public JSONFile(string path)
        {
            //FilePath = "games.json";
            FilePath = path;
        }

        public string GetFilePath()
        {
            return FilePath;
        }

        //public void SaveFilePath(string path)
        //{
        //    FilePath = path;
        //}

        public void ReadFromFile(){
            string path = GetFilePath();

            if(File.Exists(path)){
                Console.WriteLine("file exist");
            }
        }        
    }

    public class TextFile : IReadable, IWriteable{

        public string FilePath { get; set; }
      
        public string GetFilePath(){
            return FilePath;
        }

        public void SaveFilePath(string path){
            
            FilePath = path;
        }

        public void WriteToFile(){

        }

        public void ReadFromFile(){

        }
    }
}
