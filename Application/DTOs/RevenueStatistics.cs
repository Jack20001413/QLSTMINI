using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Application.DTOs
{
    public class RevenueStatistics
    {
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime? currentDate {get;set;}

        [DisplayFormat(DataFormatString = "{0:MM-yyyy-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime? startDate {get;set;}
       

        [DisplayFormat(DataFormatString = "{0:MM-yyyy-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime? endDate {get;set;}

        public IEnumerable<SellingOrderDto> sellingOrders{get;set;}
    }
}