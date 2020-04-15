using Silver.API.Models;

namespace Silver.API.Dtos
{
    public class AreaProgressForMenuDto
    {
        public int AreaId { get; set; }
        public int Explored { get; set; }
        public int DungeonId { get; set; }
    }
}