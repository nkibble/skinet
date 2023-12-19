using API.Dtos;
using AutoMapper;
using Core.Entities;

namespace API.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            // Mapping between Product to ProductToReturnDto, with destination overrides to ensure
            // we pull the name strings from the Product Brand and Product Type, and also fully resolve the product image url.
            // d is the Destination (ProductToReturDto) member to reference.
            // o is the override method
            // s is the source.
            CreateMap<Product, ProductToReturnDto>()
                .ForMember(d => d.ProductBrand, o => o.MapFrom(s => s.ProductBrand.Name))
                .ForMember(d => d.ProductType, o => o.MapFrom(s => s.ProductType.Name))
                .ForMember(d => d.PictureUrl, o => o.MapFrom<ProductUrlResolver>());
        }
    }
}