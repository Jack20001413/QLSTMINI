using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Application.DTOs;
using Domain.Entities;

namespace Application.Mappings
{
    public static class ImportingOrderMapping
    {
        //Map from Entity to Dto
        public static ImportingOrderDto MappingDto(this ImportingOrder importingOrder)
        {
            return new ImportingOrderDto
            {
                Id = importingOrder.Id,
                VendorId = importingOrder.VendorId,
                Vendor = new VendorDto
                {
                    Id = importingOrder.Vendor.Id,
                    Name = importingOrder.Vendor.Name
                },
                EmployeeId = importingOrder.EmployeeId,
                Employee = new EmployeeDto
                {
                    Id = importingOrder.Employee.Id,
                    Fullname = importingOrder.Employee.Fullname
                },
                NameCode = importingOrder.NameCode,
                TotalPrice = importingOrder.TotalPrice,
                CreatedDate = importingOrder.CreatedDate,
                Status = importingOrder.Status
            };
        }

        //Map from Dto to Entity
        public static ImportingOrder MappingImportingOrder(this ImportingOrderDto importingOrderDto)
        {
            return new ImportingOrder
            {
                Id = importingOrderDto.Id,
                VendorId = importingOrderDto.VendorId,
                EmployeeId = importingOrderDto.EmployeeId,
                NameCode = importingOrderDto.NameCode,
                TotalPrice = importingOrderDto.TotalPrice,
                CreatedDate = (System.DateTime)importingOrderDto.CreatedDate,
                Status = importingOrderDto.Status,
                ImportingTransactions = importingOrderDto.ImportingTransactions.MappingTransactions().ToList(),
            };
        }
        

        //Map Transaction list from Dto to Entity
        public static IEnumerable<ImportingTransaction> MappingTransactions(this IEnumerable<ImportingTransactionDto> importingTransactionDtos)
        {
            foreach(var importingTransactionDto in importingTransactionDtos) {
                yield return new ImportingTransaction()
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
        }

        //Map Transaction list from Entity to Dto
        public static IEnumerable<ImportingTransactionDto> MappingTransactionDtos(this IEnumerable<ImportingTransaction> importingTransactions)
        {
            foreach(var importingTransaction in importingTransactions) {
                yield return new ImportingTransactionDto()
                {
                    Id = importingTransaction.Id,
                    ImportingOrderId = importingTransaction.ImportingOrderId,
                    ImportingOrder = new ImportingOrderDto()
                    {
                        Id = importingTransaction.ImportingOrderId
                    },
                    ProductId = importingTransaction.ProductId,
                    Product = new ProductDto()
                    {
                        Id = importingTransaction.Product.Id,
                        Name = importingTransaction.Product.Name,
                        Unit = importingTransaction.Product.Unit
                    },
                    Quantity = importingTransaction.Quantity,
                    UnitPrice = importingTransaction.UnitPrice,
                    TotalPrice = importingTransaction.TotalPrice
                };
            }
        }

        //Map from Dto to Entity
        /*
        public static void MappingEmployee(this EmployeeDto employeeDto, Employee employee)
        {
            employee.Id = employeeDto.Id;
            employee.Fullname = employeeDto.Fullname;
            employee.CardId = employeeDto.CardId;
            employee.Email = employeeDto.Email;
            employee.Password = employeeDto.Password;
            employee.Phone = employeeDto.Phone;
            employee.Address = employeeDto.Address;
            employee.BirthDate = (System.DateTime)employeeDto.BirthDate;
            employee.EmployeeGroupId = employeeDto.EmployeeGroupId;
        }*/

        //Map from Entity List to Dto List
        public static IEnumerable<ImportingOrderDto> MappingDtos(this IEnumerable<ImportingOrder> importingOrders)
        {
            foreach(var importingOrder in importingOrders)
            {
                yield return importingOrder.MappingDto();
            }
        }
    }
}