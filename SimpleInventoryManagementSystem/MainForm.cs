namespace SimpleInventoryManagementSystem;

using SimpleInventoryManagementSystem.Managers;
using SimpleInventoryManagementSystem.Models;
using SimpleInventoryManagementSystem.Services;

public partial class MainForm : Form
{
    private readonly InventoryManager inventoryManager;
    private readonly StorageService storageService;
    private bool isUpdatingSelection = false;

    public MainForm()
    {
        InitializeComponent();

        inventoryManager = new InventoryManager();
        storageService = new JsonStorageService();

        // Configure DataGridView columns
        ConfigureDataGridView();
    }

    // Configure DataGridView columns manually
    private void ConfigureDataGridView()
    {
        dgvProducts.AutoGenerateColumns = false;
        dgvProducts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvProducts.MultiSelect = false;
        dgvProducts.ReadOnly = true;
        dgvProducts.AllowUserToAddRows = false;

        dgvProducts.Columns.Clear();

        dgvProducts.Columns.Add(new DataGridViewTextBoxColumn
        {
            DataPropertyName = "ProductId",
            HeaderText = "Product ID",
            Width = 90
        });

        dgvProducts.Columns.Add(new DataGridViewTextBoxColumn
        {
            DataPropertyName = "Name",
            HeaderText = "Product Name",
            Width = 140
        });

        dgvProducts.Columns.Add(new DataGridViewTextBoxColumn
        {
            DataPropertyName = "Category",
            HeaderText = "Category",
            Width = 100
        });

        DataGridViewTextBoxColumn priceColumn = new DataGridViewTextBoxColumn
        {
            DataPropertyName = "Price",
            HeaderText = "Price",
            Width = 75
        };
        priceColumn.DefaultCellStyle.Format = "C2";
        dgvProducts.Columns.Add(priceColumn);

        dgvProducts.Columns.Add(new DataGridViewTextBoxColumn
        {
            DataPropertyName = "Quantity",
            HeaderText = "Quantity",
            Width = 75
        });

        dgvProducts.Columns.Add(new DataGridViewTextBoxColumn
        {
            DataPropertyName = "MinimumStockLevel",
            HeaderText = "Min Stock",
            Width = 85
        });

        dgvProducts.Columns.Add(new DataGridViewTextBoxColumn
        {
            DataPropertyName = "StockStatus",
            HeaderText = "Status",
            Width = 90
        });
    }

