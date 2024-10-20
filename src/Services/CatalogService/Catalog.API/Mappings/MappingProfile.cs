using AutoMapper;
using Catalog.API.Models;
using Product.Contracts.Events;

namespace Catalog.API.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Entities.Product, CreateProductModel>().ReverseMap();
            CreateMap<Entities.Product, ProductCreated>().ReverseMap();
        }
    }
}
