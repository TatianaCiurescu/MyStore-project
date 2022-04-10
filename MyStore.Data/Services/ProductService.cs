using AutoMapper;
using MyStore.Data.Repositories;
using MyStore.Domain.Entities;
using MyStore.Domain.Models;
using System.Collections.Generic;
using System.Linq;

namespace MyStore.Data.Services
{

    public interface IProductService
    {
        Product AddProduct(ProductModel newProduct);
        bool Delete(int id);
        bool Exists(int id);
        IEnumerable<ProductModel> GetAllProducts();
        Product GetById(int id);
        void UpdateProduct(ProductModel model);
    }

    public class ProductService: IProductService
    {
        private readonly IProductRepository productRepository;
        private readonly IMapper mapper;

        public ProductService(IProductRepository productRepository,IMapper mapper)
        {
            this.productRepository = productRepository;
            this.mapper = mapper;
        }

        public IEnumerable<ProductModel> GetAllProducts()
        {
            //take domain objects
            var allProducts = productRepository.GetAll().ToList();//List<Product>AutoMapper.AutoMapperMappingException: 'Error mapping types.'

            //transfer domain objects from list->List<ProductModel>
            var productModels = mapper.Map<IEnumerable<ProductModel>>(allProducts);

            return productModels;
        }

        public Product GetById(int id)
        {
            return productRepository.GetById(id);
        }

        public Product AddProduct(ProductModel newProduct)
        {
            //->ProductModel->Product
            //assuming is valid-> transform to Product(domain obj)

            Product productToAdd = mapper.Map<Product>(newProduct);
            var addedProduct = productRepository.Add(productToAdd);
            newProduct = mapper.Map<ProductModel>(addedProduct);

            return addedProduct;
        }

        public void UpdateProduct(ProductModel model)
        {
            Product productToUpdate = mapper.Map<Product>(model);
            productRepository.Update(productToUpdate);
        }

        public bool Exists(int id)
        {
            return productRepository.Exists(id);
        }

        public bool Delete(int id)
        {
            //get by id
            var itemToDelete = productRepository.GetById(id);

            //delete item
            return productRepository.Delete(itemToDelete);
        }


    }
}
