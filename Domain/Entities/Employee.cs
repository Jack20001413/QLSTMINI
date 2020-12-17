using System;
using System.Collections.Generic;
using Domain.Entities.Common;

namespace Domain.Entities
{
    public class Employee :EntityBase, IAggregateRoot
    {
        //public int Id { get; set; }

        public string Fullname { get; set; }
        public string FullnameSlug { get; set; }
        public string CardId { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
        public DateTime BirthDate { get; set; }
        public int EmployeeGroupId { get; set; }
        public EmployeeGroup EmployeeGroup { get; set; }
        
        //public virtual ICollection<ImportingOrder> ImportingOrders { get; set; }
    }
}