using AutoMapper;
using MyStore.Data.Repositories;
using MyStore.Domain.Entities;
using MyStore.Domain.Extensions;
using MyStore.Domain.Models;
using System.Collections.Generic;
using System.Linq;


namespace MyStore.Data.Services
{
    public interface IReportsService
    {
        List<CustomerContact> GetContacts();
        List<Customer> GetCustomersWithNoOrders();
    }
    public class ReportsService : IReportsService
    {
        private readonly IReportsRepository reportsRepository;
        public ReportsService(IReportsRepository reportsRepository)
        {
            this.reportsRepository = reportsRepository;
        }
        public List<Customer> GetCustomersWithNoOrders()
        {
            return this.reportsRepository.GetCustomersWithNoOrders();
        }
        public List<CustomerContact> GetContacts()
        {
            var result = this.reportsRepository.GetContacts();
            return result;
        }
    }
}