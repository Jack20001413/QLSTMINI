using System.Collections.Generic;
using Application.DTOs;
using Application.Interfaces;
using Application.Mappings;
using Domain.Repositories;

namespace Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository categoryRepository;
        
        public CategoryService(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        public void CreateCategory(CategoryDto categoryDto)
        {
            //var category = categoryDto.MappingCategory();
            categoryRepository.Add(categoryDto.MappingCategory());
        }

        public void DeleteCategory(CategoryDto categoryDto)
        {
            // var category = categoryDto.MappingCategory();
            categoryRepository.Delete(categoryDto.MappingCategory());
        }

        public IEnumerable<CategoryDto> GetAll()
        {
            return categoryRepository.GetAll().MappingDtos();
        }

        public CategoryDto GetCategory(int id)
        {
            return categoryRepository.GetBy(id).MappingDto();
        }

        public void UpdateCategory(CategoryDto categoryDto)
        {
            // var category = categoryDto.MappingCategory();
            categoryRepository.Update(categoryDto.MappingCategory());
        }

        public bool CategoryExists(int id)
        {
            // var category = _db.Categories.Find(id);
            return categoryRepository.GetBy(id) != null;
        }

    }
}