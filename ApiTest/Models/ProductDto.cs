namespace ApiTest.Models;

public class ProductDto
{
    public uint Id { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public decimal Price { get; set; }

    public uint Quantity { get; set; }
    
    public string CategoryName { get; set; }
}