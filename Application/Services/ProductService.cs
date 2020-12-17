using System.Collections.Generic;
using Application.DTOs;
using Application.Interfaces;
using Application.Mappings;
using Domain.Repositories;

namespace Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository productRepository;
        private readonly IBrandRepository brandRepository;
        private readonly ICategoryRepository categoryRepository;

        public ProductService(
            IProductRepository productRepository,
            ICategoryRepository categoryRepository,
            IBrandRepository brandRepository)
        {
            this.productRepository = productRepository;
            this.brandRepository = brandRepository;
            this.categoryRepository = categoryRepository;
        }

        public void CreateProduct(ProductDto productDto)
        {
            productRepository.Add(productDto.MappingProduct());
        }

        public void DeleteProduct(ProductDto productDto)
        {
            productRepository.Delete(productDto.MappingProduct());
        }

        public IEnumerable<ProductDto> GetAll()
        {
            return productRepository.GetAll().MappingDtos();
        }

        public IEnumerable<ProductDto> Search(string parm)
        {
            return productRepository.Search(parm).MappingDtos();
        }

        public ProductDto GetProduct(int id)
        {
            var product = productRepository.GetBy(id);
            product.Brand = brandRepository.GetBy(product.BrandId);
            product.Category = categoryRepository.GetBy(product.CategoryId);
            return product.MappingDto();
        }

        public void UpdateProduct(ProductDto productDto)
        {
            productRepository.Update(productDto.MappingProduct());
        }

        public bool ProductExists(int id)
        {
            //var product = productRepository.GetBy(id);
            return productRepository.GetBy(id) != null;
        }
    }
}