namespace BlueNestKaraoke.Data.Entities
{
    public class Event
    {
        public int Id { get; set; }
        public string? Description { get; set; }
        public DateTime Date { get; set; }
        public string? Status { get; set; } // "current", "completed", "upcoming"
    }
}