using PetsLostAndFoundSystem.Constants;
using System;
using System.ComponentModel.DataAnnotations;

namespace PetsLostAndFoundSystem.Data.Models
{
    public class Shelter
    {
        public int Id { get; set; }

        [Required]
        [MinLength(DataConstants.UserNameMinLength)]
        [MaxLength(DataConstants.UserNameMaxLength)]
        public string Name { get; set; }

        [Required]
        public TypeShelter Type { get; set; }

        [MinLength(5)]
        [MaxLength(2000)]
        public string WebPageUrl { get; set; }

        [Required]
        [MinLength(DataConstants.CityMinLength)]
        [MaxLength(DataConstants.CityMaxLength)]
        public string City { get; set; }

        [Required]
        [MinLength(DataConstants.BusinessAddressMinLength)]
        [MaxLength(DataConstants.BusinessAddressMaxLength)]
        public string Address { get; set; }

        public double LatLocation { get; set; }

        public double LngLocation { get; set; }

        [Required]
        public PetType PetType { get; set; }

        public string Note { get; set; }
            
        [MinLength(DataConstants.PicUrlMinLength)]
        [MaxLength(DataConstants.PicUrlMaxLength)]
        public string PicUrl { get; set; }

        public string Image { get; set; }

        public DateTime PublishDate { get; set; }

        public bool IsApproved { get; set; }

        public int AuthorId { get; set; }

        public Author Author { get; set; }

        public int ReporterId { get; set; }

        public Reporter Reporter { get; set; }
    }
}
