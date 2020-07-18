using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PetsLostAndFoundSystem.Infrastructure;
using PetsLostAndFoundSystem.Notifications.Hub;
using PetsLostAndFoundSystem.Notifications.Infrastructure;
using PetsLostAndFoundSystem.Notifications.Messages;

namespace PetsLostAndFoundSystem.Notifications
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
             => this.Configuration = configuration;

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
            => services
                .AddCors()
                .AddTokenAuthentication(
                    this.Configuration,
                    JwtConfiguration.BearerEvents)
                .AddMessaging(typeof(ReportCreatedConsumer))
                .AddSignalR();

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app
                .UseRouting()
                .UseCors(options => options
                    .WithOrigins("http://localhost:4200")
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowCredentials())
                .UseAuthentication()
                .UseAuthorization()
                .UseEndpoints(endpoints => endpoints
                .MapHub<NotificationsHub>("/notifications"));
        }
    }
}
