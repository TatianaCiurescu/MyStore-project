using AutoMapper;
using MyStore.Domain.Entities;
using MyStore.Domain.Models;

namespace MyStore.Services.Infrastructure
{
    public class SupplierProfile: Profile
    {
        public SupplierProfile()
        {
            CreateMap<Supplier, SupplierModel>();
            CreateMap<SupplierModel, Supplier>();
        }
    }
}
