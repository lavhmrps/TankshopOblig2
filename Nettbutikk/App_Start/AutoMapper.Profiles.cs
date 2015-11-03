using AutoMapper;
using Nettbutikk.Model;
using Nettbutikk.Models;

namespace Nettbutikk
{
    public static class AutoMapperProfiles
    {
        public static void Configure()
        {
            Mapper.Initialize(config =>
            {
                config.AddProfile<ProductsProfile>();
                config.AddProfile<CategoriesProfile>();
            });
        }

        private class CategoriesProfile : Profile
        {
            protected override void Configure()
            {
                Mapper.CreateMap<Category, CategoryView>();
                Mapper.CreateMap<CategoryView, Category>();
                Mapper.CreateMap<Category, CreateCategory>();
                Mapper.CreateMap<CreateCategory, Category>();
                Mapper.CreateMap<Category, EditCategory>();
                Mapper.CreateMap<EditCategory, Category>();
            }
        }

        private class ProductsProfile : Profile
        {
            protected override void Configure()
            {
                Mapper.CreateMap<Product, ProductView>();
                Mapper.CreateMap<ProductView, Product>();
                Mapper.CreateMap<Product, CreateProduct>();
                Mapper.CreateMap<CreateProduct, Product>();
                Mapper.CreateMap<Product, EditProduct>();
                Mapper.CreateMap<EditProduct, Product>();
            }
        }
    }
}