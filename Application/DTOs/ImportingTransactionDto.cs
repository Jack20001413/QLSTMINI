using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class ImportingTransactionDto
    {   
        [Key]
        public int Id { get; set; }


        public ImportingOrderDto ImportingOrder { get; set; }
        [ForeignKey(nameof(ImportingOrder))]
        public int ImportingOrderId { get; set; }


        public ProductDto Product { get; set; }
        [ForeignKey(nameof(Product))]
        public int ProductId { get; set; }


        [Required(ErrorMessage="Vui lòng điền số lượng")]
        public int Quantity { get; set; }


        [Required(ErrorMessage="Vui lòng điền đơn giá")]
        [DataType(DataType.Text)]
        public int UnitPrice { get; set; }


        [Required(ErrorMessage="Vui lòng điền tổng giá")]
        public int TotalPrice { get; set; }
    }
}