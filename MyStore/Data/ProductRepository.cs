using MyStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyStore.Data
{
    public interface IProductRepository
    {
        Product Add(Product newProduct);
        bool Delete(Product productToDelete);
        bool Exists(int id);
        IEnumerable<Product> GetAll();
        Product GetById(int id);
        void Update(Product productToUpdate);
    }
    public class ProductRepository : IProductRepository
    {
        private readonly StoreContext context;
        public ProductRepository(StoreContext context)
        {
            this.context = context;
        }
        public IEnumerable<Product> GetAll()
        {
            return context.Products.ToList();
        }

        public IEnumerable<Product> FindByCategory(int categoryId)
        {
            return context.Products.Where(x => x.Categoryid == categoryId).ToList();
        }

        public Product GetById(int id)
        {
            return context.Products.FirstOrDefault(x => x.Productid == id);
        }

        public Product Add(Product newProduct)
        {
            var addedProduct=context.Products.Add(newProduct);
            context.SaveChanges();

            return addedProduct.Entity;
        }

        public void Update(Product productToUpdate)
        {
            context.Products.Update(productToUpdate);
            context.SaveChanges();
        }

        public bool Exists(int id)
        {
            var exists = context.Products.Count(x => x.Productid == id);
            return exists == 1;
        }

        public bool Delete(Product productToDelete)
        {
            var deletedItem = context.Products.Remove(productToDelete);
            context.SaveChanges();
            return deletedItem != null;
        }
    }
}
