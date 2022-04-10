using AutoMapper;
using MyStore.Domain.Entities;
using MyStore.Models;

namespace MyStore.Infrastructure
{
    public class OrderDetailsProfile : Profile
    {
        public OrderDetailsProfile()
        {
            CreateMap<OrderDetailModel, OrderDetail>();
            CreateMap<OrderDetail, OrderDetailModel>();
        }
    }
}
