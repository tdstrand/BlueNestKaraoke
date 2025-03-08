namespace BlueNestKaraoke.Data.Entities
{
    public class Song
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Artist { get; set; }
        public string? Genre { get; set; }
        public string? YouTubeUrl { get; set; }
        public string? Status { get; set; } // "approved" or "pending"
        public int PlayCount { get; set; }
    }
}