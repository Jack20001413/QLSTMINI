using System.Collections.Generic;
using Application.DTOs;
using Domain.Entities;

namespace Application.Mappings
{
    public static class SellingTransactionMapping
    {
        //Map from Entity to Dto
        public static SellingTransactionDto MappingDto(this SellingTransaction sellingTransaction)
        {
            return new SellingTransactionDto
            {
                Id = sellingTransaction.Id,
                SellingOrderId = sellingTransaction.SellingOrderId,
                SellingOrder = new SellingOrderDto()
                {
                    Id = sellingTransaction.SellingOrder.Id,
                },
                ProductId = sellingTransaction.ProductId,
                Product = new ProductDto()
                {
                    Id = sellingTransaction.Product.Id,
                    Name = sellingTransaction.Product.Name
                },
                Quantity = sellingTransaction.Quantity,
                UnitPrice = sellingTransaction.UnitPrice,
                TotalPrice = sellingTransaction.TotalPrice
            };
        }

        //Map from Dto to Entity
        public static SellingTransaction MappingTransaction(this SellingTransactionDto sellingTransactionDto)
        {
            return new SellingTransaction
            {
                Id = sellingTransactionDto.Id,
                SellingOrderId = sellingTransactionDto.SellingOrderId,
                ProductId = sellingTransactionDto.ProductId,
                Quantity = sellingTransactionDto.Quantity,
                UnitPrice = sellingTransactionDto.UnitPrice,
                TotalPrice = sellingTransactionDto.TotalPrice
            };
        }

        //Map from Dto to Entity
        public static void MappingTransaction(this SellingTransactionDto sellingTransactionDto, SellingTransaction sellingtransaction)
        {
            sellingtransaction.Id = sellingTransactionDto.Id;
            sellingtransaction.SellingOrderId = sellingTransactionDto.SellingOrderId;
            sellingtransaction.ProductId = sellingTransactionDto.ProductId;
            sellingtransaction.Quantity = sellingTransactionDto.Quantity;
            sellingtransaction.UnitPrice = sellingTransactionDto.UnitPrice;
            sellingtransaction.TotalPrice = sellingTransactionDto.TotalPrice;
            
        }

        //Map from Entity List to Dto List
        public static IEnumerable<SellingTransactionDto> MappingDtos(this IEnumerable<SellingTransaction> transactions)
        {
            foreach(var transaction in transactions)
            {
                yield return transaction.MappingDto();
            }
        }
    }
}