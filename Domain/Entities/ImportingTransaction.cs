using Domain.Entities.Common;

namespace Domain.Entities
{
    public class ImportingTransaction : IAggregateRoot
    {
        public int Id { get; set; }

        public int ImportingOrderId { get; set; }
        public ImportingOrder ImportingOrder { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }

        public int Quantity { get; set; }
        public int UnitPrice { get; set; }
        public int TotalPrice { get; set; }
    }
}