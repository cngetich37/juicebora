# 🥤 Juice Shop Management System

A lightweight, full-featured management system for a juice kiosk — built to handle daily operations including order taking, inventory tracking, customer management, and sales reporting.

---

## 📋 Table of Contents

- [Overview](#overview)
- [Features](#features)
- [Database Schema](#database-schema)
- [Business Processes](#business-processes)
- [Tech Stack](#tech-stack)
- [Getting Started](#getting-started)
- [Project Structure](#project-structure)
- [Contributing](#contributing)
- [License](#license)

---

## Overview

The Juice Shop Management System is designed for a small kiosk-style juice shop. It streamlines the counter workflow — from registering customers and placing orders, to monitoring ingredient stock levels and generating daily sales reports.

The system is backed by a relational database and covers four core operations:

- **Order management** — create and track customer orders in real time
- **Inventory control** — auto-deduct ingredients per order and alert on low stock
- **Customer management** — maintain a record of customers and their order history
- **Sales reporting** — review daily revenue, top-selling juices, and payment breakdowns

---

## Features

- Register and look up customers by name or phone number
- Browse the juice menu and add items to an order with quantities
- Automatic ingredient stock validation before an order is confirmed
- Real-time stock deduction based on each juice's ingredient requirements
- Low-stock alerts when an ingredient falls below its reorder level
- Record sales with payment method (e.g. Cash, M-Pesa)
- Daily sales reports showing revenue totals and best-selling juices
- Payment method breakdown per day

---

## Database Schema

The system is built around **7 tables**:

| Table | Description |
|-------|-------------|
| `Juice` | The menu — juice name, price, and description |
| `Customer` | Customer name, phone, and email |
| `Order` | Each transaction, with status and total amount |
| `OrderItem` | Line items linking an order to specific juices and quantities |
| `Ingredient` | Raw ingredients with stock levels and reorder thresholds |
| `JuiceIngredient` | Maps each juice to its required ingredients and quantities |
| `Sale` | Payment record per order (amount paid, payment method, date) |

### Entity Relationships

```
Customer     ──< Order ──< OrderItem >── Juice
                  │                        │
                Sale              JuiceIngredient >── Ingredient
```

### Key Fields

**Juice**
```
Id | Name | Price | Description
```

**Customer**
```
Id | Name | Phone | Email
```

**Order**
```
Id | CustomerId (FK) | OrderDate | Status | TotalAmount
```

**OrderItem**
```
Id | OrderId (FK) | JuiceId (FK) | Quantity | UnitPrice
```

**Ingredient**
```
Id | Name | Unit | QuantityInStock | ReorderLevel
```

**JuiceIngredient**
```
Id | JuiceId (FK) | IngredientId (FK) | QuantityRequired
```

**Sale**
```
Id | OrderId (FK) | SaleDate | AmountPaid | PaymentMethod
```

---

## Business Processes

### 1. Order Process
1. Customer arrives at the counter
2. Staff looks up or registers the customer (by name/phone)
3. Staff selects juices and sets quantities
4. System checks ingredient stock availability
5. If stock is sufficient — order is confirmed and a sale is recorded
6. If stock is insufficient — customer is notified and offered alternatives

### 2. Inventory Management
1. Every confirmed order triggers an automatic ingredient deduction
2. System compares updated stock against each ingredient's reorder level
3. If stock drops below the threshold — a low-stock alert is raised
4. Staff restocks and updates the `QuantityInStock` field

### 3. Sales Reporting (End of Day)
1. Generate a daily revenue total from the `Sale` table
2. Identify top-selling juices from `OrderItem` grouped by `JuiceId`
3. Break down sales by payment method (Cash vs. M-Pesa)
4. Use insights to inform stocking and pricing decisions

### 4. Customer Management
1. New customers are registered on first visit
2. Returning customers are looked up quickly by phone number
3. Order history is maintained per customer for loyalty tracking

---

## Tech Stack

| Layer | Technology |
|-------|------------|
| API Framework | ASP.NET Core Web API (.NET 10) |
| Language | C# |
| ORM | Entity Framework Core |
| Database | SQL Server |
| API Docs | Swagger / Swashbuckle |
| Auth | JWT Bearer Tokens |

---

## Getting Started

### Prerequisites

- [.NET 10 SDK](https://dotnet.microsoft.com/download/dotnet/10.0)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) (or SQL Server Express)
- [Visual Studio 2022](https://visualstudio.microsoft.com/) or [VS Code](https://code.visualstudio.com/) with the C# extension

### Installation

```bash
# 1. Clone the repository
git clone https://github.com/your-username/juice-shop-management.git
cd juice-shop-management

# 2. Restore NuGet packages
dotnet restore

# 3. Update the connection string in appsettings.json
#    (see Configuration section below)

# 4. Apply Entity Framework migrations to create the database
dotnet ef database update

# 5. Run the API
dotnet run
```

The API will start at `https://localhost:5001` by default.  
Swagger UI is available at `https://localhost:5001/swagger`.

### Configuration

Update `appsettings.json` with your SQL Server connection string:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=JuiceShopDb;Trusted_Connection=True;TrustServerCertificate=True;"
  },
  "Jwt": {
    "Key": "your-secret-key-here",
    "Issuer": "JuiceShopApi",
    "Audience": "JuiceShopClient"
  }
}
```

### Running Migrations

```bash
# Add a new migration
dotnet ef migrations add MigrationName

# Apply migrations to the database
dotnet ef database update

# Revert last migration
dotnet ef migrations remove
```

---

## API Endpoints

| Method | Endpoint | Description |
|--------|----------|-------------|
| GET | `/api/juices` | Get all juices on the menu |
| POST | `/api/juices` | Add a new juice |
| GET | `/api/customers` | Get all customers |
| POST | `/api/customers` | Register a new customer |
| GET | `/api/orders` | Get all orders |
| POST | `/api/orders` | Place a new order |
| GET | `/api/orders/{id}` | Get order details |
| GET | `/api/ingredients` | Get all ingredients with stock levels |
| PUT | `/api/ingredients/{id}/restock` | Update ingredient stock |
| GET | `/api/sales/report` | Get daily sales report |

> Full interactive documentation is available via Swagger UI when the API is running.

---

## Project Structure

```
JuiceShopManagement/
│
├── Controllers/
│   ├── JuicesController.cs
│   ├── CustomersController.cs
│   ├── OrdersController.cs
│   ├── IngredientsController.cs
│   └── SalesController.cs
│
├── Models/
│   ├── Juice.cs
│   ├── Customer.cs
│   ├── Order.cs
│   ├── OrderItem.cs
│   ├── Ingredient.cs
│   ├── JuiceIngredient.cs
│   └── Sale.cs
│
├── Data/
│   ├── AppDbContext.cs          # EF Core DbContext
│   └── Migrations/              # EF Core migration files
│
├── Services/
│   ├── IOrderService.cs
│   ├── OrderService.cs          # Stock validation & order logic
│   ├── IInventoryService.cs
│   └── InventoryService.cs      # Stock deduction & reorder alerts
│
├── DTOs/                        # Request/Response data transfer objects
├── appsettings.json
├── appsettings.Development.json
├── Program.cs
└── JuiceShopManagement.csproj
```

---

## Contributing

Contributions are welcome! To get started:

1. Fork the repository
2. Create a new branch: `git checkout -b feature/your-feature-name`
3. Commit your changes: `git commit -m "Add your feature"`
4. Push to the branch: `git push origin feature/your-feature-name`
5. Open a pull request

Please ensure your code follows the existing style and includes relevant comments.

---

## License

This project is licensed under the [MIT License](LICENSE).

---

> Built for a small juice shop — simple, practical, and easy to extend.