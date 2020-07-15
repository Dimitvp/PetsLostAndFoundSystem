using PetsLostAndFoundSystem.Constants;
using System;
using System.ComponentModel.DataAnnotations;

namespace PetsLostAndFoundSystem.Data.Models
{
    public class BasePublications
    {
        public int Id { get; set; }

        [Required]
        [MinLength(DataConstants.PublicationTitleMinLength)]
        [MaxLength(DataConstants.PublicationTitleMaxLength)]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        [MinLength(DataConstants.PicUrlMinLength)]
        [MaxLength(DataConstants.PicUrlMaxLength)]
        public string PicUrl { get; set; }

        public DateTime PublishDate { get; set; }
    }
}
