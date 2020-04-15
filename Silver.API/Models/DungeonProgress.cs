namespace Silver.API.Models
{
    public class DungeonProgress
    {
        public int Id { get; set; }
        public int DungeonId { get; set; }
        public int Explored { get; set; }
        public Progress Progress { get; set; }
        public int ProgressId { get; set; }
    }
}