# Order Integration API

## Overview
Integration API is a robust middleware solution designed to process supplier-side orders through flat file integration, price validation, 
stock management, and ERP system communication. The system handles fixed-length order documents (.sdf files) and performs comprehensive validation and processing workflows.

## Features

### Order Processing
- Parses fixed-length flat files (.sdf)
- Validates order content and structure
- Processes both header and article records

### Price Management
- Validates unit prices against reference database
- Supports default and buyer-specific pricing
- Automated price mismatch notifications

### Stock Management
- Real-time stock availability checking
- ERP system integration
- Automated order abort for insufficient stock
- Stock update synchronization

### System Integration
- XML order transformation
- HTTP-based order submission
- Account manager notification system

## Technical Architecture

### File Structure
#### Order Header Format
| Column Index | Position | Length | Description |
|--------------|----------|---------|-------------|
| 1 | 0 | 3 | File type identifier (ORD) |
| 2 | 3 | 20 | Order number |
| 3 | 23 | 13 | Order date |
| 4 | 36 | 13 | Buyer EAN code |
| 5 | 49 | 13 | Supplier EAN code |
| 6 | 62 | 100 | Comment |

#### Article Line Format
| Column Index | Position | Length | Description |
|--------------|----------|---------|-------------|
| 1 | 0 | 13 | Article EAN code |
| 2 | 13 | 65 | Article description |
| 3 | 78 | 10 | Quantity |
| 4 | 88 | 10 | Unit price |

## Getting Started

### Prerequisites
- .NET Core SDK
- SQL Server (for price reference database)
- Access to ERP system endpoints

### Installation
1. Clone the repository
```bash
git clone https://github.com/bekair/IntegrationApi.git
```

2. Update the configuration in `appsettings.json`
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "your_connection_string"
  },
  "ErpSystem": {
    "BaseUrl": "erp_system_url",
    "ApiKey": "your_api_key"
  }
}
```

3. Run database migrations
```bash
dotnet ef database update
```

4. Build and run the application
```bash
dotnet build
dotnet run
```

## Usage

### Sample Order File
```
ORD0000000000000001   20240116       4006381333931  4006381333932  Order for Q1        
4006381333933  Article Description                                       0000001000000000100
```

### Processing an Order
1. Place the .sdf file in the designated input directory
2. System automatically processes the file
3. Check logs for processing status and notifications

## Technologies
- .NET Core
- Entity Framework Core
- AutoMapper
- FluentValidation
- xUnit (for testing)

## License
This project is licensed under the MIT License - see the LICENSE file for details.
