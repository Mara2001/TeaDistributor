using TeaDistributor.Models;

namespace TeaDistributor.DTO
{
    public class TeaOrderDetailsDTO
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public DateOnly Date { get; set; }
        public string? Note { get; set; }
        public int InvoiceId { get; set; }
    }
}
