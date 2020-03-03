using System.ComponentModel.DataAnnotations;

namespace Silver.API.Dtos
{
    public class UserForRegisterDto
    {
        [Required]
        public string Username { get; set; }

        [Required]
        [StringLength(12, MinimumLength = 6, ErrorMessage = "Please use password 6 to 12 characters long")]
        public string Password { get; set; }
    }
}