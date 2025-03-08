namespace BlueNestKaraoke.Data.Entities
{
    public class QueueItemRequestedSinger
    {
        public int QueueItemId { get; set; }
        public QueueItem? QueueItem { get; set; }
        public string? SingerId { get; set; }
        public ApplicationUser? Singer { get; set; }
    }
}