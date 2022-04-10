
using AutoMapper;
using MyStore.Domain.Entities;
using MyStore.Domain.Models;

namespace MyStore.Services.Infrastructure
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
