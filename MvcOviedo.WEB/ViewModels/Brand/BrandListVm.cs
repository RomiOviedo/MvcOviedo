using System.ComponentModel;

namespace MvcOviedo.WEB.ViewModels.Brand
{
    public class BrandListVm
    {
        public int BrandId { get; set; }
        [DisplayName("Marcas")]
        public string? BrandName { get; set; }
    }
}
