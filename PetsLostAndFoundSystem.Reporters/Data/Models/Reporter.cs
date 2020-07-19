using System.Collections.Generic;

namespace PetsLostAndFoundSystem.Reporters.Data.Models
{
    public class Reporter
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string PhoneNumber { get; set; }

        public string UserId { get; set; }

        public ICollection<Report> Reports { get; set; } = new List<Report>();

        public ICollection<Pet> Pets { get; set; } = new List<Pet>();

        public ICollection<Comment> Comments { get; set; } = new List<Comment>();
    }
}
