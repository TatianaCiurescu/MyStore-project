using AutoMapper;
using MyStore.Data;
using MyStore.Domain.Entities;
using MyStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyStore.Services
{
    public interface ICustomerService
    {
        Customer AddCustomer(Customer newCustomer);
        bool Delete(int id);
        bool Exists(int id);
        IEnumerable<CustomerModel> GetAllCustomers();
        Customer GetById(int id);
        void UpdateCustomer(CustomerModel model);
    }
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository customerRepository;
        private readonly IMapper mapper;

        public CustomerService(ICustomerRepository customerRepository, IMapper mapper)
        {
            this.customerRepository = customerRepository;
            this.mapper = mapper;
        }

        public IEnumerable<CustomerModel> GetAllCustomers()
        {
            var allCustomers = customerRepository.GetAll().ToList();
            var customerModels = mapper.Map<IEnumerable<CustomerModel>>(allCustomers);
            return customerModels;
        }

        public Customer GetById(int id)
        {
            return customerRepository.GetById(id);
        }

        public Customer AddCustomer(Customer newCustomer)
        {
            Customer customerToAdd = mapper.Map<Customer>(newCustomer);
            var addedCustomer = customerRepository.Add(customerToAdd);
            return customerRepository.Add(newCustomer);
        }


        public bool Exists(int id)
        {
            return customerRepository.Exists(id);
        }

        public void UpdateCustomer(CustomerModel model)
        {
            Customer customerToUpdate = mapper.Map<Customer>(model);
            customerRepository.Update(customerToUpdate);
        }

        public bool Delete(int id)
        {
            var custToDelete = customerRepository.GetById(id);
            return customerRepository.Delete(custToDelete);
        }

    }
}
