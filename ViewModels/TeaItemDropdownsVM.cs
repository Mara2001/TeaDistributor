using TeaDistributor.Models;

namespace TeaDistributor.ViewModels
{
    public class TeaItemDropdownsVM
    {
        public List<TeaType> Types { get; set; }
        public List<TeaRegion> Regions { get; set; }
        public List<TeaSupplier> Suppliers { get; set; }
        public TeaItemDropdownsVM()
        {
            Types = new List<TeaType>();
            Regions = new List<TeaRegion>();
            Suppliers = new List<TeaSupplier>();
        }
    }
}
