using System.Collections.Generic;
using Application.DTOs;
using Domain.Entities;

namespace Application.Mappings
{
    public static class VendorMapping
    {
        public static VendorDto MappingDto(this Vendor vendor)
        {
            return new VendorDto()
            {
                Id = vendor.Id,
                Name = vendor.Name,
                Address = vendor.Address,
                Phone = vendor.Phone
            };
        }

        public static Vendor MappingVendor(this VendorDto vendorDto)
        {
            return new Vendor()
            {
                Id = vendorDto.Id,
                Name = vendorDto.Name,
                Address = vendorDto.Address,
                Phone = vendorDto.Phone
            };
        }

        public static void MappingVendor(this VendorDto vendorDto,Vendor vendor)
        {
            vendor.Id = vendorDto.Id;
            vendor.Name = vendorDto.Name;
            vendor.Address = vendorDto.Address;
            vendor.Phone = vendorDto.Phone;
        }

        public static IEnumerable<VendorDto> MappingDtos(this IEnumerable<Vendor> vendors)
        {
            foreach(var vendor in vendors)
            {
                yield return vendor.MappingDto();
            }
        }
    }
}