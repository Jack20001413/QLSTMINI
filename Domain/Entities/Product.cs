using System;
using Domain.Entities.Common;

namespace Domain.Entities
{
    public class Product : IAggregateRoot
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Unit { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public int BrandId { get; set; }
        public Brand Brand { get; set; }

        public string OrgCode { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public int ImportPrice { get; set; }
        public int SalePrice { get; set; }
    }
}