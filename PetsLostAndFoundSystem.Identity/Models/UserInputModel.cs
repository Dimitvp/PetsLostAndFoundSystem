using System.ComponentModel.DataAnnotations;

using static PetsLostAndFoundSystem.Data.DataConstants.Common;

namespace PetsLostAndFoundSystem.Identity.Models.Identity
{
    public class UserInputModel
    {
        [EmailAddress]
        [Required]
        [MinLength(EmailMinLength)]
        [MaxLength(EmailMaxLength)]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
