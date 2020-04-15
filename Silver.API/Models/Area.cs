using System.Collections.Generic;

namespace Silver.API.Models
{
    public class Area
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CodeName { get; set; }
        public string Description { get; set; }
        public string ThumbnailUrl { get; set; }

        // Threshold when area will be unlocked, will compare to Explored prop on character model
        public int UnlockOn { get; set; }
        public int ExploreMax { get; set; }
        public ICollection<Enemy> Enemies { get; set; }
        public Dungeon Dungeon { get; set; }
        public int DungeonId { get; set; }
    }
}