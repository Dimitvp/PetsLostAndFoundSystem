using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PetsLostAndFoundSystem.Infrastructure;
using PetsLostAndFoundSystem.Publications.Data;
using PetsLostAndFoundSystem.Publications.Services.Article;
using PetsLostAndFoundSystem.Publications.Services.Author;
using PetsLostAndFoundSystem.Publications.Services.Contracts;
using PetsLostAndFoundSystem.Publications.Services.Shelter;

namespace PetsLostAndFoundSystem.Publications
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
             => this.Configuration = configuration;

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
            => services
                .AddWebService<PublicationsDbContext>(this.Configuration)
                .AddTransient<IArticleService, ArticleService>()
                .AddTransient<IAuthorService, AuthorService>()
                .AddTransient<IShelterService, ShelterService>()
                .AddMessaging(this.Configuration);

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
            => app
                .UseWebService(env)
                .Initialize();
    }
}
