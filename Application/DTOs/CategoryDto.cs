using System;
using System.ComponentModel.DataAnnotations;

namespace Application.DTOs
{
    public class CategoryDto
    {   
        [Key]
        public int Id { get; set; }

        [RegularExpression(pattern: @"[^\d]+",ErrorMessage= "Tên loại không có số từ 0-9")]
        [MaxLength(50,ErrorMessage="Tên loại sản phẩm không quá 50 ký tự")]  
        [Required(ErrorMessage="Vui lòng nhập tên loại")]
        [DataType(DataType.Text)]
        public string Name { get; set; }
    }
}