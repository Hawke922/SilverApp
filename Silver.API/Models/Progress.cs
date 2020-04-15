using System.Collections.Generic;

namespace Silver.API.Models
{
    public class Progress
    {
        public int Id { get; set; }
        public ICollection<DungeonProgress> DungeonProgress { get; set; }
        public ICollection<AreaProgress> AreaProgress { get; set; }
        public Character Character { get; set; }
        public int CharacterId { get; set; }
    }
}