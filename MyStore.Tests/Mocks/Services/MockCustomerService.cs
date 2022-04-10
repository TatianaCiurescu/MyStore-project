using Moq;
using MyStore.Data.Services;
using MyStore.Domain.Entities;
using MyStore.Domain.Models;
using System.Collections.Generic;

namespace MyStore.Tests.Mocks.Services
{
    class MockCustomerService: Mock<ICustomerService>
    {
        public MockCustomerService MockGetAllCustomers(List<CustomerModel> results)
        {
            Setup(x => x.GetAllCustomers()).Returns(results);
            return this;
        }

        public MockCustomerService MockGetByID(Customer customer)
        {
            Setup(x => x.GetById(It.IsAny<int>())).Returns(customer);
            return this;
        }
    }
}
