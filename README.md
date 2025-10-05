# Grain Broker Management

A grain broker management system built with **ASP.NET Core 8.0**, designed to help grain brokers manage suppliers, customers, and grain requirements efficiently.

---

## Overview

- Manage grain suppliers and customers
- Fulfill grain requirements**
- Access data through RESTful API
- Built with ASP.NET Core 8, Entity Framework Core, and SQL Server
- API documentation available through integrated Swagger UI

---

## Features

- CRUD operations for Customers and Suppliers
- Place and manage Orders for grain
- Fulfillment tracking for each order (including supplier, amount supplied, and delivery cost)
- Relational database design using Entity Framework Core
- Seed data for quick testing and demonstration
- Modern ASP.NET Core architecture

---

## Directory Structure

```
src/
├── GrainBroker.API/           # ASP.NET Core Web API project
│   ├── Controllers/           # API Controllers (e.g., WeatherForecastController)
│   ├── Program.cs             # Entry point and configuration
│   └── WeatherForecast.cs     # Example model
└── GrainBroker.Entities/      # Data access and EF Core entities
    ├── GrainBrokerDbContext.cs      # EF Core DbContext
    └── Migrations/                  # EF Core migrations and model snapshots
```

---

## Database Schema

- **Customers**: Id (GUID), Name, Location
- **Suppliers**: Id (GUID), Name, Location
- **Orders**: OrderId, OrderDate, CustomerId (foreign key), RequestedGrainAmount
- **OrderFulfillments**: Id, OrderId (unique, foreign key), SupplierId (foreign key), SuppliedAmount, CostOfDelivery

All relationships are enforced with appropriate foreign keys and constraints.

---

## Getting Started

### Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- SQL Server (local or cloud)

### Setup Instructions

1. **Clone the repository**
    ```bash
    git clone https://github.com/mahalakshmilatha/enademoproject.git
    cd enademoproject
    ```

2. **Update connection string**
    - Edit `appsettings.json` in `src/GrainBroker.API/GrainBroker.API/` to set your SQL Server connection.

3. **Apply database migrations**
    ```bash
    cd src/GrainBroker.API/GrainBroker.API
    dotnet ef database update
    ```

4. **Run the API**
    ```bash
    dotnet run
    ```
    The API will start, and Swagger UI will be available at `https://localhost:<port>/swagger`.

---

## API Usage

- All major endpoints are auto-documented via Swagger.
- You can test and explore the API interactively at `/swagger`.

---

## Example API Endpoints

- `GET /customers` - List all customers
- `POST /suppliers` - Add a new supplier
- `POST /orders` - Place a new order
- `GET /orderfulfillments` - List all order fulfillments

> For more details, refer to the auto-generated Swagger documentation.

---

## Technologies Used

- ASP.NET Core 8.0
- Entity Framework Core (with Migrations)
- SQL Server
- Swagger (Swashbuckle)

---

## Architecture

<img width="2404" height="1444" alt="image" src="https://github.com/user-attachments/assets/ec1174f0-5f6c-4ed4-af1a-47c22c06b216" />

---


