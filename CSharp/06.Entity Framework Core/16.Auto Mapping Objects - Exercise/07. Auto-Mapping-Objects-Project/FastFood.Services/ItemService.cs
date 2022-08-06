using AutoMapper;
using AutoMapper.QueryableExtensions;
using FastFood.Data;
using FastFood.Models;
using FastFood.Services.Contracts;
using FastFood.Services.Models.Items;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastFood.Services
{


    public class ItemService : IItemService
    {
        private readonly FastFoodContext context;
        private readonly IMapper mapper;

        public ItemService(FastFoodContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task AddAsync(CreateItemDto itemDto)
        {
            var item = this.mapper.Map<Item>(itemDto);
            await this.context.Items.AddAsync(item);
            await this.context.SaveChangesAsync();
        }

        public async Task<ICollection<ListItemDto>> GetAllAsync()
        {
            ICollection<ListItemDto> items = await this.context
                .Items
                .ProjectTo<ListItemDto>(this.mapper.ConfigurationProvider)
                .ToListAsync();
            return items;
        }
    }
}
