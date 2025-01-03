namespace TeaDistributor.Models
{
    public class TeaBatch
    {
        public int Id { get; set; }
        public TeaItem? Tea { get; set; }
        public DateOnly Date { get; set; }
        public int Amount { get; set; }
        public int Price { get; set; }
        public int DiscountedPrice { get; set; }
    }
}
