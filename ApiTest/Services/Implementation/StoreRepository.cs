using ApiTest.Data;
using ApiTest.Models;
using ApiTest.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ApiTest.Services.Implementation;

public class StoreRepository(ApplicationDbContext context) : IStoreRepository
{
    #region Adding new product

    public async Task AddProductAsync(Product product)
    {
        context.Products.Add(product);
        await context.SaveChangesAsync();
    }

    #endregion

    #region Adding new products

    public async Task AddCategoryAsync(Category category)
    {
        context.Categories.Add(category);
        await context.SaveChangesAsync();
    }

    #endregion

    #region Get all products without categories

    public async Task<IReadOnlyList<ProductDto>> GetAllProductsAsync()
    {
        return context.Products.Any()
            ? await context.Products
                .Include(p => p.Category)
                .AsNoTracking()
                .Select(p => new ProductDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    Description = p.Description,
                    Price = p.Price,
                    Quantity = p.Quantity,
                    CategoryName = p.Category.Name,
                }).ToListAsync()
            : null;
    }

    #endregion

    #region Get product with id

    public async Task<ProductDto> GetProductById(int productId)
    {
        return await context.Products
            .Include(p => p.Category)
            .Where(p => p.Id == productId)
            .AsNoTracking()
            .Select(p => new ProductDto
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
                Price = p.Price,
                Quantity = p.Quantity,
                CategoryName = p.Category.Name,
            })
            .FirstOrDefaultAsync();
    }

    #endregion

    #region Get all categories

    public async Task<IReadOnlyList<CategoryDto>> GetAllCategoriesAsync()
    {
        return context.Categories.Any()
            ? await context.Categories
                .AsNoTracking()
                .Select(c => new CategoryDto
                {
                    Id = c.Id,
                    Name = c.Name,
                    Description = c.Description
                })
                .ToListAsync()
            : null;
    }

    #endregion

    #region Get category with id

    public async Task<CategoryDto> GetCategoryByIdAsync(int categoryId)
    {
        return await context.Categories
            .Where(c => c.Id == categoryId)
            .AsNoTracking()
            .Select(c => new CategoryDto
            {
                Id = c.Id,
                Name = c.Name,
                Description = c.Description
            })
            .FirstOrDefaultAsync();
    }

    #endregion

    #region Remove product with id

    public async Task RemoveProductByIdAsync(int id)
    {
        var productToRemove = await context.Products
            .FirstOrDefaultAsync(p => p.Id == id);

        if (productToRemove == null)
        {
            throw new KeyNotFoundException($"Product with ID {id} not found.");
        }

        context.Products.Remove(productToRemove);
        await context.SaveChangesAsync();
    }

    #endregion

    #region Remove category by id

    public async Task RemoveCategoryByIdAsync(int id)
    {
        var categoryToRemove = await context.Categories
            .Include(c => c.Products)
            .FirstOrDefaultAsync(c => c.Id == id);

        if (categoryToRemove == null)
        {
            throw new KeyNotFoundException($"Category with ID {id} not found.");
        }

        context.Products.RemoveRange(categoryToRemove.Products);

        context.Categories.Remove(categoryToRemove);
        await context.SaveChangesAsync();
    }

    #endregion

    #region Update product

    public async Task UpdateProductAsync(int id, ProductUpdateDto product)
    {
        var productToUpdate = await context.Products
            .FirstOrDefaultAsync(p => p.Id == id);

        if (productToUpdate == null)
        {
            throw new KeyNotFoundException($"Product with ID {id} does not exist.");
        }

        var categoryExists = await context.Categories.AnyAsync(c => c.Id == product.CategoryId);

        if (!categoryExists)
        {
            throw new KeyNotFoundException($"Category with ID {product.CategoryId} does not exist.");
        }

        if (string.IsNullOrEmpty(product.Name) || product.Price <= 0)
        {
            throw new ArgumentException("Product name cannot be empty and price must be greater than zero.");
        }

        productToUpdate.Name = product.Name;
        productToUpdate.Description = product.Description;
        productToUpdate.Price = product.Price;
        productToUpdate.Quantity = product.Quantity;
        productToUpdate.CategoryId = product.CategoryId;

        await context.SaveChangesAsync();
    }

    #endregion

    #region Update category

    public async Task UpdateCategoryAsync(Category category)
    {
        var categoryToUpdate = await context.Categories.FirstOrDefaultAsync(c => c.Id == category.Id);

        if (categoryToUpdate == null)
        {
            throw new KeyNotFoundException($"Category with ID {category.Id} does not exist.");
        }

        if (string.IsNullOrEmpty(category.Name))
        {
            throw new ArgumentException("Category name cannot be empty.");
        }

        categoryToUpdate.Name = category.Name;
        categoryToUpdate.Description = category.Description;

        await context.SaveChangesAsync();
    }

    #endregion
}