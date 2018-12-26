using System;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace Piast.Api.Tests.Pact.Fakes
{
    public class FakeWebHostStarter : IDisposable
    {
        private IWebHost _webHost;
        public FakeWebHostStarter()
        {
            _webHost = WebHost.CreateDefaultBuilder(new string[0])
                .UseStartup<FakeStartup>()
                .Build();

            _webHost.StartAsync().GetAwaiter().GetResult();
        }
        public void Dispose()
        {
            _webHost.StopAsync().GetAwaiter().GetResult();
        }
    }
}