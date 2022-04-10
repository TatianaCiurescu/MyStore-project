using Moq;
using MyStore.Data.Repositories;
using MyStore.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace MyStore.Tests.SupplierTests
{
    public class SupplierRepositoryTests
    {
        public SupplierRepositoryTests()
        {

        }

        [Fact]
        public void Should_GetAllSuppliers()
        {
            //arrange
            var mockRepo = new Mock<ISupplierRepository>();
            mockRepo.Setup(repo => repo.GetAll())
                .Returns(ReturnsMultiple());

            //act
            var result = mockRepo.Object.GetAll();

            //assert
            Assert.Equal(2, result.Count());
            Assert.IsType<List<Supplier>>(result);
        }
        
        public List<Supplier> ReturnsMultiple()
        {
            return new List<Supplier>
            {
                new Supplier
                {
                    Supplierid = 1,
                    Companyname = "Alpha",
                    Contactname = "Adrian",
                    Contacttitle ="Owner",
                    Address = "Bucharest 15",
                    City = "Bucharest",
                    Region ="",
                    Postalcode ="041974",
                    Country ="Romania",
                    Phone = "0777452413",
                    Fax = ""
                },

                 new Supplier
                {
                    Supplierid = 2,
                    Companyname = "Alpha",
                    Contactname = "Bogdan",
                    Contacttitle ="Owner",
                    Address = "Bucharest 15",
                    City = "Bucharest",
                    Region ="",
                    Postalcode ="041974",
                    Country ="Romania",
                    Phone = "0222452413",
                    Fax = ""
                }
            };
        }
        
    }
}
