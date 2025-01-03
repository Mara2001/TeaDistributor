namespace TeaDistributor.Models
{
    public class TeaOrder
    {
        public int Id { get; set; }
        public TeaCustomer? Customer { get; set; }
        public DateOnly Date { get; set; }
        public string? Note { get; set; }
        public TeaInvoice? Invoice { get; set; }

    }
}
