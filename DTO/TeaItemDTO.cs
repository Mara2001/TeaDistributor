using TeaDistributor.Models;

namespace TeaDistributor.DTO
{
    public class TeaItemDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int TypeId { get; set; }
        public int RegionId { get; set; }
        public string? Quality { get; set; }
        public int SupplierId { get; set; }
        public string? Description { get; set; }
        public string? SteepingTime { get; set; }
    }
}
