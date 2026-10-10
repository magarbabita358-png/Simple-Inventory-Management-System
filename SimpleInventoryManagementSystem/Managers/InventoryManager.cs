namespace SimpleInventoryManagementSystem.Managers;

using SimpleInventoryManagementSystem.Models;

public class InventoryManager
{
    private List<Product> products = new List<Product>();

    // Expose products safely to protect internal collection
    public List<Product> GetProducts()
    {
        return new List<Product>(products);
    }

    // Load products into the manager
    public void LoadProducts(List<Product> initialProducts)
    {
        if (initialProducts != null)
        {
            products = new List<Product>(initialProducts);
        }
        else
        {
            products = new List<Product>();
        }
    }

    // Find a product by its ID
    public Product? FindProductById(string productId)
    {
        if (string.IsNullOrWhiteSpace(productId))
        {
            return null;
        }

        foreach (Product product in products)
        {
            if (string.Equals(product.ProductId, productId.Trim(), StringComparison.OrdinalIgnoreCase))
            {
                return product;
            }
        }

        return null;
    }

    // Check if a product ID already exists
    public bool ProductIdExists(string productId)
    {
        return FindProductById(productId) != null;
    }

    // Add a new product if the ID is unique
    public bool AddProduct(Product product)
    {
        if (product == null || ProductIdExists(product.ProductId))
        {
            return false;
        }

        products.Add(product);
        return true;
    }

    // Update an existing product
    public bool UpdateProduct(Product updatedProduct)
    {
        if (updatedProduct == null)
        {
            return false;
        }

        Product? existingProduct = FindProductById(updatedProduct.ProductId);
        if (existingProduct == null)
        {
            return false;
        }

        existingProduct.Name = updatedProduct.Name;
        existingProduct.Category = updatedProduct.Category;
        existingProduct.Price = updatedProduct.Price;
        existingProduct.Quantity = updatedProduct.Quantity;
        existingProduct.MinimumStockLevel = updatedProduct.MinimumStockLevel;

        return true;
    }

    // Delete a product by its ID
    public bool DeleteProduct(string productId)
    {
        Product? product = FindProductById(productId);
        if (product == null)
        {
            return false;
        }

        products.Remove(product);
        return true;
    }

    // Increase stock for a product
    public bool IncreaseStock(string productId, int amount)
    {
        if (amount <= 0)
        {
            return false;
        }

        Product? product = FindProductById(productId);
        if (product == null)
        {
            return false;
        }

        product.Quantity += amount;
        return true;
    }

    // Decrease stock without going below zero
    public bool DecreaseStock(string productId, int amount)
    {
        if (amount <= 0)
        {
            return false;
        }

        Product? product = FindProductById(productId);
        if (product == null || product.Quantity < amount)
        {
            return false;
        }

        product.Quantity -= amount;
        return true;
    }

    // Get all products that have reached low-stock level
    public List<Product> GetLowStockProducts()
    {
        List<Product> lowStockProducts = new List<Product>();

        foreach (Product product in products)
        {
            if (product.Quantity <= product.MinimumStockLevel)
            {
                lowStockProducts.Add(product);
            }
        }

        return lowStockProducts;
    }

    // Search products by ID or Name
    public List<Product> SearchProducts(string searchText)
    {
        if (string.IsNullOrWhiteSpace(searchText))
        {
            return GetProducts();
        }

        List<Product> searchResults = new List<Product>();
        string cleanSearch = searchText.Trim();

        foreach (Product product in products)
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
