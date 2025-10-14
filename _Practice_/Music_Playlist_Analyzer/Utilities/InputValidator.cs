namespace MusicPlaylistAnalyzer.Utilities
{
    public static class InputValidator{

        public static int IntegerValid(){
            var input = Console.ReadLine();
            if(!string.IsNullOrEmpty(input) && int.TryParse(input, out int result)){
                return result;
            }else{
                Console.WriteLine("Please enter the valid value.");
                return 0;
            }

        }

        public static string StringValid(){
            var input = Console.ReadLine();
            if(!string.IsNullOrEmpty(input)){
                return input;
            }else{
                Console.WriteLine("Please enter the valid value.");
                return null;
            }
        }
    }
}
