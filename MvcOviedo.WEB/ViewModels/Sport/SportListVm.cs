using System.ComponentModel;

namespace MvcOviedo.WEB.ViewModels.Sport
{
    public class SportListVm
    {
        public int SportId { get; set; }

        [DisplayName("Deportes")]
        public string? SportName { get; set; }

    }
}
