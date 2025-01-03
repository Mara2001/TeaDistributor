namespace TeaDistributor.DTO
{
    public class TeaInvoiceDTO
    {
        public int Id { get; set; }
        public DateOnly Date { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
