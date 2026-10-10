namespace SimpleInventoryManagementSystem.Models;

public class Product
{
    public string ProductId { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string Category { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public int Quantity { get; set; }
    public int MinimumStockLevel { get; set; }

    // Parameterless constructor for JSON deserialization
    public Product()
    {
    }

    // Constructor to initialize a product
    public Product(string productId, string name, string category, decimal price, int quantity, int minimumStockLevel)
    {
        ProductId = productId;
        Name = name;
        Category = category;
        Price = price;
        Quantity = quantity;
        MinimumStockLevel = minimumStockLevel;
    }

    // Calculate low-stock status
    public string StockStatus
    {
        get
        {
            if (Quantity <= MinimumStockLevel)
            {
                return "Low Stock";
            }

            return "In Stock";
        }
    }
}
