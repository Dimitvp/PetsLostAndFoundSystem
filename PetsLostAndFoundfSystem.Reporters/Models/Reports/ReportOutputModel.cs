using PetsLostAndFoundSystem.Data.Enums;
using PetsLostAndFoundSystem.Models;
using PetsLostAndFoundSystem.Reporters.Data.Models;
using System;

namespace PetsLostAndFoundSystem.Reporters.Models.Reports
{
    public class ReportOutputModel : IMapFrom<Report>
    {
        public PetStatusType Status { get; set; }

        public DateTime LostDate { get; set; }

        public string Content { get; set; }
        public string PicUrl { get; set; }

        public DateTime PublishDate { get; set; }
    }
}
