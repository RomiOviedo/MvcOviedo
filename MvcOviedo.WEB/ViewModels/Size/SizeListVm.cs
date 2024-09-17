using System.ComponentModel;

namespace MvcOviedo.WEB.ViewModels.Size
{
    public class SizeListVm
    {
        public int SizeId { get; set; }
        [DisplayName("Talles")]
        public decimal? SizeNumber { get; set; }

    }
}
