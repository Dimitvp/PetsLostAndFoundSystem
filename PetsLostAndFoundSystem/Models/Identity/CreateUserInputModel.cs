using PetsLostAndFoundSystem.Constants;
using System.ComponentModel.DataAnnotations;

namespace PetsLostAndFoundSystem.Models.Identity
{
    public class CreateUserInputModel : UserInputModel
    {
        [Required]
        [MinLength(DataConstants.UserNameMinLength)]
        [MaxLength(DataConstants.UserNameMaxLength)]
        public string Name { get; set; }

        [Required]
        [MinLength(DataConstants.PhoneNumberMinLength)]
        [MaxLength(DataConstants.PhoneNumberMaxLength)]
        [RegularExpression(DataConstants.PhoneNumberRegularExpression)]
        public string PhoneNumber { get; set; }
    }
}