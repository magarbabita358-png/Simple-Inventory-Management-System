namespace SimpleInventoryManagementSystem.Services;

using System.Text.Json;
using SimpleInventoryManagementSystem.Models;

public class JsonStorageService
{
    private readonly string filePath;

    // Initialize file path to Data/products.json
    public JsonStorageService()
    {
        string dataFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data");
        filePath = Path.Combine(dataFolder, "products.json");
    }

    // Optional constructor for custom file path
    public JsonStorageService(string customFilePath)
    {
        filePath = customFilePath;
    }

    // Load products from JSON file
    public List<Product> LoadProducts()
    {
        // Return empty list if file does not exist
        if (!File.Exists(filePath))
        {
            return new List<Product>();
        }

        try
        {
            string jsonText = File.ReadAllText(filePath);
            List<Product>? products = JsonSerializer.Deserialize<List<Product>>(jsonText);
            return products ?? new List<Product>();
        }
        catch (Exception ex)
        {
            throw new IOException("Failed to load products from file: " + ex.Message, ex);
        }
    }

    // Save products to JSON file
    public void SaveProducts(List<Product> products)
    {
        try
        {
            // Ensure Data directory exists
            string? folder = Path.GetDirectoryName(filePath);
            if (!string.IsNullOrEmpty(folder) && !Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }

            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            };

            string jsonText = JsonSerializer.Serialize(products, options);
            File.WriteAllText(filePath, jsonText);
        }
        catch (Exception ex)
        {
            throw new IOException("Failed to save products to file: " + ex.Message, ex);
        }
    }
}
