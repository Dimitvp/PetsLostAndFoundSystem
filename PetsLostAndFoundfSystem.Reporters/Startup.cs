using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using PetsLostAndFoundSystem.Infrastructure;
using PetsLostAndFoundSystem.Reporters.Data;
using PetsLostAndFoundSystem.Services;

namespace PetsLostAndFoundSystem.Reporters
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
             => this.Configuration = configuration;

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
            => services
                .AddWebService<ReportersDbContext>(this.Configuration)
                .AddTransient<IDataSeeder, ReportersDataSeeder>();

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
            => app
                .UseWebService(env)
                .Initialize();
    }
}
