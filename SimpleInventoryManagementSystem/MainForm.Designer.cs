namespace SimpleInventoryManagementSystem;

partial class MainForm
{
    private System.ComponentModel.IContainer components = null;

    // Clean up any resources being used
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    // Initialize form components
    private void InitializeComponent()
    {
        grpProductDetails = new GroupBox();
        lblProductId = new Label();
        txtProductId = new TextBox();
        lblName = new Label();
        txtName = new TextBox();
        lblCategory = new Label();
        cmbCategory = new ComboBox();
        lblPrice = new Label();
        nudPrice = new NumericUpDown();
        lblQuantity = new Label();
        nudQuantity = new NumericUpDown();
        lblMinimumStock = new Label();
        nudMinimumStock = new NumericUpDown();
        btnAdd = new Button();
        btnUpdate = new Button();
        btnDelete = new Button();
        btnClear = new Button();
        grpStockAdjustment = new GroupBox();
        lblStockAmount = new Label();
        nudStockAmount = new NumericUpDown();
        btnIncreaseStock = new Button();
        btnDecreaseStock = new Button();
        lblSearch = new Label();
        txtSearch = new TextBox();
        btnSearch = new Button();
        btnShowAll = new Button();
        btnShowLowStock = new Button();
        dgvProducts = new DataGridView();
        lblTotalProducts = new Label();
        lblLowStockCount = new Label();
        lblStatus = new Label();
        grpProductDetails.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)nudPrice).BeginInit();
        ((System.ComponentModel.ISupportInitialize)nudQuantity).BeginInit();
        ((System.ComponentModel.ISupportInitialize)nudMinimumStock).BeginInit();
        grpStockAdjustment.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)nudStockAmount).BeginInit();
        ((System.ComponentModel.ISupportInitialize)dgvProducts).BeginInit();
        SuspendLayout();

        // grpProductDetails
        grpProductDetails.Controls.Add(lblProductId);
        grpProductDetails.Controls.Add(txtProductId);
        grpProductDetails.Controls.Add(lblName);
        grpProductDetails.Controls.Add(txtName);
        grpProductDetails.Controls.Add(lblCategory);
        grpProductDetails.Controls.Add(cmbCategory);
        grpProductDetails.Controls.Add(lblPrice);
        grpProductDetails.Controls.Add(nudPrice);
        grpProductDetails.Controls.Add(lblQuantity);
        grpProductDetails.Controls.Add(nudQuantity);
        grpProductDetails.Controls.Add(lblMinimumStock);
        grpProductDetails.Controls.Add(nudMinimumStock);
        grpProductDetails.Controls.Add(btnAdd);
        grpProductDetails.Controls.Add(btnUpdate);
        grpProductDetails.Controls.Add(btnDelete);
        grpProductDetails.Controls.Add(btnClear);
        grpProductDetails.Location = new Point(16, 16);
        grpProductDetails.Name = "grpProductDetails";
        grpProductDetails.Size = new Size(340, 465);
        grpProductDetails.TabIndex = 0;
        grpProductDetails.TabStop = false;
        grpProductDetails.Text = "Product Details";

        // lblProductId
        lblProductId.AutoSize = true;
        lblProductId.Location = new Point(16, 26);
        lblProductId.Name = "lblProductId";
        lblProductId.Size = new Size(82, 20);
        lblProductId.TabIndex = 0;
        lblProductId.Text = "Product ID:";

        // txtProductId
        txtProductId.Location = new Point(16, 48);
        txtProductId.Name = "txtProductId";
        txtProductId.Size = new Size(305, 27);
        txtProductId.TabIndex = 1;

        // lblName
        lblName.AutoSize = true;
        lblName.Location = new Point(16, 83);
        lblName.Name = "lblName";
        lblName.Size = new Size(107, 20);
        lblName.TabIndex = 2;
        lblName.Text = "Product Name:";

        // txtName
        txtName.Location = new Point(16, 105);
        txtName.Name = "txtName";
        txtName.Size = new Size(305, 27);
        txtName.TabIndex = 3;

        // lblCategory
        lblCategory.AutoSize = true;
        lblCategory.Location = new Point(16, 140);
        lblCategory.Name = "lblCategory";
        lblCategory.Size = new Size(72, 20);
        lblCategory.TabIndex = 4;
        lblCategory.Text = "Category:";

        // cmbCategory
        cmbCategory.DropDownStyle = ComboBoxStyle.DropDownList;
        cmbCategory.FormattingEnabled = true;
        cmbCategory.Items.AddRange(new object[] {
            "Electronics",
            "Groceries",
            "Clothing",
            "Stationery",
            "Books",
            "Household",
            "Other"
        });
        cmbCategory.Location = new Point(16, 162);
        cmbCategory.Name = "cmbCategory";
        cmbCategory.Size = new Size(305, 28);
        cmbCategory.TabIndex = 5;

        // lblPrice
        lblPrice.AutoSize = true;
        lblPrice.Location = new Point(16, 198);
        lblPrice.Name = "lblPrice";
        lblPrice.Size = new Size(44, 20);
        lblPrice.TabIndex = 6;
        lblPrice.Text = "Price:";

        // nudPrice
        nudPrice.DecimalPlaces = 2;
        nudPrice.Location = new Point(16, 220);
        nudPrice.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
        nudPrice.Name = "nudPrice";
        nudPrice.Size = new Size(305, 27);
        nudPrice.TabIndex = 7;

        // lblQuantity
        lblQuantity.AutoSize = true;
        lblQuantity.Location = new Point(16, 255);
        lblQuantity.Name = "lblQuantity";
        lblQuantity.Size = new Size(68, 20);
        lblQuantity.TabIndex = 8;
        lblQuantity.Text = "Quantity:";

        // nudQuantity
        nudQuantity.Location = new Point(16, 277);
        nudQuantity.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
        nudQuantity.Name = "nudQuantity";
        nudQuantity.Size = new Size(305, 27);
        nudQuantity.TabIndex = 9;

        // lblMinimumStock
        lblMinimumStock.AutoSize = true;
        lblMinimumStock.Location = new Point(16, 312);
        lblMinimumStock.Name = "lblMinimumStock";
        lblMinimumStock.Size = new Size(150, 20);
        lblMinimumStock.TabIndex = 10;
        lblMinimumStock.Text = "Minimum Stock Level:";

        // nudMinimumStock
        nudMinimumStock.Location = new Point(16, 334);
        nudMinimumStock.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
        nudMinimumStock.Name = "nudMinimumStock";
        nudMinimumStock.Size = new Size(305, 27);
        nudMinimumStock.TabIndex = 11;

        // btnAdd
        btnAdd.Location = new Point(16, 375);
        btnAdd.Name = "btnAdd";
        btnAdd.Size = new Size(145, 34);
        btnAdd.TabIndex = 12;
        btnAdd.Text = "Add Product";
        btnAdd.UseVisualStyleBackColor = true;
        btnAdd.Click += btnAdd_Click;

        // btnUpdate
        btnUpdate.Location = new Point(176, 375);
        btnUpdate.Name = "btnUpdate";
        btnUpdate.Size = new Size(145, 34);
        btnUpdate.TabIndex = 13;
        btnUpdate.Text = "Update Product";
        btnUpdate.UseVisualStyleBackColor = true;
        btnUpdate.Click += btnUpdate_Click;

        // btnDelete
        btnDelete.Location = new Point(16, 417);
        btnDelete.Name = "btnDelete";
        btnDelete.Size = new Size(145, 34);
        btnDelete.TabIndex = 14;
        btnDelete.Text = "Delete Product";
        btnDelete.UseVisualStyleBackColor = true;
        btnDelete.Click += btnDelete_Click;

        // btnClear
        btnClear.Location = new Point(176, 417);
        btnClear.Name = "btnClear";
        btnClear.Size = new Size(145, 34);
        btnClear.TabIndex = 15;
        btnClear.Text = "Clear";
        btnClear.UseVisualStyleBackColor = true;
        btnClear.Click += btnClear_Click;

        // grpStockAdjustment
        grpStockAdjustment.Controls.Add(lblStockAmount);
        grpStockAdjustment.Controls.Add(nudStockAmount);
        grpStockAdjustment.Controls.Add(btnIncreaseStock);
        grpStockAdjustment.Controls.Add(btnDecreaseStock);
        grpStockAdjustment.Location = new Point(16, 488);
        grpStockAdjustment.Name = "grpStockAdjustment";
        grpStockAdjustment.Size = new Size(340, 135);
        grpStockAdjustment.TabIndex = 1;
        grpStockAdjustment.TabStop = false;
        grpStockAdjustment.Text = "Stock Adjustment";

        // lblStockAmount
        lblStockAmount.AutoSize = true;
        lblStockAmount.Location = new Point(16, 26);
        lblStockAmount.Name = "lblStockAmount";
        lblStockAmount.Size = new Size(140, 20);
        lblStockAmount.TabIndex = 0;
        lblStockAmount.Text = "Adjustment Amount:";

        // nudStockAmount
        nudStockAmount.Location = new Point(16, 49);
        nudStockAmount.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
        nudStockAmount.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
        nudStockAmount.Name = "nudStockAmount";
        nudStockAmount.Size = new Size(305, 27);
        nudStockAmount.TabIndex = 1;
        nudStockAmount.Value = new decimal(new int[] { 1, 0, 0, 0 });

        // btnIncreaseStock
        btnIncreaseStock.Location = new Point(16, 88);
        btnIncreaseStock.Name = "btnIncreaseStock";
        btnIncreaseStock.Size = new Size(145, 34);
        btnIncreaseStock.TabIndex = 2;
        btnIncreaseStock.Text = "+ Increase Stock";
        btnIncreaseStock.UseVisualStyleBackColor = true;
        btnIncreaseStock.Click += btnIncreaseStock_Click;

        // btnDecreaseStock
        btnDecreaseStock.Location = new Point(176, 88);
        btnDecreaseStock.Name = "btnDecreaseStock";
        btnDecreaseStock.Size = new Size(145, 34);
        btnDecreaseStock.TabIndex = 3;
        btnDecreaseStock.Text = "- Decrease Stock";
        btnDecreaseStock.UseVisualStyleBackColor = true;
        btnDecreaseStock.Click += btnDecreaseStock_Click;

        // lblSearch
        lblSearch.AutoSize = true;
        lblSearch.Location = new Point(375, 20);
        lblSearch.Name = "lblSearch";
        lblSearch.Size = new Size(144, 20);
        lblSearch.TabIndex = 2;
        lblSearch.Text = "Search (ID or Name):";

        // txtSearch
        txtSearch.Location = new Point(525, 17);
        txtSearch.Name = "txtSearch";
        txtSearch.Size = new Size(190, 27);
        txtSearch.TabIndex = 3;

        // btnSearch
        btnSearch.Location = new Point(722, 16);
        btnSearch.Name = "btnSearch";
        btnSearch.Size = new Size(80, 30);
        btnSearch.TabIndex = 4;
        btnSearch.Text = "Search";
        btnSearch.UseVisualStyleBackColor = true;
        btnSearch.Click += btnSearch_Click;

        // btnShowAll
        btnShowAll.Location = new Point(808, 16);
        btnShowAll.Name = "btnShowAll";
        btnShowAll.Size = new Size(85, 30);
        btnShowAll.TabIndex = 5;
        btnShowAll.Text = "Show All";
        btnShowAll.UseVisualStyleBackColor = true;
        btnShowAll.Click += btnShowAll_Click;

        // btnShowLowStock
        btnShowLowStock.Location = new Point(899, 16);
        btnShowLowStock.Name = "btnShowLowStock";
        btnShowLowStock.Size = new Size(125, 30);
        btnShowLowStock.TabIndex = 6;
        btnShowLowStock.Text = "Low Stock Only";
        btnShowLowStock.UseVisualStyleBackColor = true;
        btnShowLowStock.Click += btnShowLowStock_Click;

        // dgvProducts
        dgvProducts.AllowUserToAddRows = false;
        dgvProducts.AllowUserToDeleteRows = false;
        dgvProducts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dgvProducts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dgvProducts.Location = new Point(375, 56);
        dgvProducts.MultiSelect = false;
        dgvProducts.Name = "dgvProducts";
        dgvProducts.ReadOnly = true;
        dgvProducts.RowHeadersVisible = false;
        dgvProducts.RowHeadersWidth = 51;
        dgvProducts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvProducts.Size = new Size(650, 520);
        dgvProducts.TabIndex = 7;
        dgvProducts.SelectionChanged += dgvProducts_SelectionChanged;

        // lblTotalProducts
        lblTotalProducts.AutoSize = true;
        lblTotalProducts.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        lblTotalProducts.Location = new Point(375, 595);
        lblTotalProducts.Name = "lblTotalProducts";
        lblTotalProducts.Size = new Size(122, 20);
        lblTotalProducts.TabIndex = 8;
        lblTotalProducts.Text = "Total Products: 0";

        // lblLowStockCount
        lblLowStockCount.AutoSize = true;
        lblLowStockCount.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        lblLowStockCount.ForeColor = Color.DarkRed;
        lblLowStockCount.Location = new Point(530, 595);
        lblLowStockCount.Name = "lblLowStockCount";
        lblLowStockCount.Size = new Size(92, 20);
        lblLowStockCount.TabIndex = 9;
        lblLowStockCount.Text = "Low Stock: 0";

        // lblStatus
        lblStatus.AutoSize = true;
        lblStatus.Location = new Point(660, 595);
        lblStatus.Name = "lblStatus";
        lblStatus.Size = new Size(50, 20);
        lblStatus.TabIndex = 10;
        lblStatus.Text = "Ready";

        // MainForm
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(1042, 635);
        Controls.Add(lblStatus);
        Controls.Add(lblLowStockCount);
        Controls.Add(lblTotalProducts);
        Controls.Add(dgvProducts);
        Controls.Add(btnShowLowStock);
        Controls.Add(btnShowAll);
        Controls.Add(btnSearch);
        Controls.Add(txtSearch);
        Controls.Add(lblSearch);
        Controls.Add(grpStockAdjustment);
        Controls.Add(grpProductDetails);
        FormBorderStyle = FormBorderStyle.FixedSingle;
        MaximizeBox = false;
        Name = "MainForm";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Simple Inventory Management System";
        Load += MainForm_Load;
        grpProductDetails.ResumeLayout(false);
        grpProductDetails.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)nudPrice).EndInit();
        ((System.ComponentModel.ISupportInitialize)nudQuantity).EndInit();
        ((System.ComponentModel.ISupportInitialize)nudMinimumStock).EndInit();
        grpStockAdjustment.ResumeLayout(false);
        grpStockAdjustment.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)nudStockAmount).EndInit();
        ((System.ComponentModel.ISupportInitialize)dgvProducts).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    private GroupBox grpProductDetails;
    private Label lblProductId;
    private TextBox txtProductId;
    private Label lblName;
    private TextBox txtName;
    private Label lblCategory;
    private ComboBox cmbCategory;
    private Label lblPrice;
    private NumericUpDown nudPrice;
    private Label lblQuantity;
    private NumericUpDown nudQuantity;
    private Label lblMinimumStock;
    private NumericUpDown nudMinimumStock;
    private Button btnAdd;
    private Button btnUpdate;
    private Button btnDelete;
    private Button btnClear;
    private GroupBox grpStockAdjustment;
    private Label lblStockAmount;
    private NumericUpDown nudStockAmount;
    private Button btnIncreaseStock;
    private Button btnDecreaseStock;
    private Label lblSearch;
    private TextBox txtSearch;
    private Button btnSearch;
    private Button btnShowAll;
    private Button btnShowLowStock;
    private DataGridView dgvProducts;
    private Label lblTotalProducts;
    private Label lblLowStockCount;
    private Label lblStatus;
}
