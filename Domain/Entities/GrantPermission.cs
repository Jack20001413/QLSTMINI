using Domain.Entities.Common;

namespace Domain.Entities
{
    public class GrantPermission : IAggregateRoot
    {
        public int Id { get; set; }

        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }

        public int PermissionId { get; set; }
        public Permission Permission { get; set; }
    }
}