    // Load products on startup
    private void MainForm_Load(object? sender, EventArgs e)
    {
        // Load saved products
        try
        {
            List<Product> savedProducts = storageService.LoadProducts();
            inventoryManager.LoadProducts(savedProducts);
            RefreshProductGrid();
            lblStatus.Text = $"Loaded {savedProducts.Count} products from storage.";
        }
        catch (Exception ex)
        {
            MessageBox.Show("Could not load products: " + ex.Message + "\nStarting with an empty inventory.", "Storage Notice", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            inventoryManager.LoadProducts(new List<Product>());
            RefreshProductGrid();
            lblStatus.Text = "Started with an empty inventory.";
        }
    }

    // Add a new product
    private void btnAdd_Click(object? sender, EventArgs e)
    {
        // Validate input for new product
        if (!ValidateProductInput(true))
        {
            return;
        }

        Product newProduct = GetProductFromInputs();

        // Check for duplicate product ID
        if (inventoryManager.ProductIdExists(newProduct.ProductId))
        {
            MessageBox.Show("Product ID already exists. Please enter a unique ID.", "Duplicate ID", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtProductId.Focus();
            return;
        }

        // Add to manager
        inventoryManager.AddProduct(newProduct);

        // Save inventory to JSON
        SaveInventory();

        // Refresh UI
        RefreshProductGrid();
        ClearInputs();

        MessageBox.Show("Product added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        lblStatus.Text = $"Product '{newProduct.Name}' added successfully.";
    }

    // Update existing product
    private void btnUpdate_Click(object? sender, EventArgs e)
    {
        string productId = txtProductId.Text.Trim();

        if (string.IsNullOrWhiteSpace(productId))
        {
            MessageBox.Show("Please select a product from the table to update.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        if (!inventoryManager.ProductIdExists(productId))
        {
            MessageBox.Show("The product being edited does not exist in inventory.", "Product Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        // Validate updated fields
        if (!ValidateProductInput(false))
        {
            return;
        }

        Product updatedProduct = GetProductFromInputs();

        // Update in manager
        inventoryManager.UpdateProduct(updatedProduct);

        // Save inventory to JSON
        SaveInventory();

        // Refresh UI
        RefreshProductGrid();

        MessageBox.Show("Product updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        lblStatus.Text = $"Product '{updatedProduct.Name}' updated successfully.";
    }

    // Delete existing product
    private void btnDelete_Click(object? sender, EventArgs e)
    {
        string productId = txtProductId.Text.Trim();

        if (string.IsNullOrWhiteSpace(productId))
        {
            MessageBox.Show("Please select a product from the table to delete.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        Product? productToDelete = inventoryManager.FindProductById(productId);
        if (productToDelete == null)
        {
            MessageBox.Show("The selected product does not exist in inventory.", "Product Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        // Ask for confirmation
        DialogResult result = MessageBox.Show(
            $"Are you sure you want to delete '{productToDelete.Name}' (ID: {productToDelete.ProductId})?",
            "Confirm Delete",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question
        );

        if (result != DialogResult.Yes)
        {
            return;
        }

        // Delete from manager
        inventoryManager.DeleteProduct(productId);

        // Save inventory to JSON
        SaveInventory();

        // Refresh UI
        RefreshProductGrid();
        ClearInputs();

        MessageBox.Show("Product deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        lblStatus.Text = $"Product '{productId}' was deleted.";
    }

    // Clear all input controls
    private void btnClear_Click(object? sender, EventArgs e)
    {
        ClearInputs();
        lblStatus.Text = "Input fields cleared.";
    }

    // Search products by ID or Name
    private void btnSearch_Click(object? sender, EventArgs e)
    {
        string searchText = txtSearch.Text.Trim();

        if (string.IsNullOrWhiteSpace(searchText))
        {
            RefreshProductGrid();
            lblStatus.Text = $"Showing all {inventoryManager.GetProducts().Count} products.";
            return;
        }

        List<Product> searchResults = inventoryManager.SearchProducts(searchText);
        RefreshProductGrid(searchResults);
        lblStatus.Text = $"Found {searchResults.Count} product(s) matching '{searchText}'.";
    }

    // Restore full product list
    private void btnShowAll_Click(object? sender, EventArgs e)
    {
        txtSearch.Clear();
        RefreshProductGrid();
        lblStatus.Text = $"Showing all {inventoryManager.GetProducts().Count} products.";
    }

    // Display only products that are low on stock
    private void btnShowLowStock_Click(object? sender, EventArgs e)
    {
        List<Product> lowStockProducts = inventoryManager.GetLowStockProducts();
        RefreshProductGrid(lowStockProducts);
        lblStatus.Text = $"Showing {lowStockProducts.Count} low-stock product(s).";
    }

    // Increase stock for selected product
    private void btnIncreaseStock_Click(object? sender, EventArgs e)
    {
        string productId = txtProductId.Text.Trim();

        if (string.IsNullOrWhiteSpace(productId))
        {
            MessageBox.Show("Please select a product from the table first.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        int amount = (int)nudStockAmount.Value;
        if (amount <= 0)
        {
            MessageBox.Show("Stock adjustment amount must be greater than zero.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        // Increase stock in manager
        bool success = inventoryManager.IncreaseStock(productId, amount);
        if (!success)
        {
            MessageBox.Show("Could not increase stock. Product not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        // Save inventory to JSON
        SaveInventory();

        // Refresh table and inputs
        RefreshProductGrid();

        Product? updated = inventoryManager.FindProductById(productId);
        if (updated != null)
        {
            nudQuantity.Value = updated.Quantity;
        }

        MessageBox.Show($"Stock increased by {amount}. Current quantity: {updated?.Quantity}", "Stock Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
        lblStatus.Text = $"Stock increased by {amount} for product '{productId}'.";
    }

    // Decrease stock for selected product
    private void btnDecreaseStock_Click(object? sender, EventArgs e)
    {
        string productId = txtProductId.Text.Trim();

        if (string.IsNullOrWhiteSpace(productId))
        {
            MessageBox.Show("Please select a product from the table first.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        Product? product = inventoryManager.FindProductById(productId);
        if (product == null)
        {
            MessageBox.Show("Product not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        int amount = (int)nudStockAmount.Value;
        if (amount <= 0)
        {
            MessageBox.Show("Stock adjustment amount must be greater than zero.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        // Validate stock does not go below zero
        if (product.Quantity < amount)
        {
            MessageBox.Show($"Cannot remove more stock than available. Current stock: {product.Quantity}.", "Insufficient Stock", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        // Decrease stock in manager
        inventoryManager.DecreaseStock(productId, amount);

        // Save inventory to JSON
        SaveInventory();

        // Refresh table and inputs
        RefreshProductGrid();

        nudQuantity.Value = product.Quantity;

        MessageBox.Show($"Stock decreased by {amount}. Current quantity: {product.Quantity}", "Stock Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
        lblStatus.Text = $"Stock decreased by {amount} for product '{productId}'.";
    }

    // Populate input controls from selected DataGridView row
    private void dgvProducts_SelectionChanged(object? sender, EventArgs e)
    {
        if (isUpdatingSelection)
        {
            return;
        }

        if (dgvProducts.SelectedRows.Count == 0)
        {
            return;
        }

        DataGridViewRow row = dgvProducts.SelectedRows[0];
        Product? product = row.DataBoundItem as Product;

        if (product != null)
        {
            txtProductId.Text = product.ProductId;
            txtName.Text = product.Name;

            if (cmbCategory.Items.Contains(product.Category))
            {
                cmbCategory.SelectedItem = product.Category;
            }
            else
            {
                cmbCategory.Text = product.Category;
            }

            nudPrice.Value = product.Price;
            nudQuantity.Value = product.Quantity;
            nudMinimumStock.Value = product.MinimumStockLevel;

            // Lock Product ID while editing
            txtProductId.ReadOnly = true;
        }
    }

    // Refresh DataGridView display and update summary counters
    private void RefreshProductGrid(List<Product>? productsToDisplay = null)
    {
        isUpdatingSelection = true;
        dgvProducts.DataSource = null;

        List<Product> displayList = productsToDisplay ?? inventoryManager.GetProducts();
        dgvProducts.DataSource = new List<Product>(displayList);
        dgvProducts.ClearSelection();
        isUpdatingSelection = false;

        UpdateSummary();
    }

    // Save inventory using storage service with error handling
    private void SaveInventory()
    {
        try
        {
            storageService.SaveProducts(inventoryManager.GetProducts());
        }
        catch (Exception ex)
        {
            MessageBox.Show("Error saving products to file: " + ex.Message, "Storage Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    // Update total and low-stock count labels
    private void UpdateSummary()
    {
        int totalCount = inventoryManager.GetProducts().Count;
        int lowStockCount = inventoryManager.GetLowStockProducts().Count;

        lblTotalProducts.Text = $"Total Products: {totalCount}";
        lblLowStockCount.Text = $"Low Stock: {lowStockCount}";
    }

    // Validate inputs for product creation or editing
    private bool ValidateProductInput(bool isNew)
    {
        string productId = txtProductId.Text.Trim();
        if (string.IsNullOrWhiteSpace(productId))
        {
            MessageBox.Show("Please enter a product ID.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtProductId.Focus();
            return false;
        }

        string name = txtName.Text.Trim();
        if (string.IsNullOrWhiteSpace(name))
        {
            MessageBox.Show("Please enter a product name.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtName.Focus();
            return false;
        }

        if (cmbCategory.SelectedItem == null || string.IsNullOrWhiteSpace(cmbCategory.Text))
        {
            MessageBox.Show("Please select a category.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            cmbCategory.Focus();
            return false;
        }

        if (nudPrice.Value < 0)
        {
            MessageBox.Show("Price cannot be negative.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            nudPrice.Focus();
            return false;
        }

        if (nudQuantity.Value < 0)
        {
            MessageBox.Show("Stock quantity cannot be negative.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            nudQuantity.Focus();
            return false;
        }

        if (nudMinimumStock.Value < 0)
        {
            MessageBox.Show("Minimum stock level cannot be negative.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            nudMinimumStock.Focus();
            return false;
        }

        return true;
    }

    // Construct Product object from current form controls
    private Product GetProductFromInputs()
    {
        return new Product(
            txtProductId.Text.Trim(),
            txtName.Text.Trim(),
            cmbCategory.Text.Trim(),
            nudPrice.Value,
            (int)nudQuantity.Value,
            (int)nudMinimumStock.Value
        );
    }

    // Clear all inputs and unlock Product ID
    private void ClearInputs()
    {
        isUpdatingSelection = true;
        txtProductId.Clear();
        txtName.Clear();
        cmbCategory.SelectedIndex = -1;
        nudPrice.Value = 0;
        nudQuantity.Value = 0;
        nudMinimumStock.Value = 0;
        nudStockAmount.Value = 1;
        txtProductId.ReadOnly = false;
        dgvProducts.ClearSelection();
        isUpdatingSelection = false;

        txtProductId.Focus();
    }
}
