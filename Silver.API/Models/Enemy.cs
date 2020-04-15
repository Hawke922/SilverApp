using System.Collections.Generic;

namespace Silver.API.Models
{
    public class Enemy
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PictureUrl { get; set; }
        public string ThumbnailUrl { get; set; }
        public string Description { get; set; }
        public int Hp { get; set; }
        public int FastAttack { get; set; }
        public int StrongAttack { get; set; }
        public int SpecialAttack { get; set; }
        public int FastDefense { get; set; }
        public int StrongDefense { get; set; }
        public int SpecialDefense { get; set; }
        public bool IsBoss { get; set; }
        public Dungeon Dungeon { get; set; }
        public int DungeonId { get; set; }
        public ICollection<EnemyAbility> EnemyAbilities { get; set; }
    }
}