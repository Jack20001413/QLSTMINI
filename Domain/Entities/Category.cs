using System;
using Domain.Entities.Common;

namespace Domain.Entities
{
    public class Category : IAggregateRoot
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}