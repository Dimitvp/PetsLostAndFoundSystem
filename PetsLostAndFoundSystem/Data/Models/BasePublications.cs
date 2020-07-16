using System;
using System.ComponentModel.DataAnnotations;

namespace PetsLostAndFoundSystem.Data.Models
{
    public class BasePublications
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }
        public string PicUrl { get; set; }

        public DateTime PublishDate { get; set; }
    }
}
