using AutoMapper;
using MyStore.Domain.Entities;
using MyStore.Domain.Models;

namespace MyStore.Services.Infrastructure
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
