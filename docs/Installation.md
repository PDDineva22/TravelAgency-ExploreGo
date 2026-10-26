
# Installation Guide

Follow these steps to set up and run ExploreGo locally.

## Prerequisites

Make sure you have installed:

- .NET 8 SDK
- Visual Studio 2022
- Microsoft SQL Server or SQL Server Express
- SQL Server Management Studio (optional)

## Getting Started

### 1. Clone the Repository

```bash
git clone YOUR_REPOSITORY_URL
```

Alternatively, download the project as a ZIP file.

### 2. Open the Project

Open the solution in Visual Studio 2022 and restore the NuGet packages.

You can also restore them manually:

```bash
dotnet restore
```

## NuGet Packages

ExploreGo uses the following main packages:

- `Microsoft.EntityFrameworkCore.SqlServer` — SQL Server integration
- `Microsoft.EntityFrameworkCore.Tools` — Database migrations
- `Microsoft.EntityFrameworkCore.Design` — EF Core design-time tools
- `Microsoft.AspNetCore.Identity.EntityFrameworkCore` — User authentication and roles

All required packages are restored automatically from the project files.

## Database Seeding

ExploreGo includes two seeders that provide sample data for testing:

- **ExploreGoSeeder** — Adds sample destinations and trips.
- **IdentitySeeder** — Creates the Admin role and a default administrator account.

### Demo Administrator Account

| Email | Password |
|-------|----------|
| `admin@explorego.com` | `Admin123!` |

The seeders run automatically when the application starts and check for existing data to avoid duplicates.

> The administrator credentials are intended for local testing only.
