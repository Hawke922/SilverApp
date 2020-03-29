using System.Collections.Generic;

namespace Silver.API.Models
{
    public class Ability
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Icon { get; set; }
        public string Description { get; set; }
        public int BaseDamage { get; set; }
        public int TypeId { get; set; }
        public bool IsOffensive { get; set; }
        public Type Type { get; set; }
        public ICollection<AbilityCharacter> AbilityCharacters { get; set; }
        public ICollection<EnemyAbility> EnemyAbilities { get; set; }
        
    }
}