using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MvcOviedo.WEB.ViewModels.Brand
{
    public class BrandEditVm
    {
        public int BrandId { get; set; }
        [Required(ErrorMessage = "{0} este campo es requerido")]
        [StringLength(200, ErrorMessage = "{0} debe tener entre {2}" +
            " y {1} caracteres", MinimumLength = 3)]
        [DisplayName("Marcas")]
        public string? BrandName { get; set; }

    }
}
