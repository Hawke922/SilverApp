using System.Collections.Generic;

namespace Silver.API.Models
{
    public class Character
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Class { get; set; }
        public string PictureUrl { get; set; }
        public int Hp { get; set; }
        public int FastAttack { get; set; }
        public int StrongAttack { get; set; }
        public int SpecialAttack { get; set; }
        public int FastDefense { get; set; }
        public int StrongDefense { get; set; }
        public int SpecialDefense { get; set; }
        public string FastAttAbility { get; set; }
        public string StrongAttAbility { get; set; }
        public string SpecialAttAbility { get; set; }
        public string fastDefAbility { get; set; }
        public string StrongDefAbility { get; set; }
        public string SpecialDefAbility { get; set; }
        public string FastAttAbilityIcon { get; set; }
        public string StrongAttAbilityIcon { get; set; }
        public string SpecialAttAbilityIcon { get; set; }
        public string fastDefAbilityIcon { get; set; }
        public string StrongDefAbilityIcon { get; set; }
        public string SpecialDefAbilityIcon { get; set; }
        public string ClassIcon { get; set; }
        public int CharacterCounter { get; set; }
        public int ActiveDungeonId { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
        public virtual ICollection<AbilityCharacter> AbilityCharacters { get; set; }
    }
}