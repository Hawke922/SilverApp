using System.Collections.Generic;

namespace Silver.API.Models
{
    public class Enemy
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PictureUrl { get; set; }
        public string ThumbnailUrl { get; set; }
        public string DescriptionLong { get; set; }
        public string DescriptionShort { get; set; }
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
        public bool IsBoss { get; set; }
        public Dungeon Dungeon { get; set; }
        public int DungeonId { get; set; }
        public ICollection<EnemyAbility> EnemyAbilities { get; set; }
    }
}