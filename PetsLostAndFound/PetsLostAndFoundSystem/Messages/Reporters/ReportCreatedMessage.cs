using PetsLostAndFoundSystem.Data.Enums;

namespace PetsLostAndFoundSystem.Messages.Reporters
{
    public class ReportCreatedMessage
    {
        public int ReportId { get; set; }

        public PetStatusType Status { get; set; }

    }
}
