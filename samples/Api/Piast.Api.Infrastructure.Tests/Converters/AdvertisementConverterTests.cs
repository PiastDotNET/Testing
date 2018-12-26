using System;
using System.Linq;
using AutoMapper;
using Bogus;
using NUnit.Framework;
using Piast.Api.Domain.Entities;
using Piast.Api.Infrastructure.Converters;
using Piast.Api.Infrastructure.Converters.Interfaces;
using Piast.Api.Infrastructure.DTO;
using Shouldly;

namespace Piast.Api.Infrastructure.Tests.Converters
{
    [TestFixture]
    public class AdvertisementConverterTests
    {
        private IAdvertisementConverter _sut;
        private Faker<Advertisement> _advertisementEntityFaker;
        private Faker<AdvertisementDTO> _advertisementDTOFaker;

        [SetUp]
        public void SetUp()
        {
            _sut = new AdvertisementConverter(Mapper.Instance);
            _advertisementDTOFaker = new Faker<AdvertisementDTO>()
                .RuleFor(x=>x.Id, f => f.Random.Guid())
                .RuleFor(x=>x.Title, f => f.Random.Words(4))
                .RuleFor(x=>x.Description, f=>f.Random.Words(20))
                .RuleFor(x=>x.Price, f =>f.Random.Decimal())
                .RuleFor(x=>x.PublicationDate, f => f.Date.Past());

            _advertisementEntityFaker = new Faker<Advertisement>()
                .RuleFor(x=>x.Id, f => f.Random.Guid())
                .RuleFor(x=>x.Title, f => f.Random.Words(4))
                .RuleFor(x=>x.Description, f=>f.Random.Words(20))
                .RuleFor(x=>x.Price, f =>f.Random.Decimal())
                .RuleFor(x=>x.PublicationDate, f => f.Date.Past());
        }

        [Test]
        public void Convert_Entity_To_DTO_Should_Convert_Properly()
        {
            var input = _advertisementEntityFaker.Generate(1).FirstOrDefault();

            var result = _sut.Convert(input);

            result.Id.ShouldBe(input.Id);
            result.Title.ShouldBe(input.Title);
            result.Description.ShouldBe(input.Description);
            result.Price.ShouldBe(input.Price);
            result.PublicationDate.ShouldBe(input.PublicationDate);
        }

        [Test]
        public void Convert_DTO_To_Entity_Should_Convert_Properly()
        {
            var input = _advertisementDTOFaker.Generate(1).FirstOrDefault();

            var result = _sut.Convert(input);

            result.Id.ShouldBe(input.Id);
            result.Title.ShouldBe(input.Title);
            result.Description.ShouldBe(input.Description);
            result.Price.ShouldBe(input.Price);
            result.PublicationDate.ShouldBe(input.PublicationDate);
        }

        [Test]
        public void Convert_Entity_List_To_DTO_List_Should_Convert_Properly()
        {
            var input = _advertisementEntityFaker.Generate(2);

            var result = _sut.Convert(input);

            result.Count.ShouldBe(2);
            result[0].Id.ShouldBe(input[0].Id);
            result[0].Title.ShouldBe(input[0].Title);
            result[0].Description.ShouldBe(input[0].Description);
            result[0].Price.ShouldBe(input[0].Price);
            result[0].PublicationDate.ShouldBe(input[0].PublicationDate);
            result[1].Id.ShouldBe(input[1].Id);
            result[1].Title.ShouldBe(input[1].Title);
            result[1].Description.ShouldBe(input[1].Description);
            result[1].Price.ShouldBe(input[1].Price);
            result[1].PublicationDate.ShouldBe(input[1].PublicationDate);
        }

        [Test]
        public void Convert_DTO_List_To_Entity_List_Should_Convert_Properly()
        {
            var input = _advertisementDTOFaker.Generate(2);

            var result = _sut.Convert(input);

            result.Count.ShouldBe(2);
            result[0].Id.ShouldBe(input[0].Id);
            result[0].Title.ShouldBe(input[0].Title);
            result[0].Description.ShouldBe(input[0].Description);
            result[0].Price.ShouldBe(input[0].Price);
            result[0].PublicationDate.ShouldBe(input[0].PublicationDate);
            result[1].Id.ShouldBe(input[1].Id);
            result[1].Title.ShouldBe(input[1].Title);
            result[1].Description.ShouldBe(input[1].Description);
            result[1].Price.ShouldBe(input[1].Price);
            result[1].PublicationDate.ShouldBe(input[1].PublicationDate);
        }
    }
}