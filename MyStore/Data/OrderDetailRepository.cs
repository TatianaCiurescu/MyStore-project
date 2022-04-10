using MyStore.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace MyStore.Data
{
    public interface IOrderDetailRepository
    {
        OrderDetail Add(OrderDetail orderDetail);
        bool Delete(OrderDetail detailToDelete);
        bool Exists(int id);
        IEnumerable<OrderDetail> GetAll();
        OrderDetail GetById(int id);
        void Update(OrderDetail orderUpdate);
    }
    public class OrderDetailRepository: IOrderDetailRepository
    {
        private readonly StoreContext context;

        public OrderDetailRepository(StoreContext context)
        {
            this.context = context;
        }

        public IEnumerable<OrderDetail> GetAll()
        { 
            return context.OrderDetails.ToList();
        }

        public OrderDetail GetById(int id)
        {
            return context.OrderDetails.FirstOrDefault(x => x.Orderid == id);
        }

        public OrderDetail Add(OrderDetail orderDetail)
        {
            var item = context.OrderDetails.Add(orderDetail);
            context.SaveChanges();

            return item.Entity;
        }

        public void Update(OrderDetail orderUpdate)
        {
            context.OrderDetails.Update(orderUpdate);
            context.SaveChanges();
        }

        public bool Exists(int id) 
        {
            var exists = context.OrderDetails.Count(x => x.Orderid == id);
            return exists == 1;
        }

        public bool Delete (OrderDetail detailToDelete)
        {
            var deletedItem = context.OrderDetails.Remove(detailToDelete);
            context.SaveChanges();

            return deletedItem != null;
        }
    }

    
}
