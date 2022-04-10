using AutoMapper;
using MyStore.Domain.Entities;
using MyStore.Models;

namespace MyStore.Infrastructure.Attributes
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
