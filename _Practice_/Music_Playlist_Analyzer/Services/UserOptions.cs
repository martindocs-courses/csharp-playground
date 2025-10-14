
using MusicPlaylistAnalyzer.Enums;
using MusicPlaylistAnalyzer.Utilities;
using MusicPlaylistAnalyzer.Models;

namespace MusicPlaylistAnalyzer.Services
{ 
    public class UserOptions{
        private readonly List<Songs> _songs = FileOperations.ReadJson();
       

        public void AllSongs()
        {
            if (_songs.Count !=0){

                Messages.ConsoleMessage("Current list of songs:" + Environment.NewLine);
                Messages.ConsoleMessage("TITLE".PadLeft(20) + "ARTIST".PadLeft(20) + "SONG DURATION (sec)".PadLeft(23));

                var sortAllSongs = _songs.OrderBy(song => song.Artist);

                foreach (var song in sortAllSongs)
                {
                    Messages.ConsoleMessage($"" +
                        $"{song.Title.PadLeft(20)} " +
                        $"{song.Artist.PadLeft(20)} " +
                        $"{song.SongDuration.ToString().PadLeft(10)}"
                    );
                }
            }
            else{
                Messages.ConsoleMessage("No songs in the library.");
            }
        }

        public void SearchSongs() {

            if (_songs.Count != 0)
            {
                Messages.ConsoleMessage("** Search songs **");

                Console.Write("Enter song title or artist: ");
                string userChoice = InputValidator.StringValid();

                var returnValue = _songs.FirstOrDefault(song => song.Title == userChoice || song.Artist == userChoice);

                if (returnValue != null) {

                    Messages.ConsoleMessage(@$"ID: {returnValue.ID}
Title: {returnValue.Title}
Artist: {returnValue.Artist}
Genre: {returnValue.Genre}
Song Duration: {returnValue.SongDuration} sec."); 
                }else{
                    Messages.ConsoleMessage("No record found.");
                }

            } else {
                Messages.ConsoleMessage("No songs in the library.");
            }

        }

        public void PlaylistSummaryScreen(){
            if (_songs.Count != 0){

                Messages.ConsoleMessage("** Playlist summary **");
               
                var totalSongs = _songs.Count;
                var totalSongsDuration = _songs.Select(song => song.SongDuration).Sum();
                var uniqueArtists = _songs.Select(song => song.Artist).Distinct().Count();

                var uniqueGenres = _songs.Select(song => song.Genre).Distinct().Count();

                Messages.ConsoleMessage(@$"Total Songs: {totalSongs}
Total Duration: {totalSongsDuration} sec.
Unique Artists: {uniqueArtists}
Unique Genres: {uniqueGenres}");

            }
        }

        public void GenreSongsExplorer()
        {
            if (_songs.Count != 0)
            {
                Messages.ConsoleMessage("** Choose genre **");

                Messages.ConsoleMessage("Rock, Pop, Jazz, Techno, Disco, R&B, Electronic");
                string input = InputValidator.StringValid();

                var genreSongsList = _songs.Where(song => song.Genre.ToLower() == input.ToLower());

                if(genreSongsList.Count() != 0){
                
                    foreach (var song in genreSongsList)
                    {
                        Messages.ConsoleMessage(@$"ID: {song.ID}
Title: {song.Title}
Artist: {song.Artist}
Song Duration: {song.SongDuration} sec.");
                        Messages.ConsoleMessage();
                    }

                    int genreSongsTotalDuration = genreSongsList.Select(song => song.SongDuration).Sum();

                    bool allGenreSongsTwoMinutes = genreSongsList.All(song => song.SongDuration > 120);

                    Messages.ConsoleMessage($"Count, total duration: {genreSongsTotalDuration}");
                    Messages.ConsoleMessage($"Are all songs in this genre over 2 min?: {allGenreSongsTwoMinutes}");
                }
            }
        }

        public void ArtistSongsExplorer()
        {
            if (_songs.Count != 0)
            {
                Messages.ConsoleMessage("** Choose artist **");
                string input = InputValidator.StringValid();

                var matchArtist = _songs.FirstOrDefault(song => song.Artist == input);

                if (matchArtist != null)
                {
                    var artistSongsList = _songs.Where(song => song.Artist == input);

                    Messages.ConsoleMessage($"\n*List of songs titles*");
                    foreach (var artist in artistSongsList)
                    {
                        Messages.ConsoleMessage(@$"Title: {artist.Title}
Genre: {artist.Genre}
Song Duration: {artist.SongDuration} sec.");
                        Messages.ConsoleMessage();
                    }

                    Messages.ConsoleMessage($"Total of songs: {artistSongsList.Count()}");
                }else
                {
                    Messages.ConsoleMessage("No artist found.");
                }
            }
        }

        public void AddSong(){

            Messages.ConsoleMessage("** Add new song **");

            Console.Write("Title: ");
            string title = InputValidator.StringValid();
            Console.Write("Artist: ");
            string artist = InputValidator.StringValid();
            Console.Write("Genre: ");
            string genre = InputValidator.StringValid();
            Console.Write("Song duration[seconds]: ");
            int songDuration = InputValidator.IntegerValid();
            
           
            var newSong = new Songs()
            {
                ID= _songs.Count+1,
                Title = title,
                Artist = artist,
                Genre = genre,
                SongDuration = songDuration
            };

            FileOperations.SaveToJson(newSong);

            Messages.ConsoleMessage("Song Saved!");        
        }

        public void SongsFilters(){     

            Messages.ConsoleMessage("Songs Filters:");
            foreach (SongsFiltersOptions song in Enum.GetValues(typeof(SongsFiltersOptions)))
            {
                Messages.ConsoleMessage($"{(int)song}.{song.GetDescription()}");
            }
        }

        public void SongsSortOptions(){   
            Messages.ConsoleMessage("Songs Sort Options (type option number and \"asc\" or \"desc\" order), example 1asc:");
            foreach (SongsSortOptions song in Enum.GetValues(typeof(SongsSortOptions)))
            {
                Messages.ConsoleMessage($"{(int)song}.{song.GetDescription()}");
            }

        }
    }
}
