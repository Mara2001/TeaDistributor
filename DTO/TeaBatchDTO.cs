using TeaDistributor.Models;

namespace TeaDistributor.DTO
{
    public class TeaBatchDTO
    {
        public int Id { get; set; }
        public int TeaId { get; set; }
        public DateOnly Date { get; set; }
        public int Amount { get; set; }
        public int Price { get; set; }
        public int DiscountedPrice { get; set; }
    }
}
