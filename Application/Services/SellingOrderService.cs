using System;
using System.Collections.Generic;
using System.Linq;
using Application.DTOs;
using Application.Interfaces;
using Application.Mappings;
using Domain.Entities;
using Domain.Repositories;

namespace Application.Services
{
    public class SellingOrderService : ISellingOrderService
    {
        private readonly ISellingOrderRepository sellingOrderRepository;
        private readonly ISellingTransactionRepository sellingTransactionRepository;
        private readonly IProductRepository productRepository;
        public SellingOrderService(ISellingOrderRepository sellingOrderRepository,
                                IProductRepository productRepository,
                                ISellingTransactionRepository sellingTransactionRepository)
        {
            this.sellingOrderRepository = sellingOrderRepository;
            this.productRepository = productRepository;
            this.sellingTransactionRepository = sellingTransactionRepository;
        }

        public void CreateOrder(SellingOrderDto orderDto)
        {
            orderDto.CreatedDate = System.DateTime.UtcNow;
            
            List<Product> productList = new List<Product>();
            foreach(var transaction in orderDto.SellingTransactions)
            {
                var product = productRepository.GetBy(transaction.ProductId);
                product.Quantity -= transaction.Quantity;
                productList.Add(product);
            }

            sellingOrderRepository.Add(orderDto.MappingOrder());
            productRepository.UpdateQuantity(productList);
        }

        public void DeleteOrder(SellingOrderDto orderDto)
        {
            sellingOrderRepository.Delete(orderDto.MappingOrder());
        }

        public IEnumerable<SellingOrderDto> GetAll()
        {
            return sellingOrderRepository.GetAll().MappingDtos();
        }

        public SellingOrderDto GetOrder(int id)
        {
            var orderDto = sellingOrderRepository.GetBy(id).MappingDto();
            orderDto.SellingTransactions = sellingTransactionRepository.GetTransactions(id).MappingTransactionDtos().ToList();
            return orderDto;
        }

        public void UpdateOrder(SellingOrderDto orderDto)
        {
            var oldOrder = sellingOrderRepository.GetBy(orderDto.Id);
            oldOrder.SellingTransactions = sellingTransactionRepository.GetTransactions(orderDto.Id).ToList();

            /*Remove old quantity*/
            List<Product> productList = new List<Product>();
            foreach(var transaction in oldOrder.SellingTransactions)
            {
                var product = productRepository.GetBy(transaction.ProductId);
                product.Quantity += transaction.Quantity;
                productList.Add(product);
            }
            productRepository.UpdateQuantity(productList);

            /*Remove old transaction*/
            sellingTransactionRepository.RemoveRange(oldOrder.SellingTransactions);

            /*Add new quantity*/
            List<Product> newProductList = new List<Product>();
            foreach(var transaction in orderDto.SellingTransactions)
            {
                transaction.SellingOrderId = orderDto.Id;
                var product = productRepository.GetBy(transaction.ProductId);
                product.Quantity -= transaction.Quantity;
                newProductList.Add(product);
            }
            productRepository.UpdateQuantity(newProductList);

            /*Add new transaction*/
            sellingOrderRepository.Update(orderDto.MappingOrder());
        }

        public IEnumerable<SellingOrderDto> GetStatistics(DateTime startTime, DateTime endTime)
        {
            return sellingOrderRepository.GetStatistics(startTime,endTime).MappingDtos();
        }

        public bool OrderExists(int id)
        {
            var order = sellingOrderRepository.GetBy(id);
            return order != null;
        }
    }
}