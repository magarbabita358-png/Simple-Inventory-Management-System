namespace SimpleInventoryManagementSystem;

using SimpleInventoryManagementSystem.Managers;
using SimpleInventoryManagementSystem.Models;
using SimpleInventoryManagementSystem.Services;

public partial class MainForm : Form
{
    private readonly InventoryManager inventoryManager;
    private readonly JsonStorageService storageService;
    private bool isUpdatingSelection = false;

    public MainForm()
    {
        InitializeComponent();

        inventoryManager = new InventoryManager();
        storageService = new JsonStorageService();

        // Configure table columns
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

    // Form load event handler
    private void MainForm_Load(object? sender, EventArgs e)
    {
        // Load saved products
        try
        {
            List<Product> savedProducts = storageService.LoadProducts();
            inventoryManager.LoadProducts(savedProducts);
            DisplayProducts(inventoryManager.Products);
            lblStatus.Text = $"Loaded {inventoryManager.Products.Count} products from storage.";
        }
        catch (Exception ex)
        {
            MessageBox.Show("Could not load products: " + ex.Message, "Storage Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            lblStatus.Text = "Started with an empty inventory.";
        }
    }

    // Add a new product
    private void btnAdd_Click(object? sender, EventArgs e)
    {
        // Check product input
        string productId = txtProductId.Text.Trim();
        if (string.IsNullOrWhiteSpace(productId))
        {
            MessageBox.Show("Please enter a Product ID.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtProductId.Focus();
            return;
        }

        string name = txtName.Text.Trim();
        if (string.IsNullOrWhiteSpace(name))
        {
            MessageBox.Show("Please enter a Product Name.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtName.Focus();
            return;
        }

        if (cmbCategory.SelectedItem == null || string.IsNullOrWhiteSpace(cmbCategory.Text))
        {
            MessageBox.Show("Please select a Category.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            cmbCategory.Focus();
            return;
        }

        string category = cmbCategory.Text.Trim();

        if (nudPrice.Value < 0)
        {
            MessageBox.Show("Price cannot be negative.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            nudPrice.Focus();
            return;
        }

        if (nudQuantity.Value < 0)
        {
            MessageBox.Show("Quantity cannot be negative.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            nudQuantity.Focus();
            return;
        }

        if (nudMinimumStock.Value < 0)
        {
            MessageBox.Show("Minimum stock level cannot be negative.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            nudMinimumStock.Focus();
            return;
        }

        // Check for duplicate product ID
        if (inventoryManager.ProductIdExists(productId))
        {
            MessageBox.Show("A product with this ID already exists. Product IDs must be unique.", "Duplicate ID", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtProductId.Focus();
            return;
        }

        // Create product object
        Product newProduct = new Product(
            productId,
            name,
            category,
            nudPrice.Value,
            (int)nudQuantity.Value,
            (int)nudMinimumStock.Value
        );

        // Add to inventory manager
        inventoryManager.AddProduct(newProduct);

        // Save products to JSON
        try
        {
            storageService.SaveProducts(inventoryManager.Products);
        }
        catch (Exception ex)
        {
            MessageBox.Show("Failed to save products: " + ex.Message, "Save Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        // Refresh product table
        DisplayProducts(inventoryManager.Products);

        // Clear input controls
        ClearInputs();

        // Display success confirmation
        MessageBox.Show("Product added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        lblStatus.Text = $"Product '{newProduct.Name}' (ID: {productId}) added successfully.";
    }

    // Search products by ID or Name
    private void btnSearch_Click(object? sender, EventArgs e)
    {
        string searchText = txtSearch.Text.Trim();

        // If search is empty show all
        if (string.IsNullOrWhiteSpace(searchText))
        {
            DisplayProducts(inventoryManager.Products);
            lblStatus.Text = $"Showing all {inventoryManager.Products.Count} products.";
            return;
        }

        List<Product> searchResults = inventoryManager.SearchProducts(searchText);
        DisplayProducts(searchResults);
        lblStatus.Text = $"Found {searchResults.Count} matching product(s).";
    }

    // Show all products
    private void btnShowAll_Click(object? sender, EventArgs e)
    {
        txtSearch.Clear();
        DisplayProducts(inventoryManager.Products);
        lblStatus.Text = $"Showing all {inventoryManager.Products.Count} products.";
    }

    // Clear input fields
    private void btnClear_Click(object? sender, EventArgs e)
    {
        ClearInputs();
        lblStatus.Text = "Input fields cleared.";
    }

    // Display selected product details in input controls
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

        DataGridViewRow selectedRow = dgvProducts.SelectedRows[0];
        Product? product = selectedRow.DataBoundItem as Product;

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
        }
    }

    // Refresh the DataGridView display
    private void DisplayProducts(List<Product> products)
    {
        isUpdatingSelection = true;
        dgvProducts.DataSource = null;
        dgvProducts.DataSource = new List<Product>(products);
        dgvProducts.ClearSelection();
        isUpdatingSelection = false;
    }

    // Clear all input controls
    private void ClearInputs()
    {
        isUpdatingSelection = true;
        txtProductId.Clear();
        txtName.Clear();
        cmbCategory.SelectedIndex = -1;
        nudPrice.Value = 0;
        nudQuantity.Value = 0;
        nudMinimumStock.Value = 0;
        dgvProducts.ClearSelection();
        isUpdatingSelection = false;

        txtProductId.Focus();
    }
}
