using Moq;
using MyStore.Data.Repositories;
using MyStore.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace MyStore.Tests.CustomerTests
{
    public class CustomerRepositoryTests
    {
        public CustomerRepositoryTests()
        {

        }

        [Fact]
        public void Should_GetAllProducts()
        {
            //arrange
            var mockRepo = new Mock<ICustomerRepository>();
            mockRepo.Setup(repo => repo.GetAll())
                .Returns(ReturnMultiple);

            //act
            var result = mockRepo.Object.GetAll();

            //assert
            Assert.Equal(2, result.Count());
            Assert.IsType<List<Customer>>(result);
        }

        public List<Customer> ReturnMultiple()
        {
            return new List<Customer>()
            {
                new Customer{

                Custid = 1,
                Companyname = "test",
                Contactname = "Victor",
                Contacttitle = "Owner",
                Address = "France, Paris",
                City = "Paris",
                Region = "",
                Postalcode = "12345",
                Country = "France",
                Phone = "23.45.67.89",
                Fax = ""
                },

                new Customer
                {
                     Custid = 5,
                Companyname = "test",
                Contactname = "Victor",
                Contacttitle = "Owner",
                Address = "France, Paris",
                City = "Paris",
                Region = "",
                Postalcode = "120078",
                Country = "France",
                Phone = "12.23.34.45",
                Fax = ""
                }

            };
        }
    }
}
