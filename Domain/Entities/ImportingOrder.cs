using System;
using System.Collections.Generic;
using Domain.Entities.Common;

namespace Domain.Entities
{
    public class ImportingOrder : IAggregateRoot
    {
        public int Id { get; set; }

        public int VendorId { get; set; }
        public virtual Vendor Vendor { get; set; }

        public int EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }
        public string NameCode { get; set; }
        public int TotalPrice { get; set; }
        public DateTime CreatedDate { get; set; }
        public int Status { get; set; }
        

        public virtual ICollection<ImportingTransaction> ImportingTransactions { get; set; }
    }
}