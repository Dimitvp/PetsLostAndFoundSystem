using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using PetsLostAndFoundSystem.Reporters.Constants;

namespace PetsLostAndFoundSystem.Reporters.Data.Models
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

        public int ReporterId { get; set; }

        [Required]
        public Reporter Reporter { get; set; }

        public ICollection<Report> Reports { get; set; }
    }
}
