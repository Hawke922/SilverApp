using Microsoft.EntityFrameworkCore;
using Silver.API.Models;

namespace Silver.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options){}
        public DbSet<User> Users { get; set; }
        public DbSet<Character> Characters { get; set; }
        public DbSet<Dungeon> Dungeons { get; set; }
        public DbSet<Enemy> Enemies { get; set; }
    }
}