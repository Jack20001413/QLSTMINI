using System;
using System.Collections;
using System.Collections.Generic;
using Domain.Entities.Common;

namespace Domain.Entities
{
    public class EmployeeGroup : IAggregateRoot
    {
        public int Id { get; set; }
        public string Name { get; set; }
        //public virtual ICollection<Employee> Employees { get; set; }
    }
}