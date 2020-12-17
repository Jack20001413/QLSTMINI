using System.Collections.Generic;
using Application.DTOs;
using Application.Interfaces;
using Application.Mappings;
using Domain.Repositories;

namespace Application.Services
{
    public class BrandService : IBrandService
    {   
        private readonly IBrandRepository brandRepository;

        public BrandService(IBrandRepository brandRepository)
        {
            this.brandRepository = brandRepository;
        }

        public void CreateBrand(BrandDto brandDto)
        {
            var brand = brandDto.MappingBrand();
            brandRepository.Add(brand);
        }

        public void DeleteBrand(BrandDto brandDto)
        {
            var brand = brandDto.MappingBrand();
            brandRepository.Delete(brand);
        }

        public IEnumerable<BrandDto> GetAll()
        {
            var brand = brandRepository.GetAll();
            return brand.MappingDtos();
        }

        public BrandDto GetBrand(int id)
        {
            var brand = brandRepository.GetBy(id);
            return brand.MappingDto();
        }

        public void UpdateBrand(BrandDto brandDto)
        {
            var brand = brandDto.MappingBrand();
            brandRepository.Update(brand);
        }

        public bool BrandExists(int id)
        {
            var brand = brandRepository.GetBy(id);
            return brand != null;
        }
    }
}