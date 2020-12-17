using System.Collections;
using System.Collections.Generic;
using Application.DTOs;

namespace Application.Interfaces
{
    public interface IBrandService
    {
         IEnumerable<BrandDto> GetAll();
         BrandDto GetBrand(int id);
         void CreateBrand(BrandDto brand);
         void UpdateBrand(BrandDto brand);
         void DeleteBrand(BrandDto brand);
         bool BrandExists(int id);
    }
}