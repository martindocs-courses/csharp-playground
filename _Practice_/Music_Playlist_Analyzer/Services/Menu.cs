using MusicPlaylistAnalyzer.Utilities;

namespace MusicPlaylistAnalyzer.Services
{ 
    public class Menu
    {       
        private readonly MenuList _menuList;
        private readonly UserInteraction _userInteraction;

        public Menu(MenuList menuList, UserInteraction userInteraction)
        {            
            _menuList = menuList;
            _userInteraction = userInteraction;
        }

        public void MenuUI(){

            Console.WriteLine("*** Main Menu ***");
            _menuList.MenuListOptions();

            bool viewMainMenu = true;
            while(viewMainMenu){
                int userChoice = InputValidator.IntegerValid();

                if (userChoice > 0 && userChoice <= 6) { 
                    _userInteraction.ViewMenu(userChoice);
                    viewMainMenu = false;
                }else{
                    Console.WriteLine($"Please choose options from {MenuConstants.MENU_OPTIONS_FIRST} to {MenuConstants.MENU_OPTIONS_LAST}");
                }
            }
        
        }

    }
}
