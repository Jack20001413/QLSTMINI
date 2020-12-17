using System.Collections.Generic;
using Application.DTOs;

namespace Application.Interfaces
{
    public interface IVendorService
    {
         IEnumerable<VendorDto> GetAll();
         VendorDto GetVendor(int id);
         void CreateVendor(VendorDto vendor);
         void UpdateVendor(VendorDto vendor);
         void DeleteVendor(VendorDto vendor);
         bool VendorExists(int id);
         
    }
}