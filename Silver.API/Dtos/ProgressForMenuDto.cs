using System.Collections.Generic;
using Silver.API.Models;

namespace Silver.API.Dtos
{
    public class ProgressForMenuDto
    {
        public ICollection<DungeonProgressForMenuDto> DungeonProgress { get; set; }
        public ICollection<AreaProgressForMenuDto> AreaProgress { get; set; }
    }
}