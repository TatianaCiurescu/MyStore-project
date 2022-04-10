
using AutoMapper;
using MyStore.Domain.Entities;
using MyStore.Models;

namespace MyStore.Domain.Infrastructure
{
    public class ProductProfile: Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductModel>();
            CreateMap<ProductModel, Product>();
        }
    }
}
