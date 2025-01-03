namespace TeaDistributor.Models
{
    public class TeaInvoice
    {
        public int Id { get; set; }
        public DateOnly Date {  get; set; }
        public decimal TotalPrice { get; set; }
    }
}
