using NUnit.Framework;
using PactNet;
using Piast.Api.Tests.Pact.Fakes;

namespace Piast.Api.Tests.Pact
{
    [TestFixture]
    public class PactVerificationTests
    {
        [Test]
        public void Verify_Wep_Pacts()
        {
            using(var fakeApp = new FakeWebHostStarter())
            {
                var config = new PactVerifierConfig();

                IPactVerifier pactVerifier = new PactVerifier(config);

                var pactUri = "./../../../../../Web/Piast.Web.Tests/pacts/web-api.json";


                pactVerifier
                    .ProviderState("http://localhost:5000/Ping")
                    .ServiceProvider("Api","http://localhost:5000")
                    .HonoursPactWith("Web")
                    .PactUri(pactUri)
                    .Verify();
            }
        }
    }
}