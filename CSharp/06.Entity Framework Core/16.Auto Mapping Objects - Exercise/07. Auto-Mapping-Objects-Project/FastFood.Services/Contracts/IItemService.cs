using FastFood.Services.Models.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastFood.Services.Contracts
{
    public interface IItemService
    {
        Task AddAsync(CreateItemDto itemDto);

        Task<ICollection<ListItemDto>> GetAllAsync();
    }
}
