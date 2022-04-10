using MyStore.Domain.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Xunit;

namespace MyStore.Tests
{
    public class ProductModelTests
    {
        public const string ProductNameRequiredMessage = "The Productname field is required.";
        public const int ValidCategoryId = 2;

        [Fact]
        public void FailingTest()
        {
            Assert.Equal(2, 2);
        }

        [Fact]
        public void Should_Pass()
        {
            //arrange
            var sut = new ProductModel()
            {
                Categoryid = ValidCategoryId,
                Productid = 2,
                Supplierid = 2,
                Unitprice = 10,
                Discontinued = true,
                Productname = "Test productName"
            };

            //act

            var validationResults = new List<ValidationResult>();
            var actual = Validator.TryValidateObject(sut, new ValidationContext(sut),validationResults, true);

            //assert
            Assert.True(actual, "Expected to succeed");
        }

        [Fact]
        public void Should_Fail_When_ProductName_IsEmpty()
        {
            //arrange
            var sut = new ProductModel()
            {
                Categoryid = ValidCategoryId,
                Productid = Consts.TestProduct,
                Supplierid = Consts.TestSupplierId,
                Unitprice = Consts.TestUnitPrice,
                Discontinued = true,
                Productname = ""
            };

            //act

            var validationResults = new List<ValidationResult>();
            var actual = Validator.TryValidateObject(sut, new ValidationContext(sut), validationResults, true);

            var message = validationResults[0];
           // var message1 = validationResults[1];

            //assert

            Assert.Equal(ProductNameRequiredMessage, message.ErrorMessage);
           // Assert.Equal("The Unitprice field is required.", message1.ErrorMessage);

        }
    }
}
