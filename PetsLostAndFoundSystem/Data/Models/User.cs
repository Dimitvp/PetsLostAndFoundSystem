using Microsoft.AspNetCore.Identity;
using PetsLostAndFoundSystem.Constants;
using System.Collections.Generic;

namespace PetsLostAndFoundSystem.Data.Models
{
    public class User : IdentityUser
    {
        public User()
        {
            this.Comments = new List<Comment>();
        }

        public UserType UserType { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public Author Author { get; set; }

        public Reporter Reporter { get; set; }

        public ICollection<Comment> Comments { get; set; }
    }
}
    