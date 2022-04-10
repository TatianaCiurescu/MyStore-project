using AutoMapper;
using MyStore.Domain.Entities;
using MyStore.Domain.Models;

namespace MyStore.Services.Infrastructure
{
    public class CustomerProfile: Profile
    {
        public CustomerProfile()
        {
            CreateMap<Customer, CustomerModel>();
            CreateMap<CustomerModel, Customer>();
        }
    }
}
