using MassTransit;
using Microsoft.AspNetCore.SignalR;
using PetsLostAndFoundSystem.Messages.Reporters;
using PetsLostAndFoundSystem.Notifications.Hub;
using System.Threading.Tasks;

using static PetsLostAndFoundSystem.Notifications.Constants;

namespace PetsLostAndFoundSystem.Notifications.Messages
{
    public class ReportCreatedConsumer : IConsumer<ReportCreatedMessage>
    {
        private readonly IHubContext<NotificationsHub> hub;

        public ReportCreatedConsumer(IHubContext<NotificationsHub> hub)
            => this.hub = hub;

        public async Task Consume(ConsumeContext<ReportCreatedMessage> context)
            => await this.hub
                .Clients
                .Groups(AuthenticatedUsersGroup)
                .SendAsync(ReceiveNotificationEndpoint, context.Message);
    }
}
