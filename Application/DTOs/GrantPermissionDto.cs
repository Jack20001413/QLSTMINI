using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class GrantPermissionDto
    {   
        [Key]
        public int Id { get; set; }



        public EmployeeDto EmployeeGroup { get; set; }


        
        public PermissionDto Permission { get; set; }
    }
}