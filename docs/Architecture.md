
<div align="center">

# Project Architecture

ExploreGo is built with ASP.NET Core MVC and follows a layered architecture to separate the user interface, business logic, and database operations.

<img src="https://img.shields.io/badge/ASP.NET_Core_MVC-512BD4?style=flat-square" alt="ASP.NET Core MVC">
<img src="https://img.shields.io/badge/Entity_Framework_Core-512BD4?style=flat-square" alt="Entity Framework Core">
<img src="https://img.shields.io/badge/SQL_Server-CC2927?style=flat-square" alt="SQL Server">

</div>

---

## Application Layers

### Web Layer

Contains the MVC controllers, Razor Views, ViewModels, and static resources.

It handles user requests and displays information received from the service layer.

### Service Layer

Contains the application's business logic and service interfaces.

The services handle operations such as trip management, reservations, destination management, and user accounts.

### Data Layer

Contains the Entity Framework Core database context, entity models, migrations, and seeders.

It manages data storage and communication with SQL Server.

---

## Main Entities

ExploreGo uses four main entities.

| Entity | Description |
|--------|-------------|
| **User** | Registered users and administrators |
| **Destination** | Countries and travel destinations |
| **Trip** | Available trips, prices, dates, and seats |
| **Booking** | Reservations made by users |

## Entity Relationships

Each destination can have multiple trips. A trip can have multiple bookings, and a user can make multiple reservations.

---

## Design Principles

The application uses:

- **MVC** to separate application data, user interface, and request handling.
- **Dependency Injection** to provide services to controllers.
- **Service Interfaces** to separate business logic from controller actions.
- **Entity Framework Core** for database access and migrations.
- **ASP.NET Core Identity** for authentication and role-based authorization.
- **ViewModels** to pass the required data to Razor Views.

---

<div align="center">

<a href="../README.md">
  <img src="https://img.shields.io/badge/Back_to_Overview-0969DA?style=flat-square" alt="Back to Overview">
</a>

</div>

