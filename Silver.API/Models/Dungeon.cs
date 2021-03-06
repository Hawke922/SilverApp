using System.Collections.Generic;

namespace Silver.API.Models
{
    public class Dungeon
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CodeName { get; set; }
        public int Difficulty { get; set; }
        public int UnlockOn { get; set; }
        public int ExploreMax { get; set; }
        public string DescriptionLong { get; set; }
        public string DescriptionShort { get; set; }
        public string BackgroundUrl { get; set; }
        public string ThumbnailUrl { get; set; }
        public ICollection<Enemy> Enemies { get; set; }
        public ICollection<Area> Areas { get; set; }
    }
}