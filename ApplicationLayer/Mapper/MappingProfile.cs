using AutoMapper;
using MahalShop.Core.Dtos;
using MahalShop.Core.Entities;

namespace MahalShop.ApplicationLayer.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //   category الي  dto هيحول من  
            CreateMap<CategoryDto, Category>().ReverseMap();
            CreateMap<UpdateCategoryDto, Category>().ReverseMap();
            // for GetAll And GetById
            CreateMap<Product, ProductDto>().ForMember(dest =>
                        dest.CategoryName,
                        op =>
                        op.MapFrom(src => src.Category.Name)).ReverseMap();
            CreateMap<Photo, PhotoDto>().ReverseMap();
            // for Add And Update Product
            CreateMap<AddProductDto, Product>()
                .ForMember(x => x.Photos, op => op.Ignore())
                .ReverseMap();

            // for Update Product
            CreateMap<UpdateProductDto, Product>()
                .ForMember(x => x.Photos, op => op.Ignore())
                .ReverseMap();


        }
    }
}
