using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class VendorDto
    {
        public int Id { get; set; }


        [Required(ErrorMessage="Vui lòng nhập tên nhà cung cấp!")]
        [MaxLength(30,ErrorMessage="Tên không quá 30 ký tự")]
        [DataType(DataType.Text)]
        public string Name { get; set; }


        [Required(ErrorMessage= "Vui lòng nhập địa chỉ!")]
        public string Address { get; set; }



        [RegularExpression(pattern: @"0\d{9}",ErrorMessage= "Số điện thoại không hợp lệ")]
        [DataType(DataType.PhoneNumber, ErrorMessage= "Số điện thoại không hợp lệ")]
        [Required(ErrorMessage="Vui lòng nhập số điện thoại")]
        public string Phone { get; set; }
    }
}