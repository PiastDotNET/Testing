using FluentValidation;
using NUnit.Framework;
using Piast.Web.Core.Models;
using Piast.Web.Core.Validators;
using Shouldly;

namespace Piast.Web.Core.Tests.Validators
{
    [TestFixture]
    public class AdvertisementValidatorTests
    {
        private IValidator<AdvertisementModel> _sut;

        [SetUp]
        public void SetUp()
        {
            _sut = new AdvertisementValidator();
        }

        [Test]
        public void Validator_Validates_Nulls()
        {
            var model = new AdvertisementModel()
            {
                Title = null,
                Description = null,
                Price = 0
            };

            var result = _sut.Validate(model);

            result.Errors.Count.ShouldBe(4);
            result.Errors[0].ErrorMessage.ShouldBe("This field cannot be empty");
            result.Errors[1].ErrorMessage.ShouldBe("This field cannot be empty");
            result.Errors[2].ErrorMessage.ShouldBe("This field cannot be empty");
            result.Errors[3].ErrorMessage.ShouldBe("This field cannot be empty");
        }

        [Test]
        public void Validator_Validates_Empty_Strings()
        {
            var model = new AdvertisementModel()
            {
                Title = "",
                Description = "",
                Price = -1
            };

            var result = _sut.Validate(model);

            result.Errors.Count.ShouldBe(3);
            result.Errors[0].ErrorMessage.ShouldBe("This field cannot be empty");
            result.Errors[1].ErrorMessage.ShouldBe("This field cannot be empty");
            result.Errors[2].ErrorMessage.ShouldBe("This field cannot be on minus");
        }
    }
}