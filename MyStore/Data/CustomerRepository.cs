using MyStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyStore.Data
{
    public interface ICustomerRepository
    {
        Customer Add(Customer newCustomer);
        bool Exists(int id);
        bool Delete(Customer customerToDelete);
        ///data access code
        ///CRUD
        IEnumerable<Customer> GetAll();
        Customer GetById(int id);
        void Update(Customer customerToUpdate);

    }
    public class CustomerRepository : ICustomerRepository
    {
        private readonly StoreContext context;

        public CustomerRepository(StoreContext context)
        {
            this.context = context;
        }
        public IEnumerable<Customer> GetAll()
        {
            return context.Customers.ToList();
        }

        public Customer GetById(int id)
        {
            return context.Customers.FirstOrDefault(x => x.Custid == id);
        }

        public Customer Add(Customer newCustomer)
        {
            var addedCustomer= context.Customers.Add(newCustomer);
            context.SaveChanges();

            return addedCustomer.Entity;

        }

        public bool Exists(int id)
        {
            var exists = context.Customers.Count(x=>x.Custid==id);
            return exists==1;
        }

        public void Update(Customer customerToUpdate)
        {
            context.Customers.Update(customerToUpdate);
            context.SaveChanges();
        }

        public bool Delete(Customer customerToDelete)
        {
            var deletedCust= context.Customers.Remove(customerToDelete);
            context.SaveChanges();
            return deletedCust != null;
        }
    }
}
