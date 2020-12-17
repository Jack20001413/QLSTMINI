using System.Collections.Generic;
using System.Linq;
using Application.DTOs;
using Application.Interfaces;
using Application.Mappings;
using Domain.Entities;
using Domain.Repositories;

namespace Application.Services
{
    public class ImportingOrderService : IImportingOrderService
    {
        private readonly IImportingOrderRepository importingOrderRepository;
        private readonly IProductRepository productRepository;
        private readonly IImportingTransactionRepository importingTransactionRepository;
        
        public ImportingOrderService(IImportingOrderRepository importingOrderRepository,
                                    IProductRepository productRepository,
                                    IImportingTransactionRepository importingTransactionRepository)
        {
            this.importingOrderRepository = importingOrderRepository;
            this.productRepository = productRepository;
            this.importingTransactionRepository = importingTransactionRepository;
        }
        
        public void CreateOrder(ImportingOrderDto orderDto)
        {
            orderDto.CreatedDate = System.DateTime.UtcNow;

            List<Product> productList = new List<Product>();
            foreach(var transaction in orderDto.ImportingTransactions)
            {
                var product = productRepository.GetBy(transaction.ProductId);
                product.Quantity += transaction.Quantity;
                productList.Add(product);
            }

            importingOrderRepository.Add(orderDto.MappingImportingOrder());
            productRepository.UpdateQuantity(productList);
        }

        public void DeleteOrder(ImportingOrderDto order)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<ImportingOrderDto> GetAll()
        {
            return importingOrderRepository.GetAll().MappingDtos();
        }

        public ImportingOrderDto GetOrder(int id)
        {
            var orderDto = importingOrderRepository.GetBy(id).MappingDto();
            orderDto.ImportingTransactions = importingTransactionRepository.GetByImportingId(id).MappingTransactionDtos().ToList();
            return orderDto;
        }

        public void UpdateOrder(ImportingOrderDto order)
        {
            var oldOrder = importingOrderRepository.GetBy(order.Id);
            oldOrder.ImportingTransactions = importingTransactionRepository.GetByImportingId(order.Id).ToList();

            /*Remove old quantity*/
            List<Product> productList = new List<Product>();
            foreach(var transaction in oldOrder.ImportingTransactions)
            {
                var product = productRepository.GetBy(transaction.ProductId);
                product.Quantity -= transaction.Quantity;
                productList.Add(product);
            }
            productRepository.UpdateQuantity(productList);

            /*Remove old transaction*/
            importingTransactionRepository.RemoveRange(oldOrder.ImportingTransactions);

            /*Add new quantity*/
            List<Product> newProductList = new List<Product>();
            foreach(var transaction in order.ImportingTransactions)
            {
                transaction.ImportingOrderId = order.Id;
                var product = productRepository.GetBy(transaction.ProductId);
                product.Quantity += transaction.Quantity;
                newProductList.Add(product);
            }
            productRepository.UpdateQuantity(newProductList);

            /*Add new transaction*/
            importingOrderRepository.Update(order.MappingImportingOrder());
        }

        public bool OrderExists(int id)
        {
            var order = importingOrderRepository.GetBy(id);
            return order != null;
        }
    }
}