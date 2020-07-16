using System;
using System.ComponentModel.DataAnnotations;

using PetsLostAndFoundSystem.Publications.Constants;

namespace PetsLostAndFoundSystem.Publications.Data.Models
{
    public class Shelter
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public TypeShelter Type { get; set; }

        [MinLength(5)]
        [MaxLength(2000)]
        public string WebPageUrl { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string Address { get; set; }

        public double LatLocation { get; set; }

        public double LngLocation { get; set; }

        public string Note { get; set; }
            
        public string PicUrl { get; set; }

        public string Image { get; set; }

        public DateTime PublishDate { get; set; }

        public bool IsApproved { get; set; }

        public int AuthorId { get; set; }

        public Author Author { get; set; }
    }
}
