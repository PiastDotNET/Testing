using System;
using System.Collections.Generic;
using System.Net.Http;
using Newtonsoft.Json;
using NUnit.Framework;
using PactNet;
using PactNet.Mocks.MockHttpService.Models;
using PactNet.Models;
using Piast.Web.Core.Models;
using Piast.Web.Core.Services.Interfaces;
using RestEase;
using Shouldly;

namespace Piast.Web.Tests.Pact
{
    [TestFixture]
    public class PactVerificationTests
    {
        [Test]
        public void Verify_Api_Pact()
        {
            var pactBuilder = new PactBuilder();
            pactBuilder
                .ServiceConsumer("Web")
                .HasPactWith("Api");
            var mockProviderService = pactBuilder.MockService(5000, host: IPAddress.Any);

            mockProviderService
                .Given("Valid advertisement Id")
                .UponReceiving("GET request to retrieve advertisement")
                .With(new ProviderServiceRequest
                {
                    Method = HttpVerb.Get,
                    Path = "/api/Advertisements/debdedbf-1524-4d83-8d74-7d05ffb02d6e",
                    Headers = new Dictionary<string, object>
                    {
                        {"Host", "localhost:5000"},
                        {"Version", "HTTP/1.1"}
                    }
                })
                .WillRespondWith(new ProviderServiceResponse
                {
                    Status = 200,
                    Headers = new Dictionary<string, object>
                    {
                        { "Content-Type", "application/json; charset=utf-8" }
                    },
                    Body = new{
                        id = "debdedbf-1524-4d83-8d74-7d05ffb02d6e",
                        title = "Title",
                        description = "Description",
                        price = 1.0,
                        publicationDate = "2019-01-10T00:00:00"
                    }
                });

                IAdvertisementService service = RestClient.For<IAdvertisementService>("http://localhost:5000/api/");

                var result = service.FindById(Guid.Parse("debdedbf-1524-4d83-8d74-7d05ffb02d6e")).GetAwaiter().GetResult();

                result.ShouldNotBeNull();
                result.Id.ShouldBe(Guid.Parse("debdedbf-1524-4d83-8d74-7d05ffb02d6e"));
                result.Title.ShouldBe("Title");
                result.Description.ShouldBe("Description");
                result.Price.ShouldBe(1);
                result.PublicationDate.ShouldBe(new DateTime(2019,1,10));

                mockProviderService.VerifyInteractions();

                pactBuilder.Build();
        }
    }
}