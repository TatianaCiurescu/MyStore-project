using MyStore.Domain.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Xunit;

namespace MyStore.Tests.SupplierTests
{
    public class SupplierModelTests
    {
        public const string CompanyNameErrorMessage = "The Companyname field is required.";
        public const string ContactNameErrorMessage = "The Contactname field is required.";

        [Fact]
        public void Should_Pass()
        {
            //arrange
            var sut = new SupplierModel()
            {
                Supplierid = 10,
                Companyname = "Alpha",
                Contactname = "Adrian",
                Contacttitle = "Owner",
                Address = "Bucharest 15",
                City = "Bucharest",
                Region = "",
                Postalcode = "041974",
                Country = "Romania",
                Phone = "0777452413",
                Fax = ""
            };

            //act
            var validationResults = new List<ValidationResult>();
            var actual = Validator.TryValidateObject(sut, new ValidationContext(sut), validationResults, true);

            //assert
            Assert.True(actual, "Expected to succeed");
        }

        [Fact]

        public void Should_Fail_CompanyName_IsEmpty()
        {
            //arrange
            var sut = new SupplierModel()
            {
                Supplierid = 10,
                Companyname = "",
                Contactname = "Adrian",
                Contacttitle = "Owner",
                Address = "Bucharest 15",
                City = "Bucharest",
                Region = "",
                Postalcode = "041974",
                Country = "Romania",
                Phone = "0777452413",
                Fax = ""
            };

            //act
            var validationResults = new List<ValidationResult>();
            var actual = Validator.TryValidateObject(sut, new ValidationContext(sut), validationResults, true);

            var message = validationResults[0];

            //assert

            Assert.Equal(CompanyNameErrorMessage, message.ErrorMessage);

        }

        [Fact]
        public void Should_Fail_ContactName_IsEmpty()
        {
            //arrange
            var sut = new SupplierModel()
            {
                Supplierid = 10,
                Companyname = "Coca-Cola",
                Contactname = "",
                Contacttitle = "Owner",
                Address = "Bucharest 15",
                City = "Bucharest",
                Region = "",
                Postalcode = "041974",
                Country = "Romania",
                Phone = "0777452413",
                Fax = ""
            };

            //act
            var validationResults = new List<ValidationResult>();
            var actual = Validator.TryValidateObject(sut, new ValidationContext(sut), validationResults, true);

            var message = validationResults[0];

            //assert

            Assert.Equal(ContactNameErrorMessage, message.ErrorMessage);

        }


    }
}
