using AutoMapper;
using AutoMapper.QueryableExtensions;
using FastFood.Data;
using FastFood.Models;
using FastFood.Services.Contracts;
using FastFood.Services.Models.Categories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastFood.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly FastFoodContext context;
        private readonly IMapper mapper;

        public CategoryService(FastFoodContext contextParam, IMapper mapperParam)
        {
            this.context = contextParam ?? throw new ArgumentNullException(nameof(contextParam));
            this.mapper = mapperParam ?? throw new ArgumentNullException(nameof(mapperParam));
        }

        public async Task AddAsync(CreateCategoryDto categoryDto)
        {
            Category category = this.mapper.Map<Category>(categoryDto);
            await this.context.AddAsync(category);
            await this.context.SaveChangesAsync();
        }

        public async Task<ICollection<ListCategoryDto>> GetAllAsync()
        {
            ICollection<ListCategoryDto> categories = await this.context.Categories
                .ProjectTo<ListCategoryDto>(this.mapper.ConfigurationProvider)
                .ToArrayAsync();
            return categories;
        }

        public async Task<bool> ExistsById(int id)
        {
            return await this.context.Categories.AnyAsync(c => c.Id == id);
        }
    }
}
