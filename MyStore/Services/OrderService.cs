using AutoMapper;
using MyStore.Domain.Entities;
using MyStore.Models;
using System.Collections.Generic;
using System.Linq;
using static MyStore.Data.OrderRepository;

namespace MyStore.Services
{
    public interface IOrderService
    {
        Order Add(Order newOrder);
        bool Delete(int id);
        bool Exists(int id);
        IEnumerable<OrderModel> GetAll(List<string> countries, List<string> cities);
        Order GetById(int id);
        void UpdateOrder(OrderModel model);
    }

    public class OrderService : IOrderService
    {
        private readonly IOrderRepository repository;
        private readonly IMapper mapper;

        public OrderService(IOrderRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public IEnumerable<OrderModel> GetAll(List<string> countries, List<string> cities)
        {
            
            var allOrders = repository.GetAll(countries, cities).ToList();

            var orderModels = mapper.Map<IEnumerable<OrderModel>>(allOrders);

            return orderModels; 
        }

        public Order GetById(int id)
        {
            return repository.GetById(id);
        }

        public Order Add(Order newOrder)
        {
            var addedOrder = repository.Add(newOrder);
            return addedOrder;
        }

        public void UpdateOrder(OrderModel model)
        {
            var orderToUpdate = mapper.Map<Order>(model);
            repository.Update(orderToUpdate);
        }

        public bool Exists(int id)
        {
            return repository.Exists(id);
        }
        
        public bool Delete(int id)
        {
            var orderToDelete = repository.GetById(id);

            var deletedOrder = repository.Delete(orderToDelete);
            return deletedOrder;
        }
    }
}
