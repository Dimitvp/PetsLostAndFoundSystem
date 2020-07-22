using MassTransit;
using PetsLostAndFoundSystem.Messages.Reporters;
using PetsLostAndFoundSystem.Statistics.Services.Statistics;
using System.Threading.Tasks;

namespace PetsLostAndFoundSystem.Statistics.Messages
{
    public class ReportCreatedConsumer : IConsumer<ReportCreatedMessage>
    {
        private readonly IStatisticsService statistics;

        public ReportCreatedConsumer(IStatisticsService statistics)
            => this.statistics = statistics;

        public async Task Consume(ConsumeContext<ReportCreatedMessage> context)
            => await this.statistics.AddReport(context.Message.Status);
    }
}
