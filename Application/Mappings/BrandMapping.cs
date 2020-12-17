using System.Collections.Generic;
using Application.DTOs;
using Domain.Entities;

namespace Application.Mappings
{
    public static class BrandMapping
    {
        public static BrandDto MappingDto(this Brand brand)
        {
            return new BrandDto()
            {
                Id = brand.Id,
                Name = brand.Name,
                Address = brand.Address,
                Phone = brand.Phone
            };
        }

        public static Brand MappingBrand(this BrandDto brandDto)
        {
            return new Brand()
            {
                Id = brandDto.Id,
                Name = brandDto.Name,
                Address = brandDto.Address,
                Phone = brandDto.Phone
            };
        }

        public static void MappingBrand(this BrandDto brandDto,Brand brand)
        {
            brand.Id = brandDto.Id;
            brand.Name = brandDto.Name;
            brand.Address = brandDto.Address;
            brand.Phone = brandDto.Phone;
        }

        public static IEnumerable<BrandDto> MappingDtos(this IEnumerable<Brand> brands)
        {
            foreach(var brand in brands)
            {
                yield return brand.MappingDto();
            }
        }
    }
}