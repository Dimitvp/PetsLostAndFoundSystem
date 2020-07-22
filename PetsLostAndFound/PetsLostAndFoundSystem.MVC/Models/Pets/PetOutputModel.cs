using PetsLostAndFoundSystem.Data.Enums;
using System.ComponentModel.DataAnnotations;

namespace PetsLostAndFoundSystem.MVC.Models.Pets
{
    public class PetOutputModel
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
