using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class BrandDto
    {   
        [Key]
        public int Id { get; set; }


        [DataType(DataType.Text)]
        [Required(ErrorMessage="Vui lòng nhập tên thương hiệu")]
        public string Name { get; set; }


        [Required(ErrorMessage="Vui lòng nhập địa chỉ")]
        public string Address { get; set; }


        [DataType(DataType.PhoneNumber, ErrorMessage="Số điện thoại không hợp lệ")]
        [Required(ErrorMessage="Vui lòng nhập số điện thoại")]
        public string Phone { get; set; }
    }
}