using ApiTest.Models;
using ApiTest.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoreController(IStoreRepository storeRepository) : ControllerBase
    {
        [HttpPost("/create/product")]

        #region Adding new product

        public async Task<IActionResult> NewProduct([FromBody] Product product)
        {
            if (product == null) return BadRequest("you cannot add product with null data.");

            if (!ModelState.IsValid) return BadRequest(ModelState);

            try
            {
                await storeRepository.AddProductAsync(product);
                return CreatedAtAction(nameof(NewProduct), product);
            }
            catch (DbUpdateException e)
            {
                return StatusCode(500, "Database error: " + e.Message);
            }
            catch (Exception e)
            {
                return StatusCode(500, "An unexpected error occurred: " + e.Message);
            }
        }

        #endregion

        [HttpPost("/create/category")]

        #region Adding new category

        public async Task<IActionResult> NewCategory([FromBody] Category category)
        {
            if (category == null) return BadRequest("Category can't be null.");

            if (!ModelState.IsValid) return BadRequest(ModelState);

            try
            {
                await storeRepository.AddCategoryAsync(category);
                return CreatedAtAction(nameof(NewProduct), category);
            }
            catch (DbUpdateException e)
            {
                return StatusCode(500, "Database error: " + e.Message);
            }
            catch (InvalidDataException e)
            {
                return StatusCode(500, "An unexpected error occurred: " + e.Message);
            }
        }

        #endregion

        [HttpGet("/get/all-products")]

        #region Get all products

        public async Task<IActionResult> GetAllProducts()
        {
            return await storeRepository.GetAllProductsAsync() == null
                ? NotFound("no products found.")
                : Ok(await storeRepository.GetAllProductsAsync());
        }

        #endregion

        [HttpGet("/get/product/{id:int}")]

        #region Get product by id

        public async Task<IActionResult> GetProduct([FromRoute] int id)
        {
            try
            {
                var product = await storeRepository.GetProductById(id);
                if (product == null) return NotFound($"Product with ID {id} not found.");
                return Ok(product);
            }
            catch (InvalidDataException e)
            {
                return BadRequest("An unexpected error occurred: " + e.Message);
            }
        }

        #endregion

        [HttpGet("/get/all-categories")]

        #region Get categories

        public async Task<IActionResult> GetAllCategories()
        {
            return await storeRepository.GetAllCategoriesAsync() == null
                ? NotFound("there are no categories found.")
                : Ok(await storeRepository.GetAllCategoriesAsync());
        }

        #endregion

        [HttpGet("/get/category/{id:int}")]

        #region Get category by id

        public async Task<IActionResult> GetCategory(int id)
        {
            var category = await storeRepository.GetCategoryByIdAsync(id);
            if (category == null)
                return NotFound($"Category with ID {id} not found.");

            return Ok(category);
        }

        #endregion

        [HttpDelete("/delete/product/{id:int}")]

        #region Delete product

        public async Task<IActionResult> DeleteProduct(int id)
        {
            try
            {
                await storeRepository.RemoveProductByIdAsync(id);
                return Ok($"Product with ID {id} has been deleted.");
            }
            catch (KeyNotFoundException e)
            {
                return NotFound(e.Message);
            }
            catch (Exception e)
            {
                return StatusCode(500, "An unexpected error occurred: " + e.Message); // Handle any unexpected errors
            }
        }

        #endregion

        [HttpDelete("/delete/category/{id:int}")]

        #region Delete category by id

        public async Task<IActionResult> DeleteCategory(int id)
        {
            try
            {
                await storeRepository.RemoveCategoryByIdAsync(id);
                return NoContent();
            }
            catch (KeyNotFoundException e)
            {
                return NotFound(e.Message);
            }
            catch (Exception e)
            {
                return StatusCode(500, "An unexpected error occurred: " + e.Message); // Handle other errors
            }
        }

        #endregion

        [HttpPut("/update/product/{id:int}")]

        #region Update product

        public async Task<IActionResult> UpdateProduct(int id, ProductUpdateDto product)
        {
            if (product == null || !ModelState.IsValid)
            {
                return BadRequest("Invalid data provided.");
            }

            try
            {
                await storeRepository.UpdateProductAsync(id, product);
                return NoContent();
            }
            catch (KeyNotFoundException e)
            {
                return NotFound(e.Message);
            }
            catch (ArgumentException e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception e)
            {
                return StatusCode(500, "An unexpected error occurred: " + e.Message);
            }
        }

        #endregion

        [HttpPut("/update/category")]

        #region Update category

        public async Task<IActionResult> UpdateCategory(Category category)
        {
            if (category == null || !ModelState.IsValid)
            {
                return BadRequest("Invalid category data.");
            }

            try
            {
                await storeRepository.UpdateCategoryAsync(category);
                return NoContent();
            }
            catch (KeyNotFoundException e)
            {
                return NotFound(e.Message);
            }
            catch (ArgumentException e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception e)
            {
                return StatusCode(500, "An unexpected error occurred: " + e.Message);
            }
        }

        #endregion
    }
}