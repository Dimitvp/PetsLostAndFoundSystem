using PetsLostAndFoundSystem.MVC.Constants;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PetsLostAndFoundSystem.MVC.Data.Models
{
    public class Author
    {
        public int Id { get; set; }

        [MinLength(DataConstants.UserNameMinLength)]
        public string Name { get; set; }

        public string UserId { get; set; }

        public User User { get; set; }

        public ICollection<Article> Articles { get; set; } = new List<Article>();

        public ICollection<Shelter> Shelters { get; set; } = new List<Shelter>();

    }
}
