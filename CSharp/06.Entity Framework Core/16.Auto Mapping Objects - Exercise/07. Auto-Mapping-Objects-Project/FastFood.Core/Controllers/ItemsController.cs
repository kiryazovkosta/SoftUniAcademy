namespace FastFood.Core.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Data;
    using FastFood.Services.Contracts;
    using FastFood.Services.Models.Items;
    using Microsoft.AspNetCore.Mvc;
    using ViewModels.Items;

    public class ItemsController : Controller
    {
        private readonly IMapper mapper;
        private readonly ICategoryService categoryService;
        private readonly IItemService itemService;

        public ItemsController(IMapper mapperParam
            ,ICategoryService categoryServiceParam
            ,IItemService itemService)
        {
            this.mapper = mapperParam;
            this.categoryService = categoryServiceParam;
            this.itemService = itemService;
        }

        public async Task<IActionResult> Create()
        {
            var categories = await this.categoryService.GetAllAsync();
            var items = new List<CreateItemViewModel>();
            foreach (var category in categories)
            {
                items.Add(this.mapper.Map<CreateItemViewModel>(category));
            }

            return this.View(items);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateItemInputModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.RedirectToAction("Create", "Items");
            }

            bool isValidCategory = await this.categoryService.ExistsById(model.CategoryId);
            if (!isValidCategory)
            {
                return this.RedirectToAction("Create", "Items");
            }

            CreateItemDto itemDto = this.mapper.Map<CreateItemDto>(model);
            await this.itemService.AddAsync(itemDto);
            return this.RedirectToAction("All", "Items");
        }

        public async Task<IActionResult> All()
        {
            var itemsDtos = await this.itemService.GetAllAsync();
            var items = new List<ItemsAllViewModels>();
            foreach (var itemDto in itemsDtos)
            {
                items.Add(this.mapper.Map<ItemsAllViewModels>(itemDto));
            }

            return this.View(items);
        }
    }
}
