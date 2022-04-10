using Microsoft.AspNetCore.Mvc;
using Moq;
using MyStore.Data.Services;
using MyStore.Domain.Entities;
using MyStore.Domain.Models;
using MyStore.Services.Controllers;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace MyStore.Tests
{
    public class ProductControllerTests
    {
        private readonly Mock<IProductService> mockProductService;

        public ProductControllerTests()
        {
            mockProductService = new Mock<IProductService>();
        }

        [Fact]
        public void Should_Return_OK_OnGetAll()
        {
            //arrange
            mockProductService.Setup(x => x.GetAllProducts())
                .Returns(MultipleProducts);

            var controller = new ProductsController(mockProductService.Object);

            //act
            var response = controller.Get();

            var result = response.Result as OkObjectResult;
            var actualData = result.Value as IEnumerable<ProductModel>;

            //assert
            Assert.IsType<OkObjectResult>(result);
            Assert.IsType<List<ProductModel>>(actualData);
        }

        [Fact]
        public void ShouldReturn_AllProducts()
        {
            //arrange
            mockProductService.Setup(x => x.GetAllProducts())
                .Returns(MultipleProducts());

            var controller = new ProductsController(mockProductService.Object);

            //act
            var response = controller.Get();

            var result = response.Result as OkObjectResult;
            var actualData = result.Value as IEnumerable<ProductModel>;


            //assert
            Assert.Equal(MultipleProducts().Count(), actualData.Count());
        }

        [Fact]
        public void Should_Return_OK_GetById()
        {
            //arrange
            mockProductService.Setup(x => x.GetById(1))
                .Returns(new Domain.Entities.Product 
                {
                    Categoryid = (int)Consts.Categories.Condiments,
                    Productid = Consts.TestProduct,
                    Productname = Consts.ProductName, 
                    Discontinued = false,
                    Supplierid = Consts.TestSupplierId,
                    Unitprice = Consts.TestUnitPrice
                });

            var controller = new ProductsController(mockProductService.Object);

            //act
            var response = controller.GetProduct(1);

            var result = response.Result as OkObjectResult;
            var actualData = result.Value as Product;

            //assert
            Assert.IsType<OkObjectResult>(result);
            Assert.IsType<Product>(actualData);
        }

        [Fact]
        public void Should_Return_AddedProduct()
        {
            //arrange
            mockProductService.Setup(x => x.AddProduct(It.IsAny<ProductModel>()
            )).Returns(new Product());

            var controller = new ProductsController(mockProductService.Object);

            //act
            var response = controller.Post(new ProductModel
            {
                Categoryid = (int)Consts.Categories.Condiments,
                Productid = Consts.TestProduct,
                Productname = Consts.ProductName,
                Discontinued = false,
                Supplierid = Consts.TestSupplierId,
                Unitprice = Consts.TestUnitPrice
            }
                );
            var result = response.Result as OkObjectResult;
            var actualData = result.Value as Product;

            //assert
            Assert.IsType<OkObjectResult>(result);
            Assert.IsType<Product>(actualData);
        }

        [Fact]
        public void Should_Return_UpdateProduct_BadRequest()
        {
            
            var controller = new ProductsController(mockProductService.Object);

            //act
            var response = controller.Put(99, new ProductModel
            {
                Categoryid = (int)Consts.Categories.Condiments,
                Productid = Consts.TestProduct,
                Productname = Consts.ProductName,
                Discontinued = false,
                Supplierid = Consts.TestSupplierId,
                Unitprice = Consts.TestUnitPrice
            }
                );
            var result = response as BadRequestResult;

            //assert
            Assert.IsType<BadRequestResult>(result);
        }

        [Fact]
        public void Should_Return_UpdateProduct_NotFound()
        {
            //arrange
            mockProductService.Setup(x => x.Exists(It.IsAny<int>()
            )).Returns(false);

            var controller = new ProductsController(mockProductService.Object);

            //act
            var response = controller.Put(Consts.TestProduct, new ProductModel
            {
                Categoryid = (int)Consts.Categories.Condiments,
                Productid = Consts.TestProduct,
                Productname = Consts.ProductName,
                Discontinued = false,
                Supplierid = Consts.TestSupplierId,
                Unitprice = Consts.TestUnitPrice
            }
                );
            var result = response as NotFoundResult;

            //assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public void Should_Return_UpdateProduct()
        {
            //arrange
            //arrange
            mockProductService.Setup(x => x.Exists(It.IsAny<int>()
            )).Returns(true);
            mockProductService.Setup(x => x.UpdateProduct(It.IsAny<ProductModel>()
            )).Verifiable();

            var controller = new ProductsController(mockProductService.Object);

            //act
            var response = controller.Put(Consts.TestProduct, new ProductModel
            {
                Categoryid = (int)Consts.Categories.Condiments,
                Productid = Consts.TestProduct,
                Productname = Consts.ProductName,
                Discontinued = false,
                Supplierid = Consts.TestSupplierId,
                Unitprice = Consts.TestUnitPrice
            }
                );
            var result = response as OkResult;

            //assert
            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public void Should_Return_DeleteProduct_NotFound()
        {
            //arrange
            mockProductService.Setup(x => x.Exists(It.IsAny<int>()
            )).Returns(false);

            var controller = new ProductsController(mockProductService.Object);

            //act
            var response = controller.Delete(Consts.TestProduct);
            var result = response as NotFoundResult;

            //assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public void Should_Return_DeleteProduct_Ok()
        {
            //arrange
            mockProductService.Setup(x => x.Exists(It.IsAny<int>()
            )).Returns(true);
            mockProductService.Setup(x => x.Delete(It.IsAny<int>()
            )).Returns(true);

            var controller = new ProductsController(mockProductService.Object);

            //act
            var response = controller.Delete(Consts.TestProduct);
            var result = response as OkResult;

            //assert
            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public void Should_Return_DeleteProduct_BadRequest()
        {
            //arrange
            mockProductService.Setup(x => x.Exists(It.IsAny<int>()
            )).Returns(true);
            mockProductService.Setup(x => x.Delete(It.IsAny<int>()
            )).Returns(false);

            var controller = new ProductsController(mockProductService.Object);

            //act
            var response = controller.Delete(Consts.TestProduct);
            var result = response as BadRequestResult;

            //assert
            Assert.IsType<BadRequestResult>(result);
        }

        private List<ProductModel> MultipleProducts()
        {
            return new List<ProductModel>()
            {
                new ProductModel
            {
                    Categoryid = (int) Consts.Categories.Condiments,
                    Productid = Consts.TestProduct,
                    Productname = Consts.ProductName, //hardcoded
                    Discontinued = false,
                    Supplierid=Consts.TestSupplierId,
                    Unitprice= Consts.TestUnitPrice
            },
                new ProductModel
            {
                    Categoryid = (int) Consts.Categories.Condiments,
                    Productid =Consts.TestProduct,
                    Productname = Consts.ProductName,
                    Discontinued = false,
                    Supplierid=Consts.TestSupplierId,
                    Unitprice= Consts.TestUnitPrice
            },
                new ProductModel
            {
                    Categoryid = (int) Consts.Categories.Condiments,
                    Productid =Consts.TestProduct,
                    Productname = Consts.ProductName,
                    Discontinued = false,
                    Supplierid=Consts.TestSupplierId,
                    Unitprice= Consts.TestUnitPrice
            }
            };
        }
    }
}
