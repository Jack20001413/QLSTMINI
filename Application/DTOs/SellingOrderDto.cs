using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class SellingOrderDto
    {   
        [Key]
        public int Id { get; set; }

        [ForeignKey(nameof(Customer))]
        public int CustomerId { get; set; }
        public CustomerDto Customer { get; set; }

        [ForeignKey(nameof(Employee))]
        public int EmployeeId { get; set; }
        public EmployeeDto Employee { get; set; }

        public string NameCode { get; set; }
        

        [DisplayFormat(DataFormatString = "{0:N0}", ApplyFormatInEditMode = false)]
        public int TotalPrice { get; set; }


        [DataType(DataType.Date)]
        public DateTime? CreatedDate { get; set; }
        
        public int Status { get; set; }

         public virtual IEnumerable<SellingTransactionDto> SellingTransactions { get; set; }
    }
}