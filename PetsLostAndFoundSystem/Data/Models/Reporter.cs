using PetsLostAndFoundSystem.Constants;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PetsLostAndFoundSystem.Data.Models
{
    public class Reporter
    {
        public string Id { get; set; }

        [MinLength(DataConstants.UserNameMinLength)]
        public string Name { get; set; }

        public string PhoneNumber { get; set; }

        public string UserId { get; set; }

        public User User { get; set; }

        public ICollection<Report> Reports { get; set; } = new List<Report>();

        public ICollection<Shelter> Shelters { get; set; } = new List<Shelter>();

        public ICollection<Pet> Pets { get; set; } = new List<Pet>();
    }
}
