using Hangfire;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PetsLostAndFoundSystem.Data.Models;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PetsLostAndFoundSystem.Messages
{
    public class MessagesHostedService : IHostedService
    {
        private readonly IRecurringJobManager recurringJob;
        private readonly DbContext data;
        private readonly IBus publisher;
        private readonly IServiceScopeFactory _serviceScopeFactory;

        public MessagesHostedService(
            IRecurringJobManager recurringJob,
            DbContext data,
            IBus publisher,
            IServiceScopeFactory serviceScopeFactory)
        {
            this.recurringJob = recurringJob;
            this.data = data;
            this.publisher = publisher;
            this._serviceScopeFactory = serviceScopeFactory;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            using (var scope = this._serviceScopeFactory.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetService<DbContext>();

                if (!dbContext.Database.CanConnect())
                {
                    dbContext.Database.Migrate();
                }
            }

            this.recurringJob.AddOrUpdate(
                nameof(MessagesHostedService),
                () => this.ProcessPendingMessages(),
                "*/5 * * * * *");

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
            => Task.CompletedTask;

        public void ProcessPendingMessages()
        {
            var messages = this.data
                .Set<Message>()
                .Where(m => !m.Published)
                .OrderBy(m => m.Id)
                .ToList();

            foreach (var message in messages)
            {
                this.publisher.Publish(message.Data, message.Type);

                message.MarkAsPublished();

                this.data.SaveChanges();
            }
        }
    }
}
