using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using Piast.Api.Domain.Entities;
using Piast.Api.Domain.Repositories.Interfaces;
using Piast.Api.Infrastructure.Converters.Interfaces;
using Piast.Api.Infrastructure.DTO;
using Piast.Api.Infrastructure.Services;
using Piast.Api.Infrastructure.Services.Interfaces;
using Shouldly;

namespace Piast.Api.Infrastructure.Tests.Services
{
    [TestFixture]
    public class AdvertisementServiceTests
    {
        private IAdvertisementService _sut;
        private Mock<IRepository<Advertisement>> _repositoryMock;
        private Mock<IAdvertisementConverter> _converterMock;
        [SetUp]
        public void SetUp()
        {
            _repositoryMock = new Mock<IRepository<Advertisement>>();
            _converterMock = new Mock<IAdvertisementConverter>();

            _sut = new AdvertisementService(_converterMock.Object,_repositoryMock.Object);
        }

        [Test]
        public async Task FindPageAsync_When_There_Is_Next_Page_Should_Create_Model_With_Next_Page()
        {
            int page = 1;
            int pageCount = 5;
            IList<Advertisement> list = new List<Advertisement>()
            {
                new Advertisement(),
                new Advertisement(),
                new Advertisement(),
                new Advertisement(),
                new Advertisement(),
                new Advertisement(),
            };

            var listToConvert = list.Take(5).ToList();

            _repositoryMock
                .Setup(x=>
                x.FindManyAsync(y => true,page, pageCount))
                .Returns(Task.FromResult(list));

            _converterMock.Setup(x=>x.Convert(listToConvert)).Returns(new List<AdvertisementDTO>());

            var result = await _sut.FindPageAsync(page,pageCount);

            result.ShouldNotBeNull();
            result.Items.ShouldNotBeNull();
            result.NextPageAvailable.ShouldBeTrue();

            _converterMock.Verify(x=>x.Convert(listToConvert),Times.Once);
            _repositoryMock.Verify(x=>x.FindManyAsync(y => true,page, pageCount),Times.Once);
        }

        [Test]
        public async Task FindPageAsync_When_There_Is_No_Next_Page_Should_Create_Model_With_No_Next_Page()
        {
            int page = 1;
            int pageCount = 5;
            IList<Advertisement> list = new List<Advertisement>()
            {
                new Advertisement(),
                new Advertisement(),
                new Advertisement(),
                new Advertisement(),
                new Advertisement(),
            };

            _repositoryMock
                .Setup(x=>
                x.FindManyAsync(y => true,page, pageCount))
                .Returns(Task.FromResult(list));

            _converterMock.Setup(x=>x.Convert(list)).Returns(new List<AdvertisementDTO>());

            var result = await _sut.FindPageAsync(page,pageCount);

            result.ShouldNotBeNull();
            result.Items.ShouldNotBeNull();
            result.NextPageAvailable.ShouldBeFalse();

            _converterMock.Verify(x=>x.Convert(list),Times.Once);
            _repositoryMock.Verify(x=>x.FindManyAsync(y => true,page, pageCount),Times.Once);
        }

        [Test]
        public async Task Add_Should_Call_Add_For_Mapped_DTO()
        {
            var entity = new Advertisement();
            var dto = new AdvertisementDTO();

            _converterMock.Setup(x=>x.Convert(dto)).Returns(entity);

            await _sut.AddAsync(dto);

            _repositoryMock.Verify(x=>x.AddAsync(entity),Times.Once);
        }
    }
}