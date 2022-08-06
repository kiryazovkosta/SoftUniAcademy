using AutoMapper;
using ProductShop.Dtos.Category;
using ProductShop.Dtos.CategoryProduct;
using ProductShop.Dtos.Product;
using ProductShop.Dtos.User;
using ProductShop.Models;
using System.Linq;

namespace ProductShop
{
    public class ProductShopProfile : Profile
    {
        public ProductShopProfile()
        {
            this.CreateMap<ImportUserDto, User>();
            this.CreateMap<ImportProductDto, Product>();
            this.CreateMap<ImportCategoryDto, Category>();
            this.CreateMap<ImportCategoryProductDto, CategoryProduct>();

            this.CreateMap<Product, ExportProductDto>()
                .ForMember(d => d.Seller, mo => mo.MapFrom(s => $"{s.Seller.FirstName} {s.Seller.LastName}"));

            this.CreateMap<Product, ExportUserSoldProductsDto>()
                .ForMember(d => d.BuyerFirstName, mo => mo.MapFrom(s => s.Buyer.FirstName))
                .ForMember(d => d.BuyerLastName, mo => mo.MapFrom(s => s.Buyer.LastName));
            this.CreateMap<User, ExportUsersWithSoldProductDto>()
                .ForMember(d => d.Products, mo => mo.MapFrom(s => s.ProductsSold.Where(p => p.BuyerId.HasValue)));

            this.CreateMap<Category, ViewCategodyDataDto>()
                .ForMember(d => d.ProductsCount, mo => mo.MapFrom(s => s.CategoryProducts.Count))
                .ForMember(d => d.AveragePrice, mo => mo.MapFrom(s => s.CategoryProducts.Average(cp => cp.Product.Price).ToString("F2")))
                .ForMember(d => d.TotalRevenue, mo => mo.MapFrom(s => s.CategoryProducts.Sum(cp => cp.Product.Price).ToString("F2")));


            this.CreateMap<Product, SoldProductDto>();
            this.CreateMap<User, UserListDto>()
                .ForMember(d => d.SoldProducts, mo => mo.MapFrom(s => s.ProductsSold.Where(p => p.BuyerId.HasValue)));
            this.CreateMap<User, UsersAllListDto>()
                .ForMember(d => d.Users, mo => mo.MapFrom(s => s));
        }
    }
}
