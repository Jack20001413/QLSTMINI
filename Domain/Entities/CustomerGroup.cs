using System;
using System.Collections.Generic;
using Domain.Entities.Common;

namespace Domain.Entities
{
    public class CustomerGroup : IAggregateRoot
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Customer> Customers { get; set; }
    }
}