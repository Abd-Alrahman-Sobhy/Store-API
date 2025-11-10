using System.ComponentModel.DataAnnotations;

namespace ApiTest.Models;

public class Category
{
    [Key] public uint Id { get; set; }

    [Required(ErrorMessage = "category name is required.")]
    [StringLength(100, ErrorMessage = "category name cannot be longer than 100 characters.")]
    public string Name { get; set; }

    [Required(ErrorMessage = "category description is required.")]
    [StringLength(500, ErrorMessage = "category description cannot be longer than 500 characters.")]
    public string Description { get; set; }

    public ICollection<Product> Products { get; set; }
}