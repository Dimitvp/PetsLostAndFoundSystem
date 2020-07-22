using PetsLostAndFoundSystem.Data.Enums;
using System;

namespace PetsLostAndFoundSystem.MVC.Models.Reports
{
    public class ReportDetailsOutputModel
    {
        public int Id { get; set; }

        public PetStatusType Status { get; set; }

        public DateTime LostDate { get; set; }

        public string Content { get; set; }
        public string PicUrl { get; set; }

        public DateTime PublishDate { get; set; }
    }
}