using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using PetsLostAndFoundSystem.Identity.Contracts;
using PetsLostAndFoundSystem.Identity.Data;
using PetsLostAndFoundSystem.Identity.Infrastructure;
using PetsLostAndFoundSystem.Identity.Services.Identity;
using PetsLostAndFoundSystem.Infrastructure;
using PetsLostAndFoundSystem.Services;

namespace PetsLostAndFoundSystem.Identity
{
    public class Startup
    {
        public Startup(IConfiguration configuration) => this.Configuration = configuration;

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
            => services
                .AddWebService<IdentityDbContext>(this.Configuration)
                .AddUserStorage()
                .AddTransient<IDataSeeder, IdentityDataSeeder>()
                .AddTransient<IIdentityService, IdentityService>()
                .AddTransient<ITokenGeneratorService, TokenGeneratorService>();

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
            => app
                .UseWebService(env)
                .Initialize();
    }
}
