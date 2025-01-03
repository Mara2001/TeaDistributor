namespace TeaDistributor.Models
{
    public class TeaItem
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public TeaType Type { get; set; } = null!;
        public TeaRegion Region { get; set; } = null!;
        public string Quality { get; set; } = null!;
        public TeaSupplier Supplier { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string SteepingTime { get; set; } = null!;

    }
}
