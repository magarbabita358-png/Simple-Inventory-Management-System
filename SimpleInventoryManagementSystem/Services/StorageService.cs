namespace SimpleInventoryManagementSystem.Services;

using SimpleInventoryManagementSystem.Models;

public abstract class StorageService
{
    // Load products from storage
    public abstract List<Product> LoadProducts();

    // Save products to storage
    public abstract void SaveProducts(List<Product> products);
}
