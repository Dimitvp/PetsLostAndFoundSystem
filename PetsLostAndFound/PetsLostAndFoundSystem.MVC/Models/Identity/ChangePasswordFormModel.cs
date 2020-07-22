using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PetsLostAndFoundSystem.MVC.Models.Identity
{
    public class ChangePasswordFormModel
    {
        [Required]
        [DisplayName("Current Password")]
        public string CurrentPassword { get; set; }

        [Required]
        [DisplayName("New Password")]
        public string NewPassword { get; set; }
    }
}
