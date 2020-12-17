using System.Collections.Generic;
using System.Linq;
using Application.DTOs;
using Domain.Entities;

namespace Application.Mappings
{
    public static class SellingOrderMapping
    {
        //Map from Entity to Dto
        public static SellingOrderDto MappingDto(this SellingOrder sellingOrder)
        {
            return new SellingOrderDto
            {
                Id = sellingOrder.Id,
                CustomerId = sellingOrder.CustomerId,
                Customer = new CustomerDto()
                {
                    Id = sellingOrder.Customer.Id,
                    Fullname = sellingOrder.Customer.Fullname
                },
                EmployeeId = sellingOrder.EmployeeId,
                Employee = new EmployeeDto()
                {
                    Id = sellingOrder.Employee.Id,
                    Fullname = sellingOrder.Employee.Fullname
                },
                CreatedDate = sellingOrder.CreatedDate,
                Status = sellingOrder.Status,
                TotalPrice = sellingOrder.TotalPrice,
                NameCode = sellingOrder.NameCode
            };
        }

        //Map from Dto to Entity
        public static SellingOrder MappingOrder(this SellingOrderDto sellingOrderDto)
        {
            return new SellingOrder
            {
                Id = sellingOrderDto.Id,
                CustomerId = sellingOrderDto.CustomerId,
                EmployeeId = sellingOrderDto.EmployeeId,
                CreatedDate = (System.DateTime)sellingOrderDto.CreatedDate,
                Status = sellingOrderDto.Status,
                TotalPrice = sellingOrderDto.TotalPrice,
                NameCode = sellingOrderDto.NameCode,
                SellingTransactions = sellingOrderDto.SellingTransactions.MappingTransactions().ToList(),
            };
        }

        //Map from Dto to Entity
        // public static void MappingOrder(this SellingOrderDto sellingOrderDto, SellingOrder sellingorder)
        // {
        //     sellingorder.Id = sellingOrderDto.Id;
        //     sellingorder.CustomerId = sellingOrderDto.CustomerId;
        //     sellingorder.EmployeeId = sellingOrderDto.EmployeeId;
        //     sellingorder.CreatedDate = (System.DateTime)sellingOrderDto.CreatedDate;
        //     sellingorder.Status = sellingOrderDto.Status;
        //     sellingorder.TotalPrice = sellingOrderDto.TotalPrice;
            
        // }

        //Map from Entity List to Dto List
        public static IEnumerable<SellingOrderDto> MappingDtos(this IEnumerable<SellingOrder> orders)
        {
            foreach(var order in orders)
            {
                yield return order.MappingDto();
            }
        }

        //Map Transaction list from Dto to Entity
        public static IEnumerable<SellingTransaction> MappingTransactions(this IEnumerable<SellingTransactionDto> sellingTransactionDtos)
        {
            foreach(var sellingTransactionDto in sellingTransactionDtos) {
                yield return new SellingTransaction()
                {
                    Id = sellingTransactionDto.Id,
                    SellingOrderId = sellingTransactionDto.SellingOrderId,
                    ProductId = sellingTransactionDto.ProductId,
                    Quantity = sellingTransactionDto.Quantity,
                    UnitPrice = sellingTransactionDto.UnitPrice,
                    TotalPrice = sellingTransactionDto.TotalPrice
                };
            }
        }

        //Map Transaction list from Entity to Dto
        public static IEnumerable<SellingTransactionDto> MappingTransactionDtos(this IEnumerable<SellingTransaction> sellingTransactions)
        {
            foreach(var sellingTransaction in sellingTransactions) {
                yield return new SellingTransactionDto()
                {
                    Id = sellingTransaction.Id,
                    SellingOrderId = sellingTransaction.SellingOrderId,
                    SellingOrder = new SellingOrderDto()
                    {
                        Id = sellingTransaction.SellingOrderId
                    },
                    ProductId = sellingTransaction.ProductId,
                    Product = new ProductDto()
                    {
                        Id = sellingTransaction.Product.Id,
                        Name = sellingTransaction.Product.Name,
                        Unit = sellingTransaction.Product.Unit
                    },
                    Quantity = sellingTransaction.Quantity,
                    UnitPrice = sellingTransaction.UnitPrice,
                    TotalPrice = sellingTransaction.TotalPrice
                };
            }
        }
    }
}