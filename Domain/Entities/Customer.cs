using System;
using Domain.Entities.Common;

namespace Domain.Entities
{
    public class Customer : IAggregateRoot
    {
        public int Id { get; set; }
        public string Fullname { get; set; }
        public string FullnameSlug { get; set; }
        public string CardId { get; set; }
        public string Email { get; set; }
        public string CardNumber { get; set; }
        public string Phone { get; set; }
        public DateTime BirthDate { get; set; }
        public string Address { get; set; }

        public int CustomerGroupId { get; set; }
        public virtual CustomerGroup CustomerGroup { get; set; }
    }
}