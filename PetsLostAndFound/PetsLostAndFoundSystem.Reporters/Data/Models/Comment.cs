﻿using System.ComponentModel.DataAnnotations;

namespace PetsLostAndFoundSystem.Reporters.Data.Models
{
    public class Comment
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string Content { get; set; }

        public int ReporterId { get; set; }

        [Required]
        public Reporter Reporter { get; set; }

        public int PostId { get; set; }

        [Required]
        public Report Post { get; set; }

        public int Likes { get; set; }

        public int Dislikes { get; set; }
    }
}
