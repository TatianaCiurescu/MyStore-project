using AutoMapper;
using MyStore.Domain.Entities;
using MyStore.Models;

namespace MyStore.Infrastructure
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
