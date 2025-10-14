using MusicPlaylistAnalyzer.Enums;
using MusicPlaylistAnalyzer.Utilities;

namespace MusicPlaylistAnalyzer.Services
{ 
    public class UserInteraction{
        private readonly UserOptions _userOptions;

        public UserInteraction(UserOptions userOptions)
        {
            _userOptions = userOptions;
        }

        public void ViewMenu(int userChoice)
        {
            switch (userChoice)
            {
                case (int)MenuOptions.AllSongs:
                    _userOptions.AllSongs();
                    break;
                case (int)MenuOptions.SearchSongs:
                    _userOptions.SearchSongs();
                    break;
                case (int)MenuOptions.PlayList:
                    _userOptions.PlaylistSummaryScreen();
                    break;
                case (int)MenuOptions.Genre:
                    _userOptions.GenreSongsExplorer();
                    break;
                case (int)MenuOptions.Artist:
                    _userOptions.ArtistSongsExplorer();
                    break;
                case (int)MenuOptions.AddSong:
                    _userOptions.AddSong();
                    break;
                //default:
                //    Console.WriteLine($"Please choose options from {MenuConstants.MENU_OPTIONS_FIRST} to {MenuConstants.MENU_OPTIONS_LAST}");
                //    break;
            }      
        
        }

    }
}
