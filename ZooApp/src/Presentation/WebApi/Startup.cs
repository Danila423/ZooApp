using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using ZooApp.Application.Interfaces;
using ZooApp.Application.Services;
using ZooApp.Domain.Repositories;
using ZooApp.Infrastructure.InMemory;
using ZooApp.Infrastructure.Messaging;

namespace ZooApp.Presentation.WebApi
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration) => Configuration = configuration;

        public void ConfigureServices(IServiceCollection services)
        {
            // Репозитории
            services.AddSingleton<IAnimalRepository, AnimalRepository>();
            services.AddSingleton<IEnclosureRepository, EnclosureRepository>();
            services.AddSingleton<IFeedingScheduleRepository, FeedingScheduleRepository>();
            // Шина событий
            services.AddSingleton<InMemoryMessageBus>();

            // Application‑сервисы
            services.AddTransient<IAnimalTransferService, AnimalTransferService>();
            services.AddTransient<IFeedingOrganizationService, FeedingOrganizationService>();
            services.AddTransient<IZooStatisticsService, ZooStatisticsService>();

            services.AddControllers();
            services.AddSwaggerGen(c =>
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Zoo API", Version = "v1" })
            );
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseRouting();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Zoo API v1")
            );
            app.UseEndpoints(endpoints => endpoints.MapControllers());
        }
    }
}
