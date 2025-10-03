# Grain Broker Management System

A comprehensive grain broker management system built with ASP.NET Core 6.0, designed to help grain brokers manage suppliers, customers, and grain requirements efficiently.

## Overview

This system enables grain brokers to:
- Manage grain suppliers and their capacities
- Track customer information and requirements
- Record and fulfill grain requirements
- Import data from CSV files
- Access data through a RESTful API

## Architecture

### Backend Layer
- **Framework**: ASP.NET Core 6.0 Web API
- **Database**: SQLite with Entity Framework Core
- **Data Models**: Supplier, Customer, GrainRequirement
- **API**: RESTful endpoints following REST conventions

### Database Design
The system uses a relational database with three main entities:

1. **Supplier**: Stores information about grain suppliers
   - Name, Location, Capacity, PricePerUnit, GrainType
   - Timestamps for tracking creation and updates

2. **Customer**: Manages customer information
   - Name, Location, ContactEmail, ContactPhone
   - Timestamps for auditing

3. **GrainRequirement**: Tracks grain orders and fulfillment
   - Links to Customer and Supplier
   - GrainType, Quantity, RequiredByDate, Status
   - Tracks fulfillment status and timestamps

### CSV Data Ingestion
The system includes a CSV import service that can:
- Import supplier data from CSV files
- Import customer data from CSV files
- Validate data and handle errors gracefully
- Auto-initialize with sample data on first run

## Getting Started

### Prerequisites
- .NET 6.0 SDK or later
- Any text editor or IDE (Visual Studio, VS Code, Rider)

### Installation

1. Clone the repository:
```bash
git clone https://github.com/mahalakshmilatha/enademoproject.git
cd enademoproject
```

2. Navigate to the API project:
```bash
cd src/GrainBroker.API
```

3. Build the project:
```bash
dotnet build
```

4. Run the application:
```bash
cd GrainBroker.API
dotnet run
```

The API will be available at:
- HTTP: `http://localhost:5000`
- HTTPS: `https://localhost:5001`
- Swagger UI: `https://localhost:5001/swagger` or `http://localhost:5000/swagger`

### Swagger UI

The API includes interactive Swagger documentation where you can test all endpoints:

![Swagger UI](https://github.com/user-attachments/assets/6bae441c-5b6f-458f-899f-c6de7b3631ba)

## Testing the API

You can test the API using:

1. **Swagger UI** - Navigate to `http://localhost:5000/swagger` in your browser for interactive API documentation
2. **cURL** - Use command-line tools to test endpoints
3. **Postman** - Import the OpenAPI specification from `http://localhost:5000/swagger/v1/swagger.json`

### Example API Calls

```bash
# Get all suppliers
curl http://localhost:5000/api/suppliers

# Get a specific customer
curl http://localhost:5000/api/customers/1

# Create a new grain requirement
curl -X POST http://localhost:5000/api/grainrequirements \
  -H "Content-Type: application/json" \
  -d '{
    "customerId": 1,
    "grainType": "Wheat",
    "quantity": 5000,
    "requiredByDate": "2025-11-15T00:00:00",
    "status": "Pending"
  }'

# Get all requirements with customer and supplier details
curl http://localhost:5000/api/grainrequirements
```

## API Endpoints

### Suppliers
- `GET /api/suppliers` - Get all suppliers
- `GET /api/suppliers/{id}` - Get supplier by ID
- `POST /api/suppliers` - Create new supplier
- `PUT /api/suppliers/{id}` - Update supplier
- `DELETE /api/suppliers/{id}` - Delete supplier

### Customers
- `GET /api/customers` - Get all customers
- `GET /api/customers/{id}` - Get customer by ID
- `POST /api/customers` - Create new customer
- `PUT /api/customers/{id}` - Update customer
- `DELETE /api/customers/{id}` - Delete customer

### Grain Requirements
- `GET /api/grainrequirements` - Get all requirements (with customer and supplier details)
- `GET /api/grainrequirements/{id}` - Get requirement by ID
- `POST /api/grainrequirements` - Create new requirement
- `PUT /api/grainrequirements/{id}` - Update requirement
- `DELETE /api/grainrequirements/{id}` - Delete requirement

## Sample Data

The system includes sample CSV files in the `SampleData` directory:
- `suppliers.csv` - 8 sample grain suppliers
- `customers.csv` - 6 sample customers

These files are automatically imported when the application starts for the first time.

## CSV Format

### Suppliers CSV Format
```csv
Name,Location,Capacity,PricePerUnit,GrainType
Midwest Grain Co,Iowa,50000,12.50,Wheat
```

### Customers CSV Format
```csv
Name,Location,ContactEmail,ContactPhone
Artisan Bakery Co,New York,orders@artisanbakery.com,555-0101
```

## Future Enhancements

### Potential Extensions
1. **Frontend Dashboard**: React/Angular dashboard for data visualization
2. **Authentication**: OAuth 2.0 / OpenID Connect implementation
3. **Role-Based Access**: Admin, Broker, Customer roles
4. **Analytics**: 
   - Demand forecasting
   - Optimal supplier selection algorithms
   - Price trend analysis
   - Historical data reporting
5. **Advanced Features**:
   - Real-time notifications
   - Automated matching of requirements to suppliers
   - Integration with external grain market APIs
   - Bulk operations and batch processing

## Technology Justification

### Why SQLite?
- **Portability**: Single file database, easy to deploy
- **Simplicity**: No separate database server needed
- **Development Speed**: Fast setup and iteration
- **Production Ready**: Can be upgraded to PostgreSQL/SQL Server later

### Why Entity Framework Core?
- **Code-First Approach**: Database schema generated from models
- **LINQ Support**: Type-safe queries
- **Migrations**: Version control for database schema
- **Cross-Platform**: Works on Windows, Linux, macOS

### Why ASP.NET Core?
- **Performance**: High-throughput web framework
- **Cross-Platform**: Runs anywhere
- **Built-in DI**: Clean dependency injection
- **OpenAPI Support**: Automatic API documentation with Swagger

## Contributing

This is a demonstration project showcasing backend development capabilities, data modeling, and API design for grain broker management systems.