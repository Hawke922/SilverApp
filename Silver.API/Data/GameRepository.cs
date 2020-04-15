using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Silver.API.Models;

namespace Silver.API.Data
{
    public class GameRepository : IGameRepository
    {
        private readonly DataContext _context;
        public GameRepository(DataContext context)
        {
            _context = context;

        }
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public async Task<User> GetUser(int id)
        {
            var user = await _context.Users.Include(p => p.Characters).FirstOrDefaultAsync(u => u.Id == id);

            return user;
        }
        public async Task<Character> CreateCharacter(Character character)
        {
            await _context.Characters.AddAsync(character);
            await _context.SaveChangesAsync();
            return character;
        }

        public async Task<Character> GetCharacter(int id)
        {
            var character = await _context.Characters.Include(p => p.Progress).ThenInclude(p => p.DungeonProgress)
            .Include(p => p.Progress).ThenInclude(p => p.AreaProgress)
            .Include(p => p.AbilityCharacters).ThenInclude(p => p.Ability).FirstOrDefaultAsync(c => c.Id == id);

            return character;
        }

        public async Task<Dungeon> GetDungeon(int id)
        {
            var dungeon = await _context.Dungeons.Include(p => p.Enemies).Include(p => p.Areas).FirstOrDefaultAsync(u => u.Id == id);

            return dungeon;
        }

        public async Task<Enemy> GetEnemy(int id)
        {
            var enemy = await _context.Enemies.Include(p => p.EnemyAbilities).ThenInclude(p => p.Ability).FirstOrDefaultAsync(e => e.Id == id);

            return enemy;
        }      

        public async Task<bool> SaveAll()
        {
            return await _context.SaveChangesAsync() > 0;
        }

         public async Task<bool> CharacterExists(string name)
        {
            if (await _context.Characters.AnyAsync(x => x.Name == name))
                return true;
            
            return false;
        }
    }
}