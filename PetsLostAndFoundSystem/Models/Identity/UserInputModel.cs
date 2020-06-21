using System.ComponentModel.DataAnnotations;

using PetsLostAndFoundSystem.Constants;

namespace PetsLostAndFoundSystem.Models.Identity
{
    public class UserInputModel
    {
        [EmailAddress]
        [Required]
        [MinLength(DataConstants.EmailMinLength)]
        [MaxLength(DataConstants.EmailMaxLength)]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
