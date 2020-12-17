using Domain.Entities.Common;

namespace Domain.Entities
{
    public class Permission : IAggregateRoot
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}