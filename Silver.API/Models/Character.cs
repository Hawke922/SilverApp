using System.Collections.Generic;

namespace Silver.API.Models
{
    public class Character
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Class { get; set; }
        public string PictureUrl { get; set; }
        public string ThumbnailUrl { get; set; }
        public int Hp { get; set; }
        public int FastAttack { get; set; }
        public int StrongAttack { get; set; }
        public int SpecialAttack { get; set; }
        public int FastDefense { get; set; }
        public int StrongDefense { get; set; }
        public int SpecialDefense { get; set; }
        public string ClassIcon { get; set; }
        public int ActiveDungeonId { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
        public ICollection<AbilityCharacter> AbilityCharacters { get; set; }
        public Progress Progress { get; set; }
    }
}