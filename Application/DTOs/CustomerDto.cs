using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class CustomerDto
    {   
        //[Key]
        public int Id { get; set; }


        [Required(ErrorMessage="Vui lòng nhập họ tên")]
        [MaxLength(50,ErrorMessage="Tên không quá 50 ký tự")]
        [DataType(DataType.Text)]
        public string Fullname { get; set; }


        public string FullnameSlug { get; set; }


        //Đây là CMND hay Căn cước
        [StringLength(maximumLength: 15, MinimumLength= 9,ErrorMessage= "CMND có độ dài từ 9-12 số")]
        [RegularExpression(pattern: @"^\d{9,12}$",ErrorMessage= "CMND không hợp lệ")]
        [Required(ErrorMessage="Vui lòng nhập CMND")]
        public string CardId { get; set; }


        [RegularExpression(pattern: @"^(\w+\.?)+\@\w+(\.{1}\w+)+$", ErrorMessage="Email không hợp lệ")]
        [Required(ErrorMessage="Vui lòng nhập email")]
        public string Email { get; set; }


        //Đây là Mã thẻ khi đi siêu thị
        public string CardNumber { get; set; }


        [RegularExpression(pattern: @"0\d{9}",ErrorMessage= "Số điện thoại không hợp lệ")]
        [DataType(DataType.PhoneNumber, ErrorMessage= "Số điện thoại không hợp lệ")]
        [Required(ErrorMessage="Vui lòng nhập số điện thoại")]
        public string Phone { get; set; }


        [DataType(DataType.Date)]
        [Required(ErrorMessage="Vui lòng chọn ngày sinh")]
        public DateTime? BirthDate { get; set; }


        //a-zA-Z\u{00C0}-\u{1EF9}
        //[RegularExpression(pattern: @"^(\w+\/?)+\s([\p{P}]+\s*)+([A-Z]\.\d+\s?)+([[\p{P}]|\.]+\s?)*$",ErrorMessage= "Địa chỉ không hợp lệ")]
        [Required(ErrorMessage="Vui lòng nhập địa chỉ")]
        public string Address { get; set; }


        [ForeignKey(nameof(CustomerGroup))]
        public int CustomerGroupId { get; set; }
        public virtual CustomerGroupDto CustomerGroup { get; set; }
    }
}