using System.Collections.Generic;

namespace Silver.API.Dtos
{
    public class EnemyForDungeonMenu
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PictureUrl { get; set; }
        public string ThumbnailUrl { get; set; }
        public string DescriptionLong { get; set; }
        public string DescriptionShort { get; set; }
        public bool IsBoss { get; set; }
        public int DungeonId { get; set; }
        public ICollection<AbilitiesForCharacterMenuDto> Abilities { get; set; }
    }
}