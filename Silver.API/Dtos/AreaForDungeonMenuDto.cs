using System.Collections.Generic;

namespace Silver.API.Dtos
{
    public class AreaForDungeonMenuDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CodeName { get; set; }
        public string Description { get; set; }
        public string ThumbnailUrl { get; set; }
        public int UnlockOn { get; set; }
        public int ExploreMax { get; set; }
        public ICollection<EnemyForDungeonMenu> Enemies { get; set; }
    }
}