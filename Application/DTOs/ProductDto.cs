using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class ProductDto
    {   
        [Key]
        public int Id { get; set; }


        [Required(ErrorMessage="Vui lòng điền tên sản phẩm")]
        [DataType(DataType.Text)]
        public string Name { get; set; }


        [Required(ErrorMessage="Vui lòng điền đơn vị tính")]
        [DataType(DataType.Text)]
        public string Unit { get; set; }

        [ForeignKey(nameof(Category))]
        public int CategoryId { get; set; }
        public CategoryDto Category { get; set; }


        [ForeignKey(nameof(Brand))]
        public int BrandId { get; set; }
        public BrandDto Brand { get; set; }

        public string OrgCode { get; set; }


        [DataType(DataType.Text)]
        [Required(ErrorMessage="Vui lòng điền thông tin mô tả")]
        public string Description { get; set; }

        public int Quantity { get; set; }


        [Required(ErrorMessage="Vui lòng điền giá nhập kho")]
        [DisplayFormat(DataFormatString = "{0:N0}", ApplyFormatInEditMode = false)]
        public int ImportPrice { get; set; }


        [Required(ErrorMessage="Vui lòng điền giá bán")]
        [DisplayFormat(DataFormatString = "{0:N0}", ApplyFormatInEditMode = false)]
        public int SalePrice { get; set; }
    }
}