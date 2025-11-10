using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiTest.Models;

public class Product
{
    [Key] public uint Id { get; set; }

    [Required(ErrorMessage = "Product name is required.")]
    [StringLength(100, ErrorMessage = "Product name cannot be longer than 100 characters.")]
    public string Name { get; set; }

    [Required(ErrorMessage = "Product description is required.")]
    [StringLength(500, ErrorMessage = "Product description cannot be longer than 500 characters.")]
    public string Description { get; set; }

    [Required(ErrorMessage = "Product price is required.")]
    [Column(TypeName = "decimal(7,2)")]
    public decimal Price { get; set; }

    [Required(ErrorMessage = "Product Quantity is required.")]
    public uint Quantity { get; set; }

    public uint CategoryId { get; set; }

    public Category Category { get; set; }
}