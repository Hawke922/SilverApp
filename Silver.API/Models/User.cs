using System.Collections.Generic;

namespace Silver.API.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public int ActiveCharacterId { get; set; }
        public ICollection<Character> Characters { get; set; }
    }
}