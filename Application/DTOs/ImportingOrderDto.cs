using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class ImportingOrderDto
    {   
        [Key]
        public int Id { get; set; }



        [ForeignKey(nameof(Vendor))]
        public int VendorId { get; set; }
        public virtual VendorDto Vendor { get; set; }
        

        [ForeignKey(nameof(Employee))]
        public int EmployeeId { get; set; }
        public virtual EmployeeDto Employee { get; set; }
       

        
        public string NameCode { get; set; }


        [DisplayFormat(DataFormatString = "{0:N0}", ApplyFormatInEditMode = false)]
        public int TotalPrice { get; set; }


        [DataType(DataType.Date)]
        public DateTime? CreatedDate { get; set; }



        public int Status { get; set; }

        public virtual IEnumerable<ImportingTransactionDto> ImportingTransactions { get; set; }
    }
}