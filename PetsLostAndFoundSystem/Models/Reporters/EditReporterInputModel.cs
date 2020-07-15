using PetsLostAndFoundSystem.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PetsLostAndFoundSystem.Models.Reporters
{
    public class EditReporterInputModel
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
