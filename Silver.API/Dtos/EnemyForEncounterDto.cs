using System.Collections.Generic;

namespace Silver.API.Dtos
{
    public class EnemyForEncounterDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PictureUrl { get; set; }
        public string DescriptionLong { get; set; }
        public string DescriptionShort { get; set; }
        public int Hp { get; set; }
        public int FastAttack { get; set; }
        public int StrongAttack { get; set; }
        public int SpecialAttack { get; set; }
        public int FastDefense { get; set; }
        public int StrongDefense { get; set; }
        public int SpecialDefense { get; set; }
        public bool IsBoss { get; set; }
        public ICollection<AbilitiesForCharacterMenuDto> Abilities { get; set; }
    }
}