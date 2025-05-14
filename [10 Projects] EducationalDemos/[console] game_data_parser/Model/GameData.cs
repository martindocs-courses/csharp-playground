namespace gameDataParser.Model
{
    // It's used as the data model for reading/writing game info regardless of the file format (JSON, CSV, etc.)
    public class GameData
    {
        public string? Title { get; set; }
        public int ReleaseYear { get; set; }
        public double Rating { get; set; }

        // Custom string representation for easy printing to console/logs.
        public override string ToString()
        {
            return $"{Title}, released in {ReleaseYear}, rating: {Rating}";
        }
    }
}
