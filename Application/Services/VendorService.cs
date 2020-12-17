using System.Collections.Generic;
using Application.DTOs;
using Application.Interfaces;
using Application.Mappings;
using Domain.Repositories;

namespace Application.Services
{
    public class VendorService : IVendorService
    {   
        private readonly IVendorRepository vendorRepository;
        public VendorService(IVendorRepository vendorRepository)
        {
            this.vendorRepository = vendorRepository;
        }

        public void CreateVendor(VendorDto vendorDto)
        {
            vendorRepository.Add(vendorDto.MappingVendor());
        }

        public void DeleteVendor(VendorDto vendorDto)
        {
            vendorRepository.Delete(vendorDto.MappingVendor());
        }

        public IEnumerable<VendorDto> GetAll()
        {
            return vendorRepository.GetAll().MappingDtos();
        }

        public VendorDto GetVendor(int id)
        {
            return vendorRepository.GetBy(id).MappingDto();
        }

        public void UpdateVendor(VendorDto vendorDto)
        {
            vendorRepository.Update(vendorDto.MappingVendor());
        }

        public bool VendorExists(int id)
        {
            return vendorRepository.GetBy(id).MappingDto() != null;
        }

    }
}