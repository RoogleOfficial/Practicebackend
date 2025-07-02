using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Practice.Application.DTOs;
using Practice.Domain.Entities;

namespace Practice.Application.Mappings
{
    public class AutoMappingProfile:Profile
    {
        public AutoMappingProfile()
        {
            // Brand -> BrandDto (with ProductNames)
            CreateMap<Brand, BrandDto>()
                .ForMember(dest => dest.ProductNames,
                    opt => opt.MapFrom(src => src.Products.Select(p => p.Name).ToList()));

            CreateMap<BrandDto, Brand>();

            CreateMap<CUBrandDto, Brand>().ReverseMap();

            //// Category -> CategoryDto (with ProductIds)
            //CreateMap<Category, CategoryDto>()
            //    .ForMember(dest => dest.ProductIds,
            //        opt => opt.MapFrom(src => src.products.Select(p => p.Id).ToList()));

            // Optional: Category with ProductNames instead of IDs
            CreateMap<Category, CategoryDto>() // overload if using ProductNames instead
                .ForMember(dest => dest.ProductNames,
                    opt => opt.MapFrom(src => src.products.Select(p => p.Name).ToList()));

            CreateMap<CategoryDto, Category>();

            CreateMap<CUCategoryDto, Category>().ReverseMap();

            // Product -> ProductDto (basic mapping if needed)
            CreateMap<Product, ProductDto>()
                .ForMember(dest => dest.CategoryIds,
                    opt => opt.MapFrom(src => src.Categories.Select(c => c.Id).ToList()));
                
            CreateMap<ProductDto, Product>();
        }
    }
}
