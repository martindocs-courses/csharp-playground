using MusicPlaylistAnalyzer.Enums;

namespace MusicPlaylistAnalyzer.Utilities
{ 
    public static class MenuConstants{
        public const int MENU_OPTIONS_FIRST = (int)MenuOptions.AllSongs;
        public const int MENU_OPTIONS_LAST = (int)MenuOptions.AddSong;
    }

    public static class FileConstants{
        public const string SONGS_FILE_PATH = "../../../Data/songs.json";
        public const string LOGGER_FILE_PATH = "../../../Output/logger.txt";

    }
}
