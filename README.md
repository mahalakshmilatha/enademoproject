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
│   ├── Controllers/           # API Controllers
│   ├── Services/              # Implementation of business services
│   └── Program.cs             # Entry point and configuration
├── GrainBroker.Entities/      # Data access and EF Core entities
│   ├── DTOs/                  # Data Transfer Objects
│   ├── GrainBrokerDbContext.cs # EF Core DbContext
│   └── Migrations/            # EF Core migrations
├── GrainBroker.Frontend/      # Blazor Frontend Application
│   ├── Pages/                 # Razor Pages
│   ├── Services/              # Frontend Services
│   └── Shared/               # Shared Components
└── GrainBroker.Services/      # Business Logic Layer
    ├── Interfaces/           # Service Interfaces
    └── Implementation/       # Service Implementations
```

---

## Database Schema

### Entity Relationship Diagram
```
+-------------+          +--------------+
|  Customers  |          |  Suppliers   |
+-------------+          +--------------+
| Id (PK)     |          | Id (PK)      |
| Name        |          | Name         |
| Location    |          | Location     |
| Status      |          | Status       |
+-------------+          +--------------+
       |                        |
       |                        |
       |                        |
    +--v---------+             |
    |   Orders   |             |
    +------------+             |
    | Id (PK)    |             |
    | OrderDate  |             |
    | CustomerId |             |
    | Amount     |             |
    | Status     |             |
    +------------+             |
           |                   |
           |                   |
    +------v------------------v+
    |    OrderFulfillments     |
    +-----------------------+
    | Id (PK)              |
    | OrderId (FK)         |
    | SupplierId (FK)      |
    | SuppliedAmount       |
    | CostOfDelivery       |
    | Status               |
    +-----------------------+
```

### Entity Details

1. **Customers**
   - `Id` (GUID, Primary Key)
   - `Name` (string)
   - `Location` (string)
   - `Status` (enum)

2. **Suppliers**
   - `Id` (GUID, Primary Key)
   - `Name` (string)
   - `Location` (string)
   - `Status` (enum)

3. **Orders**
   - `Id` (GUID, Primary Key)
   - `OrderDate` (DateTime)
   - `CustomerId` (GUID, Foreign Key)
   - `RequestedGrainAmount` (decimal)
   - `Status` (enum)

4. **OrderFulfillments**
   - `Id` (GUID, Primary Key)
   - `OrderId` (GUID, Foreign Key)
   - `SupplierId` (GUID, Foreign Key)
   - `SuppliedAmount` (decimal)
   - `CostOfDelivery` (decimal)
   - `Status` (enum)

### Relationships
- One Customer can have many Orders (1:N)
- One Order can have one OrderFulfillment (1:1)
- One Supplier can fulfill many Orders (1:N through OrderFulfillments)

All relationships are enforced with appropriate foreign keys and constraints.

---

## Technologies Used

- ASP.NET Core 8.0
- Entity Framework Core (with Code-First Migrations)
- Blazor WebAssembly for Frontend
- SQL Server
- Swagger (Swashbuckle)
- Clean Architecture Pattern
- Repository and Service Pattern

## Project Structure

The solution follows a clean architecture pattern with clear separation of concerns:

1. **GrainBroker.API**: Web API layer handling HTTP requests and responses
2. **GrainBroker.Entities**: Data access layer with EF Core entities and DTOs
3. **GrainBroker.Services**: Business logic layer with service interfaces and implementations
4. **GrainBroker.Frontend**: Blazor WebAssembly frontend application

## Getting Started

1. Clone the repository
2. Update the connection string in `GrainBroker.API/appsettings.json`
3. Run Entity Framework migrations:
   ```powershell
   dotnet ef database update
   ```
4. Start the API project
5. Start the Frontend project

## API Endpoints

The API provides the following main endpoints:

- `/api/customers` - Customer management
- `/api/suppliers` - Supplier management
- `/api/orders` - Order management
- `/api/fulfillments` - Order fulfillment management

For detailed API documentation, run the project and visit the Swagger UI endpoint.

---

## Architecture
This diagram illustrates a cloud-based, multi-layered architecture utilizing Microsoft Azure services. The main components and their interactions are as follows:

<img width="2404" height="1444" alt="image" src="https://github.com/user-attachments/assets/ec1174f0-5f6c-4ed4-af1a-47c22c06b216" />

---

### Frontend

 The frontend authenticates users via Azure Active Directory (Azure AD), ensuring secure access.
 
### App Services (Backend/API Layer)

App Services: The core backend of the application is hosted in Azure App Services. This layer handles business logic and API endpoints.
Frontend Interaction: The frontend communicates with App Services for all application operations after authentication.

### Data Layer
Azure SQL Database: The application’s data is managed in an Azure SQL Database. App Services read from and write to this database as part of normal operation.

### Data & Process Flow

Users authenticate via Azure AD and use the frontend to access the application.
The frontend interacts with App Services, which in turn read from and write to the Azure SQL Database.
Function Apps/Logic Apps handle background processes or data integrations, interacting both with the database and with blob storage for file operations.
Files such as CSVs are uploaded to or downloaded from Azure Blob Storage, possibly triggered by the function/logic apps.
Additional Azure services (analytics, key management, etc.) are integrated as needed.

---


