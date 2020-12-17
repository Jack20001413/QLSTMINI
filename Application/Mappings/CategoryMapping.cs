using System.Collections.Generic;
using Application.DTOs;
using Domain.Entities;

namespace Application.Mappings
{
    public static class CategoryMapping
    {
        public static CategoryDto MappingDto(this Category category)
        {
            return new CategoryDto()
            {
                Id = category.Id,
                Name = category.Name,
            };
        }

        public static Category MappingCategory(this CategoryDto CategoryDto)
        {
            return new Category()
            {
                Id = CategoryDto.Id,
                Name = CategoryDto.Name,
            };
        }

        public static void MappingCategory(this CategoryDto CategoryDto,Category category)
        {
            category.Id = CategoryDto.Id;
            category.Name = CategoryDto.Name;
        }

        public static IEnumerable<CategoryDto> MappingDtos(this IEnumerable<Category> categories)
        {
            foreach(var category in categories)
            {
                yield return category.MappingDto();
            }
        }
    }
}