using AutoMapper;
using NUnit.Framework;
using Piast.Api.Infrastructure.Converters.Profiles;

namespace Piast.Api.Infrastructure.Tests.Converters
{
    [SetUpFixture]
    public class AutomapperConfigurationTest
    {
        [OneTimeSetUp]
        public void SetUp ()
        {
            Mapper.Initialize (cfg =>
            {
                cfg.AddProfile (new AdvertisementMappingProfile ());
            });

            Mapper.AssertConfigurationIsValid ();
        }
    }
}