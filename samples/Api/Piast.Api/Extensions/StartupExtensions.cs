using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using Piast.Api.Domain.Entities;
using Piast.Api.Domain.Repositories;
using Piast.Api.Domain.Repositories.Interfaces;
using Piast.Api.Infrastructure.Converters;
using Piast.Api.Infrastructure.Converters.Interfaces;
using Piast.Api.Infrastructure.Services;
using Piast.Api.Infrastructure.Services.Interfaces;

namespace Piast.Api.Extensions
{
    public static class StartupExtensions
    {
        public static IServiceCollection RegisterDatabase(this IServiceCollection services, string connectionString)
        {
            services.AddSingleton<IMongoClient>(new MongoClient(connectionString));

            services.AddScoped<IRepository<Advertisement>,BaseRepository<Advertisement>>();

            return services;
        }

        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.AddAutoMapper();

            services.AddScoped<IAdvertisementConverter,AdvertisementConverter>();
            
            services.AddScoped<IAdvertisementService,AdvertisementService>();
            
            return services;
        }
    }
}