using Microsoft.EntityFrameworkCore;
using Silver.API.Models;

namespace Silver.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) {}
        public DbSet<User> Users { get; set; }
        public DbSet<Character> Characters { get; set; }
        public DbSet<Dungeon> Dungeons { get; set; }
        public DbSet<Enemy> Enemies { get; set; }
        public DbSet<Ability> Abilities { get; set; }
        public DbSet<AbilityCharacter> AbilityCharacters { get; set; }
        public DbSet<EnemyAbility> EnemyAbilities { get; set; }
        public DbSet<Type> Types { get; set; }
        public DbSet<Area> Areas { get; set; }
        public DbSet<Progress> Progress { get; set; }
        public DbSet<DungeonProgress> DungeonProgress { get; set; }
        public DbSet<AreaProgress> AreaProgress { get; set; }

        // Making pairings of primary keys unique
        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<AbilityCharacter>().HasKey(ac => new { ac.AbilityId, ac.CharacterId });
            modelBuilder.Entity<EnemyAbility>().HasKey(ac => new { ac.EnemyId, ac.AbilityId });
        }
    }

}