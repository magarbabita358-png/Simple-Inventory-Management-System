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
        btnClear = new Button();
        lblSearch = new Label();
        txtSearch = new TextBox();
        btnSearch = new Button();
        btnShowAll = new Button();
        dgvProducts = new DataGridView();
        lblStatus = new Label();
        grpProductDetails.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)nudPrice).BeginInit();
        ((System.ComponentModel.ISupportInitialize)nudQuantity).BeginInit();
        ((System.ComponentModel.ISupportInitialize)nudMinimumStock).BeginInit();
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
        grpProductDetails.Controls.Add(btnClear);
        grpProductDetails.Location = new Point(16, 16);
        grpProductDetails.Name = "grpProductDetails";
        grpProductDetails.Size = new Size(330, 480);
        grpProductDetails.TabIndex = 0;
        grpProductDetails.TabStop = false;
        grpProductDetails.Text = "Product Details";

        // lblProductId
        lblProductId.AutoSize = true;
        lblProductId.Location = new Point(16, 32);
        lblProductId.Name = "lblProductId";
        lblProductId.Size = new Size(82, 20);
        lblProductId.TabIndex = 0;
        lblProductId.Text = "Product ID:";

        // txtProductId
        txtProductId.Location = new Point(16, 56);
        txtProductId.Name = "txtProductId";
        txtProductId.Size = new Size(295, 27);
        txtProductId.TabIndex = 1;

        // lblName
        lblName.AutoSize = true;
        lblName.Location = new Point(16, 96);
        lblName.Name = "lblName";
        lblName.Size = new Size(107, 20);
        lblName.TabIndex = 2;
        lblName.Text = "Product Name:";

        // txtName
        txtName.Location = new Point(16, 120);
        txtName.Name = "txtName";
        txtName.Size = new Size(295, 27);
        txtName.TabIndex = 3;

        // lblCategory
        lblCategory.AutoSize = true;
        lblCategory.Location = new Point(16, 160);
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
        cmbCategory.Location = new Point(16, 184);
        cmbCategory.Name = "cmbCategory";
        cmbCategory.Size = new Size(295, 28);
        cmbCategory.TabIndex = 5;

        // lblPrice
        lblPrice.AutoSize = true;
        lblPrice.Location = new Point(16, 224);
        lblPrice.Name = "lblPrice";
        lblPrice.Size = new Size(44, 20);
        lblPrice.TabIndex = 6;
        lblPrice.Text = "Price:";

        // nudPrice
        nudPrice.DecimalPlaces = 2;
        nudPrice.Location = new Point(16, 248);
        nudPrice.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
        nudPrice.Name = "nudPrice";
        nudPrice.Size = new Size(295, 27);
        nudPrice.TabIndex = 7;

        // lblQuantity
        lblQuantity.AutoSize = true;
        lblQuantity.Location = new Point(16, 288);
        lblQuantity.Name = "lblQuantity";
        lblQuantity.Size = new Size(68, 20);
        lblQuantity.TabIndex = 8;
        lblQuantity.Text = "Quantity:";

        // nudQuantity
        nudQuantity.Location = new Point(16, 312);
        nudQuantity.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
        nudQuantity.Name = "nudQuantity";
        nudQuantity.Size = new Size(295, 27);
        nudQuantity.TabIndex = 9;

        // lblMinimumStock
        lblMinimumStock.AutoSize = true;
        lblMinimumStock.Location = new Point(16, 352);
        lblMinimumStock.Name = "lblMinimumStock";
        lblMinimumStock.Size = new Size(150, 20);
        lblMinimumStock.TabIndex = 10;
        lblMinimumStock.Text = "Minimum Stock Level:";

        // nudMinimumStock
        nudMinimumStock.Location = new Point(16, 376);
        nudMinimumStock.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
        nudMinimumStock.Name = "nudMinimumStock";
        nudMinimumStock.Size = new Size(295, 27);
        nudMinimumStock.TabIndex = 11;

        // btnAdd
        btnAdd.Location = new Point(16, 424);
        btnAdd.Name = "btnAdd";
        btnAdd.Size = new Size(140, 36);
        btnAdd.TabIndex = 12;
        btnAdd.Text = "Add Product";
        btnAdd.UseVisualStyleBackColor = true;
        btnAdd.Click += btnAdd_Click;

        // btnClear
        btnClear.Location = new Point(171, 424);
        btnClear.Name = "btnClear";
        btnClear.Size = new Size(140, 36);
        btnClear.TabIndex = 13;
        btnClear.Text = "Clear";
        btnClear.UseVisualStyleBackColor = true;
        btnClear.Click += btnClear_Click;

        // lblSearch
        lblSearch.AutoSize = true;
        lblSearch.Location = new Point(365, 20);
        lblSearch.Name = "lblSearch";
        lblSearch.Size = new Size(156, 20);
        lblSearch.TabIndex = 1;
        lblSearch.Text = "Search (ID or Name):";

        // txtSearch
        txtSearch.Location = new Point(527, 17);
        txtSearch.Name = "txtSearch";
        txtSearch.Size = new Size(230, 27);
        txtSearch.TabIndex = 2;

        // btnSearch
        btnSearch.Location = new Point(765, 16);
        btnSearch.Name = "btnSearch";
        btnSearch.Size = new Size(90, 30);
        btnSearch.TabIndex = 3;
        btnSearch.Text = "Search";
        btnSearch.UseVisualStyleBackColor = true;
        btnSearch.Click += btnSearch_Click;

        // btnShowAll
        btnShowAll.Location = new Point(863, 16);
        btnShowAll.Name = "btnShowAll";
        btnShowAll.Size = new Size(95, 30);
        btnShowAll.TabIndex = 4;
        btnShowAll.Text = "Show All";
        btnShowAll.UseVisualStyleBackColor = true;
        btnShowAll.Click += btnShowAll_Click;

        // dgvProducts
        dgvProducts.AllowUserToAddRows = false;
        dgvProducts.AllowUserToDeleteRows = false;
        dgvProducts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dgvProducts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dgvProducts.Location = new Point(365, 56);
        dgvProducts.MultiSelect = false;
        dgvProducts.Name = "dgvProducts";
        dgvProducts.ReadOnly = true;
        dgvProducts.RowHeadersVisible = false;
        dgvProducts.RowHeadersWidth = 51;
        dgvProducts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvProducts.Size = new Size(593, 440);
        dgvProducts.TabIndex = 5;
        dgvProducts.SelectionChanged += dgvProducts_SelectionChanged;

        // lblStatus
        lblStatus.AutoSize = true;
        lblStatus.Location = new Point(16, 510);
        lblStatus.Name = "lblStatus";
        lblStatus.Size = new Size(53, 20);
        lblStatus.TabIndex = 6;
        lblStatus.Text = "Ready";

        // MainForm
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(975, 545);
        Controls.Add(lblStatus);
        Controls.Add(dgvProducts);
        Controls.Add(btnShowAll);
        Controls.Add(btnSearch);
        Controls.Add(txtSearch);
        Controls.Add(lblSearch);
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
    private Button btnClear;
    private Label lblSearch;
    private TextBox txtSearch;
    private Button btnSearch;
    private Button btnShowAll;
    private DataGridView dgvProducts;
    private Label lblStatus;
}
