namespace BookShop
{
    using AutoMapper;
    using BookShop.Common;
    using BookShop.Data.Models;
    using BookShop.Data.Models.Enums;
    using BookShop.DataProcessor.ImportDto;
    using System;
    using System.Globalization;

    public class BookShopProfile : Profile
    {
        public BookShopProfile()
        {
            this.CreateMap<BookInputModel, Book>()
                .ForMember(d => d.Genre, mo => mo.MapFrom(s => Enum.Parse<Genre>(s.Genre.ToString())))
                .ForMember(d => d.PublishedOn, mo => mo.MapFrom(s => DateTime.ParseExact(s.PublishedOn, GlobalConstants.BookReleasedOnFormat, CultureInfo.InvariantCulture)));

            this.CreateMap<AuthorInputModel, Author>();
        }
    }
}
