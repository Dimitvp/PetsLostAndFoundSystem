using PetsLostAndFoundSystem.MVC.Constants;
using PetsLostAndFoundSystem.MVC.Data.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace PetsLostAndFoundSystem.MVC.Models.Reports
{
    public class ReportInputModel
    {
        [Required]
        public PetStatusType Status { get; set; }

        public DateTime LostDate { get; set; }

        public string ImagesLinksPost { get; set; }

        public double? RewardSum { get; set; }

        public Pet Pet { get; set; }

        [Required]
        public Location Location { get; set; }

        public bool IsApproved { get; set; }
    }
}
