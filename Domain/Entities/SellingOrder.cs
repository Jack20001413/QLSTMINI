using System;
using System.Collections.Generic;
using Domain.Entities.Common;

namespace Domain.Entities
{
    public class SellingOrder : IAggregateRoot
    {
        public int Id { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }

        public virtual ICollection<SellingTransaction> SellingTransactions { get; set; }
        
        public int TotalPrice { get; set; }
        public DateTime CreatedDate { get; set; }
        public int Status { get; set; }
        public string NameCode { get; set; }
    }
}