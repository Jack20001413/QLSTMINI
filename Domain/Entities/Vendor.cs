using System;
using Domain.Entities.Common;

namespace Domain.Entities
{
    public class Vendor : IAggregateRoot
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
    }
}