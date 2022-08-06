namespace FastFood.Services.Contracts
{
    using FastFood.Services.Models.Categories;
    public interface ICategoryService
    {
        Task AddAsync(CreateCategoryDto categoryDto);

        Task<ICollection<ListCategoryDto>> GetAllAsync();

        Task<bool> ExistsById(int id);
    }
}
