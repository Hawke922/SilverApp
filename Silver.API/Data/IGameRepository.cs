using System.Collections.Generic;
using System.Threading.Tasks;
using Silver.API.Models;

namespace Silver.API.Data
{
    public interface IGameRepository
    {
         void Add<T>(T entity) where T: class;
         void Delete<T>(T entity) where T: class;
         Task<bool> SaveAll();
         Task<User> GetUser(int id);
         Task<Character> GetCharacter(int id);
         Task<Dungeon> GetDungeon(int id);
         Task<Enemy> GetEnemy(int id);
         Task<bool> CharacterExists(string name);
         Task<Character> CreateCharacter(Character character);
    }
}