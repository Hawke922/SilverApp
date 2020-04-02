using System.Collections.Generic;

namespace Silver.API.Dtos
{
    public class DungeonForEncounterDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CodeName { get; set; }
        public int Difficulty { get; set; }
        public ICollection<EnemyForEncounterDto> Enemies { get; set; }
    }
}