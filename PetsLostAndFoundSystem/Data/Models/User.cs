using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using PetsLostAndFoundSystem.Constants;

namespace PetsLostAndFoundSystem.Data.Models
{
    public class User : IdentityUser
    {
        [MinLength(DataConstants.UserNameMinLength)]
        [MaxLength(DataConstants.UserNameMaxLength)]
        public string Name { get; set; }

        public List<Article> Articles { get; set; } = new List<Article>();

        public List<Ad> Ads { get; set; } = new List<Ad>();

        public List<Shelter> Shelters { get; set; } = new List<Shelter>();
    }
}
    