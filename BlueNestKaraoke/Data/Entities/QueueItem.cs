namespace BlueNestKaraoke.Data.Entities
{
    public class QueueItem
    {
        public QueueItem()
        {
            RequestedSingers = new List<QueueItemRequestedSinger>();
        }

        public int Id { get; set; }
        public int EventId { get; set; }
        public Event? Event { get; set; }
        public int SongId { get; set; }
        public Song? Song { get; set; }
        public string? SingerId { get; set; }
        public ApplicationUser? Singer { get; set; }
        public int Position { get; set; }
        public bool IsSolo { get; set; }
        public virtual List<QueueItemRequestedSinger>? RequestedSingers { get; set; }
    }
}