using System.Collections.Generic;
using Application.DTOs;
using Domain.Entities;

namespace Application.Mappings
{
    public static class ImportingTransactionMapping
    {
        public static ImportingTransactionDto MappingDto(this ImportingTransaction importingTransaction)
        {
            return new ImportingTransactionDto()
            {
                Id = importingTransaction.Id,
                ImportingOrderId = importingTransaction.ImportingOrder.Id,
                ImportingOrder = new ImportingOrderDto()
                {
                    Id = importingTransaction.ImportingOrder.Id
                },
                ProductId = importingTransaction.ProductId,
                Product = new ProductDto()
                {
                    Id = importingTransaction.Product.Id
                },
                Quantity = importingTransaction.Quantity,
                UnitPrice = importingTransaction.UnitPrice,
                TotalPrice = importingTransaction.TotalPrice
            };
        }

        //Map Transaction list from Dto to Entity
        public static ImportingTransaction MappingTransaction(this ImportingTransactionDto importingTransactionDto)
        {
            return new ImportingTransaction()
            {
                Id = importingTransactionDto.Id,
                ImportingOrderId = importingTransactionDto.ImportingOrderId,
                // ImportingOrder = new ImportingOrder()
                // {
                //     Id = importingTransactionDto.ImportingOrder.Id
                // },
                ProductId = importingTransactionDto.ProductId,
                // Product = new Product()
                // {
                //     Id = importingTransactionDto.Product.Id
                // },
                Quantity = importingTransactionDto.Quantity,
                UnitPrice = importingTransactionDto.UnitPrice,
                TotalPrice = importingTransactionDto.TotalPrice
            };

        }

        // //Map Transaction list from Dto to Entity
        // public static IEnumerable<ImportingTransaction> MappingTransactions(this IEnumerable<ImportingTransactionDto> importingTransactionDtos)
        // {
        //     foreach(var importingTransactionDto in importingTransactionDtos) {
        //         yield return importingTransactionDto.MappingTransaction();
        //     }
        // }
    }
}