﻿using System.ComponentModel.DataAnnotations;

namespace PetsLostAndFoundSystem.Data.Models
{
    public class Comment
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string Content { get; set; }

        public string UserId { get; set; }

        [Required]
        public User User { get; set; }

        public string PostId { get; set; }

        [Required]
        public Report Post { get; set; }

        public int Likes { get; set; }

        public int Dislikes { get; set; }
    }
}