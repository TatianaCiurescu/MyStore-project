using AutoMapper;
using MyStore.Domain.Entities;
using MyStore.Domain.Models;

namespace MyStore.Services.Infrastructure
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<OrderModel, Order>();
            CreateMap<Order, OrderModel>();
        }
    }
}
