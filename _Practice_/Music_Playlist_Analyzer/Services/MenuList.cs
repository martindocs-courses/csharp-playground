using MusicPlaylistAnalyzer.Enums;
using MusicPlaylistAnalyzer.Utilities;

namespace MusicPlaylistAnalyzer.Services
{ 
    public class MenuList{
        public void MenuListOptions(){
            
            foreach (MenuOptions option in Enum.GetValues(typeof(MenuOptions)))
            {
                Console.WriteLine($"{(int)option}.{option.GetDescription()}");
            }
        }
    }
}
