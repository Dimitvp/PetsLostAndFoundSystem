using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

using PetsLostAndFoundSystem.Models;

namespace PetsLostAndFoundSystem.Admin.Models.Reporters
{
    public class ReporterFromModel : IMapFrom<ReporterDetailsOutputModel>
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [DisplayName("Phone Number")]
        public string PhoneNumber { get; set; }
    }
}
