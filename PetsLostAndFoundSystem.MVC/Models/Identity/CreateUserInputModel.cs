using PetsLostAndFoundSystem.MVC.Constants;
using System.ComponentModel.DataAnnotations;

namespace PetsLostAndFoundSystem.MVC.Models.Identity
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
        public string Phone { get; set; }
    }
}