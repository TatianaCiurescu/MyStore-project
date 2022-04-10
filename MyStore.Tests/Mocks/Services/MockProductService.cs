using Moq;
using MyStore.Data.Services;
using MyStore.Domain.Entities;
using MyStore.Domain.Models;
using System.Collections.Generic;

namespace MyStore.Tests.Mocks.Services
{
    public class MockProductService: Mock<IProductService>
    {
        public MockProductService MockGetAllProducts(List<ProductModel> results)
        {
            Setup(x => x.GetAllProducts())
                .Returns(results);

            return this;
        }

        public MockProductService MockGetById(Product product)
        {
            Setup(x => x.GetById(It.IsAny<int>()))
                .Returns(product);
              //  .Throws(new Exception("Product with ID not found"));

            return this;
        }

        public MockProductService MockAddProduct(Product newProduct)
        {
            Setup(x => x.AddProduct(It.IsAny<ProductModel>())).Returns(newProduct);
            return this;
        }

        public MockProductService MockUpdateProduct()
        {
            Setup(x => x.UpdateProduct(It.IsAny<ProductModel>())).Verifiable();
            return this;
        }

        public MockProductService MockExistsProduct()
        {
            Setup(x => x.Exists(It.IsAny<int>())).Returns(true);
            return this;
        }
        public MockProductService MockDeleteProduct()
        {
            Setup(x => x.Delete(It.IsAny<int>())).Returns(true);
            return this;
        }
    }
}
