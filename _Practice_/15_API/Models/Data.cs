

namespace API.Models
{
    public class Data{    
        public string title { get; set; }
        public string body { get; set; }
        public int userId { get; set; }
    }

    public class PatchData{
        public string? title { get; set; }
        public string? body { get; set; }
        public int? userId { get; set; }
    }
}
