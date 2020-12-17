using System.Collections.Generic;
using Application.DTOs;
using Domain.Entities;

namespace Application.Mappings
{
    public static class ProductMapping
    {
        public static ProductDto MappingDto(this Product product)
        {
            return new ProductDto()
            {
                Id = product.Id,
                Name = product.Name,
                Unit = product.Unit,
                CategoryId = product.CategoryId,
                Category = new CategoryDto()
                {
                    Id = product.Category.Id,
                    Name = product.Category.Name
                },
                BrandId = product.BrandId,
                Brand = new BrandDto()
                {
                    Id = product.Brand.Id,
                    Name = product.Brand.Name
                },
                OrgCode = product.OrgCode,
                Description = product.Description,
                Quantity = product.Quantity,
                ImportPrice = product.ImportPrice,
                SalePrice = product.SalePrice
            };
        }

        public static Product MappingProduct(this ProductDto productDto)
        {
            return new Product()
            {
                Id = productDto.Id,
                Name = productDto.Name,
                Unit = productDto.Unit,
                CategoryId = productDto.CategoryId,
                BrandId = productDto.BrandId,
                OrgCode = productDto.OrgCode,
                Description = productDto.Description,
                Quantity = productDto.Quantity,
                ImportPrice = productDto.ImportPrice,
                SalePrice = productDto.SalePrice
            };
        }

        public static void MappingProduct(this ProductDto productDto,Product product)
        {
            product.Id = productDto.Id;
            product.Name = productDto.Name;
            product.Unit = productDto.Unit;
            product.CategoryId = productDto.CategoryId;
            product.BrandId = productDto.BrandId;
            product.OrgCode = productDto.OrgCode;
            product.Description = productDto.Description;
            product.Quantity = productDto.Quantity;
            product.ImportPrice = productDto.ImportPrice;
            product.SalePrice = productDto.SalePrice;
        }

        public static IEnumerable<ProductDto> MappingDtos(this IEnumerable<Product> products)
        {
            foreach(var product in products)
            {
                yield return product.MappingDto();
            }
        }

        public static IEnumerable<Product> MappingEntities(this IEnumerable<ProductDto> productDtos)
        {
            foreach(var productDto in productDtos)
            {
                yield return productDto.MappingProduct();
            }
        }

    }
}