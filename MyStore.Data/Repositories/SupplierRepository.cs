using MyStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyStore.Data.Repositories
{
    public interface ISupplierRepository
    {
        Supplier Add(Supplier newSupplier);
        bool Delete(Supplier supplierToDelete);
        bool Exists(int id);

        ///data access code
        ///CRUD
        IEnumerable<Supplier> GetAll();
        Supplier GetById(int id);
        void Update(Supplier supplierToUpdate);
    }
    public class SupplierRepository : ISupplierRepository
    {
        private readonly StoreContext context;

        public SupplierRepository(StoreContext context)
        {
            this.context = context;
        }
        public IEnumerable<Supplier> GetAll()
        {
            return context.Suppliers.ToList();
        }
        public Supplier GetById(int id)
        {
            return context.Suppliers.FirstOrDefault(x => x.Supplierid == id);
        }

        public Supplier Add(Supplier newSupplier)
        {
            var addedSupplier = context.Suppliers.Add(newSupplier);
            context.SaveChanges();

            return addedSupplier.Entity;
        }

        public void Update(Supplier supplierToUpdate)
        {
            context.Suppliers.Update(supplierToUpdate);
            context.SaveChanges();
        }

        public bool Exists(int id)
        {
            var exists = context.Suppliers.Count(x => x.Supplierid == id);
            return exists == 1;
        }

        public bool Delete(Supplier supplierToDelete)
        {
            var deletedItem = context.Suppliers.Remove(supplierToDelete);
            context.SaveChanges();

            return deletedItem != null;
        }


    }
}
