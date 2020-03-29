namespace Silver.API.Models
{
    public class EnemyAbility
    {
        public int EnemyId { get; set; }
        public Enemy Enemy { get; set; }
        public int AbilityId { get; set; }
        public Ability Ability { get; set; }
    }
}