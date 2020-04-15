using System.Collections.Generic;
using Silver.API.Dtos;
using Silver.API.Models;

namespace Silver.API.Dtos
{
    public class CharacterForMenuDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Class { get; set; }
        public string PictureUrl { get; set; }
        public int Hp { get; set; }
        public int FastAttack { get; set; }
        public int StrongAttack { get; set; }
        public int SpecialAttack { get; set; }
        public int FastDefense { get; set; }
        public int StrongDefense { get; set; }
        public int SpecialDefense { get; set; }
        public string ClassIcon { get; set; }
        public int ActiveDungeonId { get; set; }
        public ICollection<AbilitiesForCharacterMenuDto> Abilities { get; set; }
        public ProgressForMenuDto Progress { get; set; }
    }
}