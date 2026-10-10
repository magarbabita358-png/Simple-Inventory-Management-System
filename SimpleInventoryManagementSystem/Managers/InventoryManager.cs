namespace SimpleInventoryManagementSystem.Managers;

using SimpleInventoryManagementSystem.Models;

public class InventoryManager
{
    public List<Product> Products { get; private set; } = new List<Product>();

    // Load products into the manager
    public void LoadProducts(List<Product> products)
    {
        if (products != null)
        {
            Products = products;
        }
        else
        {
            Products = new List<Product>();
        }
    }

    // Check if a product ID already exists
    public bool ProductIdExists(string productId)
    {
        if (string.IsNullOrWhiteSpace(productId))
        {
            return false;
        }

        foreach (Product product in Products)
        {
            if (string.Equals(product.ProductId, productId.Trim(), StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }
        }

        return false;
    }

    // Add a new product if the ID is unique
    public bool AddProduct(Product product)
    {
        if (product == null)
        {
            return false;
        }

        if (ProductIdExists(product.ProductId))
        {
            return false;
        }

        Products.Add(product);
        return true;
    }

    // Search products by ID or Name
    public List<Product> SearchProducts(string searchText)
    {
        if (string.IsNullOrWhiteSpace(searchText))
        {
            return new List<Product>(Products);
        }

        List<Product> searchResults = new List<Product>();
        string cleanSearch = searchText.Trim();

        foreach (Product product in Products)
        {
            bool matchesId = product.ProductId.Contains(cleanSearch, StringComparison.OrdinalIgnoreCase);
            bool matchesName = product.Name.Contains(cleanSearch, StringComparison.OrdinalIgnoreCase);

            if (matchesId || matchesName)
            {
                searchResults.Add(product);
            }
        }

        return searchResults;
    }
}
