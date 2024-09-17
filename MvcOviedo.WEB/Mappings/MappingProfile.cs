using AutoMapper;
using MvcOviedo.Entidades;
using MvcOviedo.WEB.ViewModels.Brand;
using MvcOviedo.WEB.ViewModels.Colour;
using MvcOviedo.WEB.ViewModels.Genre;
using MvcOviedo.WEB.ViewModels.Size;
using MvcOviedo.WEB.ViewModels.Sport;

namespace MvcOviedo.WEB.Mappings
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            LoadMappingBrand();
            LoadMappingGenre();
            LoadMappingColour();
            LoadMappingSport();
            LoadMappingSize();


        }

        private void LoadMappingSize()
        {
            CreateMap<Size, SizeListVm>();
            CreateMap<Size, SizeEditVm>().ReverseMap();

        }

        private void LoadMappingSport()
        {
            CreateMap<Sport, SportListVm>();
            CreateMap<Sport, SportEditVm>().ReverseMap();
        }

        private void LoadMappingColour()
        {
            CreateMap<Colour, ColourListVm>();
            CreateMap<Colour, ColourEditVm>().ReverseMap();
        }

        private void LoadMappingGenre()
        {
            CreateMap<Genre, GenreListVm>();
            CreateMap<Genre, GenreEditVm>().ReverseMap();
        }

        private void LoadMappingBrand()
        {
            CreateMap<Brand, BrandListVm>();
            CreateMap<Brand, BrandEditVm>().ReverseMap();
        }
    }
}
