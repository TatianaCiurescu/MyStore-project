using Microsoft.EntityFrameworkCore;
using MyStore.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace MyStore.Data.Repositories
{
    public interface IOrderRepository
    {
        Order Add(Order newOrder);
        bool Delete(Order orderToDelete);
        bool Exists(int id);
        IQueryable<Order> GetAll(List<string> shipCountry, List<string> shipCities);
        Order GetById(int id);
        void Update(Order orderToUpdate);
    }
    public class OrderRepository : IOrderRepository
    {
  
        private readonly StoreContext context;

        public OrderRepository(StoreContext context)
        {
            this.context = context;
        }

        //add filters
 
        public IQueryable<Order> GetAll(List<string> shipCountries, List<string> shipCities)
        {
            var query = this.context.Orders.Include(x => x.Cust).Include(x=>x.OrderDetails).Select(x => x);

            if (shipCountries.Any())
            {
                query = query.Where(x => shipCountries.Contains(x.Shipcountry));
            }

            if (shipCities.Any())
            {
                query = query.Where(x=>shipCities.Contains(x.Shipcity));
            }

            return query;
        }

        public Order GetById(int id)
        {
            return context.Orders.FirstOrDefault(x => x.Orderid == id);
        }

        public Order Add(Order newOrder)
        {
            var savedEntity = context.Orders.Add(newOrder).Entity;
            context.SaveChanges();
            return savedEntity;
        }

        public void Update(Order orderToUpdate)
        {
            context.Orders.Update(orderToUpdate);
            context.SaveChanges();
        }

        public bool Exists(int id)
        {
            var exists = context.Orders.Count(x => x.Orderid == id);
            return exists == 1;
        }

        public bool Delete(Order orderToDelete)
        {
            var deletedOrder = context.Orders.Remove(orderToDelete);
            context.SaveChanges();
            return deletedOrder != null;
        }

    }

   
}
