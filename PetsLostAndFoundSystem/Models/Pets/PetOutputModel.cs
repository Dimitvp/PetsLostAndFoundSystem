using PetsLostAndFoundSystem.Constants;
using PetsLostAndFoundSystem.Data.Models;
using System.ComponentModel.DataAnnotations;

namespace PetsLostAndFoundSystem.Models.Pets
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
