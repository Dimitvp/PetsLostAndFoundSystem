using PetsLostAndFoundSystem.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PetsLostAndFoundSystem.Data.Models
{
    public class Report : BasePublications
    {
        public Report()
        {
            this.Comments = new List<Comment>();
        }

        [Required]
        public PetStatusType Status { get; set; }

        public ICollection<Comment> Comments { get; set; }

        public DateTime LostDate { get; set; }

        public string ImagesLinksPost { get; set; }

        public double? RewardSum { get; set; }

        public int PetId { get; set; }

        public Pet Pet { get; set; }

        public int LocationId { get; set; }

        [Required]
        public Location Location { get; set; }
        public bool IsApproved { get; set; }

        public int ReporterId { get; set; }

        public Reporter Reporter { get; set; }
    }
}
