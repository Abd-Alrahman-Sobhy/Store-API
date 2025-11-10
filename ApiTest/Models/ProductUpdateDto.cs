namespace ApiTest.Models;

public class ProductUpdateDto
{
    public string Name { get; set; }

    public string Description { get; set; }

    public decimal Price { get; set; }

    public uint Quantity { get; set; }

    public uint CategoryId { get; set; }
}