using System.ComponentModel;

namespace MvcOviedo.WEB.ViewModels.Genre
{
    public class GenreListVm
    {
        public int GenreId { get; set; }
        [DisplayName("Generos")]
        public string? GenreName { get; set; }
    }
}

