using ApiTest.Models;

namespace ApiTest.Services.Interfaces;

public interface IStoreRepository
{
    public Task AddProductAsync(Product product);
    public Task AddCategoryAsync(Category category);
    public Task<IReadOnlyList<ProductDto>> GetAllProductsAsync();
    public Task<ProductDto> GetProductById(int id);
    public Task<IReadOnlyList<CategoryDto>> GetAllCategoriesAsync();
    public Task<CategoryDto> GetCategoryByIdAsync(int id);
    public Task RemoveProductByIdAsync(int id);
    public Task RemoveCategoryByIdAsync(int id);
    public Task UpdateProductAsync(int id, ProductUpdateDto product);
    public Task UpdateCategoryAsync(Category category);
}