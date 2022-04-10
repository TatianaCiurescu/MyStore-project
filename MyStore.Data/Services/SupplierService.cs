using AutoMapper;
using MyStore.Data.Repositories;
using MyStore.Domain.Entities;
using MyStore.Domain.Models;
using System.Collections.Generic;
using System.Linq;

namespace MyStore.Data.Services
{
    public interface ISupplierService
    {
        Supplier AddSupplier(SupplierModel newSupplier);
        bool Delete(int id);
        bool Exists(int id);
        IEnumerable<SupplierModel> GetAllSuppliers();
        Supplier GetById(int id);
        void Update(SupplierModel model);
    }
    public class SupplierService : ISupplierService
    {
        private readonly ISupplierRepository supplierRepository;
        private readonly IMapper mapper;

        public SupplierService(ISupplierRepository supplierRepository, IMapper mapper)
        {
            this.supplierRepository = supplierRepository;
            this.mapper = mapper;
        }
        public IEnumerable<SupplierModel> GetAllSuppliers()
        {
            var allSuppliers = supplierRepository.GetAll().ToList();
            var supplierModels = mapper.Map<IEnumerable<SupplierModel>>(allSuppliers);

            return supplierModels;
        }
        public Supplier GetById(int id)
        {
            return supplierRepository.GetById(id);
        }

        public Supplier AddSupplier(SupplierModel newSupplier)
        {
            Supplier supplierToAdd = mapper.Map<Supplier>(newSupplier);
            var addedSupplier = supplierRepository.Add(supplierToAdd);

            return addedSupplier;
        }

        public bool Exists(int id)
        {
            return supplierRepository.Exists(id);
        }

        public void Update(SupplierModel model)
        {
            Supplier supplierToUpdate = mapper.Map<Supplier>(model);
            supplierRepository.Update(supplierToUpdate);
        }

        public bool Delete(int id)
        {
            var itemToDelete = supplierRepository.GetById(id);
            var deletedItem = supplierRepository.Delete(itemToDelete);

            return deletedItem;
        }
    }
}
