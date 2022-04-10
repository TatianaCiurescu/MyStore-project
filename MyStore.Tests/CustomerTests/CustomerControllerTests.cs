using Microsoft.AspNetCore.Mvc;
using Moq;
using MyStore.Data.Services;
using MyStore.Domain.Models;
using MyStore.Services.Controllers;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace MyStore.Tests.CustomerTests
{
    public class CustomerControllerTests
    {
        private readonly Mock<ICustomerService> mockCustomerService;

        public CustomerControllerTests()
        {
            mockCustomerService = new Mock<ICustomerService>();
        }

        [Fact]
        public void Should_Return_Ok_GetAllCustomers()
        {
            //arrange
            mockCustomerService.Setup(x => x.GetAllCustomers()).Returns(MultipleCustomers);
            var controller = new CustomersController(mockCustomerService.Object);

            //act
            var response = controller.Get();
            var result = response.Result as OkObjectResult;
            var finalData = result.Value as IEnumerable<CustomerModel>;

            //assert
            Assert.IsType<OkObjectResult>(result);
            Assert.IsType<List<CustomerModel>>(finalData);
        }

        [Fact]
        public void ShouldReturn_AllCustomers()
        {
            //arrange
            mockCustomerService.Setup(x => x.GetAllCustomers()).Returns(MultipleCustomers);
            var controller = new CustomersController(mockCustomerService.Object);

            //act
            var response = controller.Get();
            var result = response.Result as OkObjectResult;
            var finalData = result.Value as IEnumerable<CustomerModel>;

            //assert
            Assert.Equal(MultipleCustomers().Count(), finalData.Count());
        }
        private List<CustomerModel> MultipleCustomers()
        {
            return new List<CustomerModel>()
            {
                new CustomerModel
                {
                    Custid = 4,
                Companyname = Consts.CompanyName,
                Contactname = Consts.ContactName,
                Contacttitle = Consts.ContactTitle,
                Address = Consts.Address,
                City = Consts.City,
                Region = Consts.Region,
                Postalcode = Consts.PostalCode,
                Country = Consts.Country,
                Phone = Consts.Phone,
                Fax = Consts.Fax
                },
                new CustomerModel
                {
                    Custid = 5,
                Companyname = Consts.CompanyName,
                Contactname = Consts.ContactName,
                Contacttitle = Consts.ContactTitle,
                Address = Consts.Address,
                City = Consts.City,
                Region = Consts.Region,
                Postalcode = Consts.PostalCode,
                Country = Consts.Country,
                Phone = Consts.Phone,
                Fax = Consts.Fax
                },
                new CustomerModel
                {
                    Custid = 6,
                Companyname = Consts.CompanyName,
                Contactname = Consts.ContactName,
                Contacttitle = Consts.ContactTitle,
                Address = Consts.Address,
                City = Consts.City,
                Region = Consts.Region,
                Postalcode = Consts.PostalCode,
                Country = Consts.Country,
                Phone = Consts.Phone,
                Fax = Consts.Fax
                }
            };
        }
    }
}
