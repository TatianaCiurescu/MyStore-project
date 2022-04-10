using Moq;
using MyStore.Data.Services;
using MyStore.Domain.Entities;
using MyStore.Domain.Models;
using System.Collections.Generic;

namespace MyStore.Tests.Mocks.Services
{
    public class MockSupplierService: Mock<ISupplierService>
    {
        public MockSupplierService MockGetAllSuppliers(List<SupplierModel> results)
        {
            Setup(x => x.GetAllSuppliers()).Returns(results);
            return this;
        }

        public MockSupplierService MockGetById(Supplier supplier)
        {
            Setup(x => x.GetById(It.IsAny<int>())).Returns(supplier);
            return this;
        }
    }
}
