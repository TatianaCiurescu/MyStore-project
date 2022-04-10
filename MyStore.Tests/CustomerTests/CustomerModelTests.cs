using MyStore.Domain.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Xunit;

namespace MyStore.Tests.CustomerTests
{
    public class CustomerModelTests
    {
        public const string ContactNameRequiredMessage = "The Contactname field is required.";
        public const string PhoneRequiredMessage = "The Phone field is required.";

        [Fact]
        public void Should_Pass()
        {
            //arrange
            var sut = new CustomerModel()
            {
                Custid = 4,
                Companyname = "Coca-Cola",
                Contactname = "Victor",
                Contacttitle = "Owner",
                Address = "France, Paris",
                City = "Paris",
                Region = "",
                Postalcode = "12345",
                Country = "France",
                Phone = "23.45.67.89",
                Fax = ""
            };

            //act
            var validationResults = new List<ValidationResult>();
            var actual = Validator.TryValidateObject(sut, new ValidationContext(sut), validationResults, true);

            //assert
            Assert.True(actual, "Expected to succeed");
        }

        [Fact]
        public void Should_Fail_ContactName_IsEmpty()
        {
            var sut = new CustomerModel()
            {
                Custid = 4,
                Companyname = "Coca-Cola",
                Contactname = "",
                Contacttitle = "Owner",
                Address = "France, Paris",
                City = "Paris",
                Region = "",
                Postalcode = "12345",
                Country = "France",
                Phone = "23.45.67.89",
                Fax = ""
            };

            //act
            var validationResults = new List<ValidationResult>();
            var actual = Validator.TryValidateObject(sut, new ValidationContext(sut), validationResults, true);

            var message = validationResults[0];
            //assert
            Assert.Equal(ContactNameRequiredMessage ,message.ErrorMessage);
        }

        [Fact]
        public void Should_Fail_Phone_IsEmpty()
        {
            var sut = new CustomerModel()
            {
                Custid = 4,
                Companyname = "Coca-Cola",
                Contactname = "Victor",
                Contacttitle = "Owner",
                Address = "France, Paris",
                City = "Paris",
                Region = "",
                Postalcode = "12345",
                Country = "France",
                Phone = "",
                Fax = ""
            };

            //act
            var validationResults = new List<ValidationResult>();
            var actual = Validator.TryValidateObject(sut, new ValidationContext(sut), validationResults, true);

            var message1 = validationResults[0];

            //assert
            Assert.Equal(PhoneRequiredMessage, message1.ErrorMessage);
        }
    }
}
