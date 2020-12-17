using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class SellingTransactionDto
    {   
        [Key]
        public int Id { get; set; }

        [ForeignKey(nameof(SellingOrder))]
        public int SellingOrderId { get; set; }
        public SellingOrderDto SellingOrder { get; set; }

        [ForeignKey(nameof(Product))]
        public int ProductId { get; set; }
        public ProductDto Product { get; set; }


        [Required(ErrorMessage="Vui lòng điền số lượng")]
        public int Quantity { get; set; }


        [Required(ErrorMessage="Vui lòng điền đơn giá")]        
        public int UnitPrice { get; set; }


        [Required(ErrorMessage="Vui lòng điền tổng giá")]
        public int TotalPrice { get; set; }
    }
}