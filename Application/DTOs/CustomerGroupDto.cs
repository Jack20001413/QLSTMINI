using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class CustomerGroupDto
    {   
        [Key]
        public int Id { get; set; }

//d la danh cho chu so, W la danh cho ki tu dac biet
        [RegularExpression(pattern: @"[^\d]+",ErrorMessage= "Tên nhóm khách hàng không có số từ 0-9")]
        [MaxLength(20,ErrorMessage="Tên nhóm khách hàng không quá 20 ký tự")]  
        [Required(ErrorMessage="Vui lòng nhập tên nhóm khách hàng")]
        [DataType(DataType.Text)]
        public string Name { get; set; }
        
        public virtual ICollection<CustomerDto> Customers { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}