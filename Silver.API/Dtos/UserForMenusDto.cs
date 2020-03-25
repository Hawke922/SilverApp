using System.Collections.Generic;

namespace Silver.API.Dtos
{
    public class UserForMenusDto
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public ICollection<CharacterDto> Characters { get; set; }
    }
}