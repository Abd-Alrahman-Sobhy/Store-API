# 🏪 Store API

<div align="center">

![ASP.NET Core](https://img.shields.io/badge/ASP.NET%20Core-Web%20API-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![C#](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=csharp&logoColor=white)
![Entity Framework](https://img.shields.io/badge/Entity%20Framework%20Core-6B2C91?style=for-the-badge&logo=nuget&logoColor=white)
![SQL Server](https://img.shields.io/badge/SQL%20Server-CC2927?style=for-the-badge&logo=microsoftsqlserver&logoColor=white)

A **RESTful Store API** built with **ASP.NET Core**, exploring key API development concepts including filtering, searching, sorting, and pagination.

</div>

---

## 📋 Table of Contents

- [Overview](#-overview)
- [Features](#-features)
- [Tech Stack](#-tech-stack)
- [Project Structure](#-project-structure)
- [Getting Started](#-getting-started)
- [Configuration](#-configuration)
- [API Endpoints](#-api-endpoints)

---

## 🌟 Overview

Store API is a **.NET Web API** project that simulates a product store backend. It serves as a hands-on exploration of building robust REST APIs with features like dynamic **filtering**, **searching**, **sorting**, and **pagination** — patterns that are essential in any real-world API.

---

## 🚀 Features

- 📦 **Products CRUD** — Create, read, update, and delete store products
- 🔍 **Search** — Query products by name or description
- 🗂️ **Filtering** — Filter products by category, price range, and more
- 🔃 **Sorting** — Sort results by any field (ascending / descending)
- 📄 **Pagination** — Control page size and navigate through large result sets
- ✅ **Validation** — Input validation with meaningful error responses
- 🌐 **RESTful Design** — Clean, consistent endpoint structure

---

## 🧰 Tech Stack

| Technology | Purpose |
|---|---|
| **C#** | Primary language |
| **ASP.NET Core Web API** | REST API framework |
| **Entity Framework Core** | ORM & database access |
| **SQL Server** | Relational database |

---

## 📁 Project Structure

```
Store-API/
├── ApiTest/                      # Main API project
│   ├── Controllers/              # API endpoint handlers
│   ├── Models/                   # Domain entities & view models
│   ├── DTOs/                     # Data Transfer Objects
│   ├── Services/                 # Business logic layer
│   ├── Repositories/             # Data access layer
│   ├── Helpers/                  # Filtering, sorting & pagination helpers
│   ├── Data/                     # DbContext & EF Core configuration
│   ├── Migrations/               # EF Core database migrations
│   ├── appsettings.json          # App configuration
│   └── Program.cs                # Entry point & middleware pipeline
└── ApiTest.sln                   # Solution file
```

---

## ⚡ Getting Started

### Prerequisites

- [.NET SDK](https://dotnet.microsoft.com/download)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) or SQL Server Express
- [Visual Studio 2022+](https://visualstudio.microsoft.com/) or [VS Code](https://code.visualstudio.com/)

### Installation

**1. Clone the repository**
```bash
git clone https://github.com/Abd-Alrahman-Sobhy/Store-API.git
cd Store-API
```

**2. Restore dependencies**
```bash
dotnet restore
```

**3. Update the connection string** (see [Configuration](#-configuration))

**4. Apply database migrations**
```bash
dotnet ef database update --project ApiTest
```

**5. Run the API**
```bash
dotnet run --project ApiTest
```

The API will be available at `https://localhost:5001`. Swagger UI is accessible at `/swagger`.

---

## ⚙️ Configuration

Update `appsettings.json` in the `ApiTest` project:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=.;Database=StoreDB;Trusted_Connection=True;TrustServerCertificate=True;"
  }
}
```

| Key | Description |
|---|---|
| `ConnectionStrings:DefaultConnection` | Your SQL Server connection string |

---

## 📡 API Endpoints

### 📦 Products

| Method | Endpoint | Description |
|---|---|---|
| `GET` | `/api/products` | Get all products (supports filtering, sorting & pagination) |
| `GET` | `/api/products/{id}` | Get a product by ID |
| `POST` | `/api/products` | Create a new product |
| `PUT` | `/api/products/{id}` | Update a product |
| `DELETE` | `/api/products/{id}` | Delete a product |

---

<div align="center">

Made with ❤️ by [Abd-Alrahman Sobhy](https://github.com/Abd-Alrahman-Sobhy)

⭐ If you find this project helpful, please consider giving it a star!

</div>
