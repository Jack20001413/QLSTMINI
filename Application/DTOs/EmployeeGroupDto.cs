using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace Application.DTOs
{
    public class EmployeeGroupDto
    {   
        [Key]
        public int Id { get; set; }

        [RegularExpression(pattern: @"[^\d]+",ErrorMessage= "Tên nhóm nhân viên không có số từ 0-9")]
        [MaxLength(50,ErrorMessage="Tên nhóm nhân viên không quá 50 ký tự")]      
        [Required(ErrorMessage="Vui lòng nhập tên nhóm nhân viên")]
        [DataType(DataType.Text)]
        public string Name { get; set; }
    }
}