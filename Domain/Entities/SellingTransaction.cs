using Domain.Entities.Common;

namespace Domain.Entities
{
    public class SellingTransaction : IAggregateRoot
    {
        public int Id { get; set; }

        public int SellingOrderId { get; set; }
        public SellingOrder SellingOrder { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }
        
        public int Quantity { get; set; }
        public int UnitPrice { get; set; }
        public int TotalPrice { get; set; }
    }
}