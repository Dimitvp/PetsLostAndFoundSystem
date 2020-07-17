using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using PetsLostAndFoundSystem.Infrastructure;
using PetsLostAndFoundSystem.Services;
using PetsLostAndFoundSystem.Statistics.Data;
using PetsLostAndFoundSystem.Statistics.Services.ReportViews;
using PetsLostAndFoundSystem.Statistics.Services.Statistics;

namespace PetsLostAndFoundSystem.Statistics
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
            => this.Configuration = configuration;

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
            => services
                .AddWebService<StatisticsDbContext>(this.Configuration)
                .AddTransient<IDataSeeder, StatisticsDataSeeder>()
                .AddTransient<IStatisticsService, StatisticsService>()
                .AddTransient<IReportViewService, ReportViewService>();

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
            => app
                .UseWebService(env)
                .Initialize();
    }
}
