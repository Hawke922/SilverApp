using System.ComponentModel.DataAnnotations;

namespace Silver.API.Dtos
{
    public class CharacterForCreateDto
    {
        [Required]
        [StringLength(10, MinimumLength = 4, ErrorMessage = "Name must be 4 to 10 characters long.")]
        public string Name { get; set; }
        [Required]
        public string Class { get; set; }
        [Required]
        public string PictureUrl { get; set; }
        public int UserId { get; set; }
    }
}