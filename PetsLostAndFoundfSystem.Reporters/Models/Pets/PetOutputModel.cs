using System.ComponentModel.DataAnnotations;
using PetsLostAndFoundSystem.Data.Enums;
using PetsLostAndFoundSystem.Models;
using PetsLostAndFoundSystem.Reporters.Data.Models;

namespace PetsLostAndFoundSystem.Reporters.Models.Pets
{
    public class PetOutputModel : IMapFrom<Pet>
    {
        public int Id { get; set; }

        public PetType PetType { get; set; }

        [Required]
        public string Name { get; set; }

        public int Age { get; set; }

        public string RFID { get; set; }

        public string PetDescription { get; set; }
    }
}
