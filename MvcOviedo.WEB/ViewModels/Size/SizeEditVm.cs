using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace MvcOviedo.WEB.ViewModels.Size
{
    public class SizeEditVm
    {
        public int SizeId { get; set; }
        [Required(ErrorMessage = "{0} este campo es requerido")]
        [Range(20, 60, ErrorMessage = "El talle debe ser un número entre 20 y 60")]
        [DisplayName("Talles")]
        public decimal? SizeNumber { get; set; }

    }
}
