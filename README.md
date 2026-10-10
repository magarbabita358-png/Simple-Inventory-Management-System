# Simple Inventory Management System

A Windows Forms application for small retail businesses to manage product inventory and monitor stock levels, created for **ITS203 Object-Oriented Design and Programming (Milestone 3)**.

## Project Overview

The Simple Inventory Management System allows retail staff to maintain product records, perform real-time inventory adjustments, detect low-stock items, and persist data between application runs. The application is built using C# and Windows Forms on .NET 8, applying fundamental Object-Oriented Programming (OOP) concepts.

## Features

- **Product Management**: Add, update, and delete products with automatic duplicate ID validation.
- **Data Display**: Formatted DataGridView displaying Product ID, Name, Category, Price, Quantity, Minimum Stock Level, and Stock Status.
- **Stock Adjustment**: Increase and decrease stock quantities directly with boundary checks to prevent negative quantities.
- **Low-Stock Detection**: Automatic status calculation (`Low Stock` vs `In Stock`) and one-click filtering for low-stock inventory items.
- **Search & Filter**: Case-insensitive search by Product ID or Product Name, plus quick restore with "Show All".
- **Form Auto-Fill**: Selecting any row in the DataGridView populates the input fields for fast editing or deletion.
- **Persistent Storage**: Automatic save and load using formatted JSON (`Data/products.json`).
- **Resilient Error Handling**: Graceful recovery from missing or corrupted storage files without crashing.

## Technologies Used

- **Language**: C# 12
- **Framework**: .NET 8.0 (Windows Forms)
- **IDE**: Visual Studio 2022 / Visual Studio Code
- **Serialization**: System.Text.Json
- **Version Control**: Git / GitHub

## Requirements

- Windows 10 / 11
- .NET 8.0 SDK or .NET 8.0 Desktop Runtime
- Visual Studio 2022 (with *.NET desktop development* workload) or VS Code with C# Dev Kit

## How to Run

### Using Visual Studio 2022:
1. Open the solution file `SimpleInventoryManagementSystem.slnx` or `SimpleInventoryManagementSystem.csproj`.
2. Ensure build configuration is set to **Debug** or **Release** and target framework is **net8.0-windows**.
3. Press **F5** or click **Start** to run the application.

### Using .NET CLI:
```bash
cd SimpleInventoryManagementSystem
dotnet build
dotnet run
```

## Project Structure

SimpleInventoryManagementSystem
│
├── Models
│   └── Product.cs
│
├── Managers
│   └── InventoryManager.cs
│
├── Services
│   ├── StorageService.cs
│   └── JsonStorageService.cs
│
├── Data
│   └── products.json
│
├── MainForm.cs
├── MainForm.Designer.cs
├── Program.cs
├── README.md
└── SimpleInventoryManagementSystem.csproj

