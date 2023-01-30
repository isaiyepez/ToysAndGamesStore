using AutoMapper;
using ToysAndGamesAPI.DTOs;
using ToysAndGamesAPI.Entities;

namespace ToysAndGamesAPI.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles() 
        {
            CreateMap<Product, ProductDTO>()
                .ForMember(dest => dest.ImageFile,
                            opt => opt.MapFrom(src => src.ProductImage.ImageFile))
                .ForMember(dest => dest.ImageName,
                            opt => opt.MapFrom(src => src.ProductImage.ImageName))
                .ForMember(dest => dest.ProductImageId,
                            opt => opt.MapFrom(src => src.ProductImage.Id));
            CreateMap<ProductImage, ProductImageDTO>();

            CreateMap<ProductDTO, Product>()
                .ForPath(dest => dest.ProductImage.ImageFile,
                            opt => opt.MapFrom(src => src.ImageFile))
                .ForPath(dest => dest.ProductImage.ImageName,
                            opt => opt.MapFrom(src => src.ImageName))
                .ForPath(dest => dest.ProductImage.Id,
                            opt => opt.MapFrom(src => src.ProductImageId));
            CreateMap<ProductImageDTO, ProductImage>();
        }
    }
}
