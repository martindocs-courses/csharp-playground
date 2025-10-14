
using System.Text.Json.Serialization;

namespace MusicPlaylistAnalyzer.Models{
    public class Songs{
        [JsonPropertyName("id")]
        public int ID { get; set; }
        [JsonPropertyName("title")]
        public string Title { get; set; }
        [JsonPropertyName("artist")]
        public string Artist { get; set; }
        [JsonPropertyName("genre")]
        public string Genre { get; set; }
        [JsonPropertyName("durationSeconds")]
        public int SongDuration { get; set; }
    }
}
