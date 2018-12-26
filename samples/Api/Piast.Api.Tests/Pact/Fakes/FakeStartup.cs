using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Piast.Api.Domain.Entities;
using Piast.Api.Domain.Repositories.Interfaces;
using Piast.Api.Extensions;

namespace Piast.Api.Tests.Pact.Fakes
{
    public class FakeStartup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddScoped<IRepository<Advertisement>,FakeRepository>();
            services.RegisterServices();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(
            IApplicationBuilder app)
        {
            app.UseMvc();
            app.Map("/Ping", HandlePing);
            app.Map("/api/Advertisement/debdedbf-1524-4d83-8d74-7d05ffb02d6e", HandleGet);
        }

        private static void HandlePing(IApplicationBuilder app)
        {
            app.Run(async context => {
            });
        }

        private static void HandleGet(IApplicationBuilder app)
        {
            app.Run(async context => {
            });
        }
    }
}