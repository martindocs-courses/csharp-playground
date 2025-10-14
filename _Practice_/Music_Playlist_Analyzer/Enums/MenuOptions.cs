
using System.ComponentModel;

namespace MusicPlaylistAnalyzer.Enums
{ 
    public enum MenuOptions{
        [Description("View All Songs")]
        AllSongs = 1,
        [Description("Search Songs")]
        SearchSongs,
        [Description("View Playlist Summary")]
        PlayList,
        [Description("Explore by Genre")]
        Genre,
        [Description("Explore by Artist")]
        Artist,
        [Description("Add Song")]
        AddSong
    }

    public enum SongsFiltersOptions{ 
        [Description("Show all songs")]
        ShowAllSongs = 1,
        [Description("Show songs by playing time [min]")]
        ShowSongsByPlayingTime,
        [Description("Shows songs by genre")]
        ShowsSongsByGenre,
        [Description("Show songs by artist")]
        ShowSongsByArtist,
    }

    public enum SongsSortOptions
    {       
        Title = 1,     
        Artist,        
        Genre,
        [Description("Song Duration")]
        songDuration,
    }

    public enum GenreExplorerOptions{
        [Description("List of songs")]
        ListOfSongs = 1,
        [Description("Count Total Duration")]
        CountTotalDuration,
        [Description("Are all songs in this genre over 2 min?")]
        AreSongsOverTwoMinutes
    }
}
