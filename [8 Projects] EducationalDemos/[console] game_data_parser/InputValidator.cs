namespace game_data_parser
{
    public interface InputValidator{
        public bool fileHandling(string input);
    }

    public class EmptyValue : InputValidator{
        public bool fileHandling(string input){
            if(input == ""){
                return true;
            }

            return false;
        }
    }

    public class NullValue : InputValidator {
        public bool fileHandling(string input) { 
            if(string.IsNullOrEmpty(input)){
                return true;
            }

            return false;
        }
    }

}
