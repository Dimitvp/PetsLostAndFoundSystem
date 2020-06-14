using PetsLostAndFoundSystem.Constants;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PetsLostAndFoundSystem.Data.Models
{
    public class Pet
    {
        public Pet()
        {
            this.Reports = new List<Report>();
        }

        public int Id { get; set; }

        public PetType PetType { get; set; }

        [Required]
        public string Name { get; set; }

        public int Age { get; set; }

        public string RFID { get; set; }

        public string PetDescription { get; set; }

        public string ReporterId { get; set; }

        [Required]
        public Reporter Reporter { get; set; }

        public ICollection<Report> Reports { get; set; }
    }
}
