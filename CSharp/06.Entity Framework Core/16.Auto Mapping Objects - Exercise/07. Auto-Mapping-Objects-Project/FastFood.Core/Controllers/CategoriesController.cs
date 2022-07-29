namespace FastFood.Core.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using AutoMapper;
    using Data;
    using FastFood.Services.Contracts;
    using FastFood.Services.Models.Categories;
    using Microsoft.AspNetCore.Mvc;
    using ViewModels.Categories;

    public class CategoriesController : Controller
    {
        private readonly IMapper mapper;
        private readonly ICategoryService categoryService;

        public CategoriesController(ICategoryService categoryServiceParam, IMapper mapperParam)
        {
            this.mapper = mapperParam ?? throw new ArgumentNullException(nameof(mapper));
            this.categoryService = categoryServiceParam ?? throw new ArgumentNullException(nameof(categoryService));
        }

        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCategoryInputModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.RedirectToAction("Create", "Categories");
            }

            CreateCategoryDto categoryDto = this.mapper.Map<CreateCategoryDto>(model);
            await this.categoryService.AddAsync(categoryDto);

            return this.RedirectToAction("All", "Categories");
        }

        public async Task<IActionResult> All()
        {
            ICollection<ListCategoryDto> categoryDtos =  await this.categoryService.GetAllAsync();
            ICollection<CategoryAllViewModel> categories = new List<CategoryAllViewModel>();
            foreach (var categoryDto in categoryDtos)
            {
                categories.Add(this.mapper.Map<CategoryAllViewModel>(categoryDto));
            }

            return this.View(categories);
        }
    }
}
