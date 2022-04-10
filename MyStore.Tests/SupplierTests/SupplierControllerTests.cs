using Microsoft.AspNetCore.Mvc;
using Moq;
using MyStore.Data.Services;
using MyStore.Domain.Models;
using MyStore.Services.Controllers;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace MyStore.Tests.SupplierTests
{
    public class SupplierControllerTests
    {
        private readonly Mock<ISupplierService> mockSupplierService;

        public SupplierControllerTests()
        {
            mockSupplierService = new Mock<ISupplierService>();
        }

        [Fact]

        public void Should_Return_OK_OnGetAll()
        {
            //arrange
            mockSupplierService.Setup(x => x.GetAllSuppliers())
                .Returns(MultipleSuppliers);
            var controller = new SuppliersController(mockSupplierService.Object);

            //act
            var response = controller.Get();

            var result = response.Result as OkObjectResult;
            var actualData = result.Value as IEnumerable<SupplierModel>;

            //assert
            Assert.IsType<OkObjectResult>(result);
            Assert.IsType<List<SupplierModel>>(actualData);
        }

        [Fact]
        public void Should_Return_AllProducts()
        {
            //arrange
            mockSupplierService.Setup(x => x.GetAllSuppliers())
                .Returns(MultipleSuppliers);
            var controller = new SuppliersController(mockSupplierService.Object);

            //act
            var response = controller.Get();

            var result = response.Result as OkObjectResult;
            var actualData = result.Value as IEnumerable<SupplierModel>;

            //assert
            Assert.Equal(MultipleSuppliers().Count, actualData.Count());
        }

        private List<SupplierModel> MultipleSuppliers()
        {
            return new List<SupplierModel>()
            {
                new SupplierModel
                {
                    Supplierid = 10,
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

                new SupplierModel
                {
                    Supplierid = 11,
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

                new SupplierModel
                {
                    Supplierid = 12,
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
