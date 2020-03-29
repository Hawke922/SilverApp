using System.ComponentModel.DataAnnotations;

namespace Silver.API.Dtos
{
    public class CharacterSelectionDto
    {
        [Required]
        public int CharacterId { get; set; }
        [Required]
        public int UserId { get; set; }
    }
}