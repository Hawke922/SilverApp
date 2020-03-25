using System.Collections.Generic;

namespace Silver.API.Dtos
{
    public class DungeonForMenuDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Difficulty { get; set; }
        public string DescriptionLong { get; set; }
        public string DescriptionShort { get; set; }
        public string BackgroundUrl { get; set; }
        public string ThumbnailUrl { get; set; }
        public ICollection<EnemyForDungeonMenu> Enemies { get; set; }
    }
}