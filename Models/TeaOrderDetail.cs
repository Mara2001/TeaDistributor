namespace TeaDistributor.Models
{
    public class TeaOrderDetail
    {
        public int Id { get; set; }
        public TeaOrder? Order {  get; set; }
        public TeaBatch? Batch { get; set; }
        public int Amount { get; set; }
        public decimal Price { get; set; }

    }
}
