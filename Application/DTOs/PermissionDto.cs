using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class PermissionDto
    {
        [Key]
        public string Code { get; set; }


        [Required(ErrorMessage="Vui lòng điền tên")]
        [DataType(DataType.Text)]
        public string Name { get; set; }


        [DataType(DataType.Text)]
        [Required(ErrorMessage="Vui lòng điền thông tin mô tả")]
        public string Description { get; set; }
    }
}