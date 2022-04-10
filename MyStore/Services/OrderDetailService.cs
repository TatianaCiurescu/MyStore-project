using AutoMapper;
using MyStore.Data;
using MyStore.Domain.Entities;
using MyStore.Models;
using System.Collections.Generic;
using System.Linq;

namespace MyStore.Services
{
    public interface IOrderDetailService
    {
        OrderDetail AddDetail(OrderDetail newDetail);
        bool Delete(int id);
        bool Exists(int id);
        IEnumerable<OrderDetailModel> GetAll();
        OrderDetail GetById(int id);
        void UpdateDetails(OrderDetailModel orderModel);
    }

    public class OrderDetailService : IOrderDetailService
    {
        private readonly IOrderDetailRepository orderDetailRepository;
        private readonly IMapper mapper;

        public OrderDetailService(IOrderDetailRepository orderDetailRepository, IMapper mapper )
        {
            this.orderDetailRepository = orderDetailRepository;
            this.mapper = mapper;
        }

        public IEnumerable<OrderDetailModel> GetAll()
        {
            var allDetails = orderDetailRepository.GetAll().ToList();
            var models = mapper.Map<IEnumerable<OrderDetailModel>>(allDetails);

            return models;
        }

        public OrderDetail GetById(int id)
        {
            return orderDetailRepository.GetById(id);
        }

        public OrderDetail AddDetail(OrderDetail newDetail)
        {
            var addedDetail = orderDetailRepository.Add(newDetail);
            return addedDetail;
        }

        public void UpdateDetails(OrderDetailModel orderModel)
        {
            OrderDetail detailsToUpdate = mapper.Map<OrderDetail>(orderModel);
            orderDetailRepository.Update(detailsToUpdate);
        }

        public bool Exists(int id)
        {
            return orderDetailRepository.Exists(id);
        }

        public bool Delete(int id)
        {
            var detailsToDelete = orderDetailRepository.GetById(id);
            return orderDetailRepository.Delete(detailsToDelete);
        }
    }
}
    
