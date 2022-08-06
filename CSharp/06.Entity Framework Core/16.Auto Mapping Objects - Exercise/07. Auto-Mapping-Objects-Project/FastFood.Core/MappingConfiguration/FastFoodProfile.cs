namespace FastFood.Core.MappingConfiguration
{
    using AutoMapper;
    using FastFood.Core.ViewModels.Categories;
    using FastFood.Core.ViewModels.Items;
    using FastFood.Models;
    using FastFood.Services.Models.Categories;
    using FastFood.Services.Models.Items;
    using ViewModels.Positions;

    public class FastFoodProfile : Profile
    {
        public FastFoodProfile()
        {
            //Positions
            this.CreateMap<CreatePositionInputModel, Position>()
                .ForMember(x => x.Name, y => y.MapFrom(s => s.PositionName));

            this.CreateMap<Position, PositionsAllViewModel>()
                .ForMember(x => x.Name, y => y.MapFrom(s => s.Name));

            // Categories
            this.CreateMap<CreateCategoryDto, Category>();
            this.CreateMap<CreateCategoryInputModel, CreateCategoryDto>()
                .ForMember(destination => destination.Name, map => map.MapFrom(source => source.CategoryName));
            this.CreateMap<Category, ListCategoryDto>();
            this.CreateMap<ListCategoryDto, CategoryAllViewModel>();

            // Items 
            this.CreateMap<ListCategoryDto, CreateItemViewModel>()
                .ForMember(d => d.CategoryId, mo => mo.MapFrom(s => s.Id))
                .ForMember(d => d.CategoryName, mo => mo.MapFrom(s => s.Name));
            this.CreateMap<CreateItemInputModel, CreateItemDto>();
            this.CreateMap<CreateItemDto, Item>();
            this.CreateMap<Item, ListItemDto>()
                .ForMember(d => d.Category, mo => mo.MapFrom(s => s.Category.Name));
            this.CreateMap<ListItemDto, ItemsAllViewModels>();
        }
    }
}
