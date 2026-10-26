
<div align="center">

<img src="docs/exploreGo-logo.png" alt="ExploreGo Logo" width="600">

### Discover. Explore. Travel.

**Your next adventure starts here.**

A travel booking web application built with ASP.NET Core MVC.

<br>

<a href="README.md">
  <img src="https://img.shields.io/badge/OVERVIEW-0969DA?style=for-the-badge" alt="Overview">
</a>
<a href="docs/INSTALLATION.md">
  <img src="https://img.shields.io/badge/INSTALLATION-30363D?style=for-the-badge" alt="Installation">
</a>
<a href="docs/FEATURES.md">
  <img src="https://img.shields.io/badge/FEATURES-30363D?style=for-the-badge" alt="Features">
</a>
<a href="docs/ARCHITECTURE.md">
  <img src="https://img.shields.io/badge/ARCHITECTURE-30363D?style=for-the-badge" alt="Architecture">
</a>
<a href="docs/SCREENSHOTS.md">
  <img src="https://img.shields.io/badge/SCREENSHOTS-30363D?style=for-the-badge" alt="Screenshots">
</a>

</div>

---

## 🌍 About ExploreGo

**ExploreGo** is a travel agency web application designed to make discovering destinations and booking trips simple, convenient, and enjoyable.

The platform allows users to explore travel destinations, browse available trips, discover exclusive offers, and book their next adventure.

Registered users can manage their reservations, while administrators have access to a dedicated administration panel for managing trips, destinations, and booking requests.

The application was developed as part of the **SoftUni ASP.NET Fundamentals Project Assignment**, demonstrating MVC architecture, database integration, CRUD operations, authentication, validation, and responsive web design.

---

## ✨ Main Features

### ✈️ For Travelers

- **Explore Destinations** — Discover different destinations and learn more about them.
- **Browse Trips** — View available trips, dates, prices, and available seats.
- **Exclusive Deals** — Discover special offers with discounted prices.
- **User Registration & Login** — Create an account and securely sign in.
- **Book Trips** — Make reservations for one or more travelers.
- **Manage Bookings** — View personal bookings and cancel eligible reservations.
- **Responsive Design** — Browse the website on desktop and mobile devices.

### 🛠️ For Administrators

- **Destination Management** — Create, edit, view, and delete destinations.
- **Trip Management** — Add, update, view, and delete trips.
- **Booking Management** — Review incoming reservations.
- **Approve & Reject Bookings** — Manage reservation requests and their statuses.
- **Seat Management** — Keep available seats updated when bookings are confirmed or cancelled.
- **Role-Based Access** — Restrict administration features to authorized users.

<div align="center">

**[Explore All Features](docs/FEATURES.md)**

</div>

---

## 💻 Technologies Used

ExploreGo is developed using the following technologies and tools.

<div align="center">

### Backend & Framework

<img src="https://skillicons.dev/icons?i=cs,dotnet" alt="C# and .NET" />
<br>

**C# · .NET 8 · ASP.NET Core MVC · Razor Views**
<br>

### Database & Data Access

<img src="https://skillicons.dev/icons?i=mongodb" height="0" alt="">

<img src="https://img.shields.io/badge/Microsoft_SQL_Server-CC2927?style=for-the-badge" alt="SQL Server">
<img src="https://img.shields.io/badge/Entity_Framework_Core-512BD4?style=for-the-badge" alt="Entity Framework Core">
<br>

**Microsoft SQL Server · Entity Framework Core · Code-First Migrations**
<br>

### Frontend

<img src="https://skillicons.dev/icons?i=html,css,js,bootstrap" alt="HTML, CSS, JavaScript and Bootstrap" />

<br>

**HTML5 · CSS3 · JavaScript · Bootstrap**

<br>

### Development Tools

<img src="https://skillicons.dev/icons?i=visualstudio,git,github" alt="Visual Studio, Git and GitHub" />

<br>

**Visual Studio · Git · GitHub**

</div>

---

## 🏗️ Project Architecture

ExploreGo follows the **Model-View-Controller (MVC)** architectural pattern.

The application is organized into separate layers to keep its responsibilities clear and make the code easier to understand and maintain.

| Layer | Responsibility |
|------|----------------|
| **Web** | Controllers, Razor Views, ViewModels, and user interface |
| **Services** | Application business logic and service interfaces |
| **Data** | Database context, entity models, migrations, and seeders |
| **Models** | Shared application models |
| **Common** | Shared code and constants |

### Main Entities

The application works with four main entities:

- **User** — Represents a registered application user.
- **Destination** — Stores information about travel destinations.
- **Trip** — Represents a trip with dates, prices, and available seats.
- **Booking** — Stores reservations made by users.

The application uses **Dependency Injection** and service interfaces to separate business logic from the controllers.

<div align="center">

**[Explore Project Architecture](docs/ARCHITECTURE.md)**

</div>

---

## 🚀 Installation & Setup

ExploreGo uses **.NET 8**, **Entity Framework Core**, and **Microsoft SQL Server**.

To run the project locally, you need:

- .NET 8 SDK
- Microsoft SQL Server, SQL Server Express, or LocalDB
- Visual Studio 2022 or a compatible development environment
- The required NuGet packages
- An initialized database using Entity Framework Core migrations

### Quick Setup

**1. Clone the repository**

```bash
git clone YOUR_REPOSITORY_URL
```

**2. Open the solution in Visual Studio**

**3. Configure the SQL Server connection string**

The application uses the connection string named `DefaultConnection` in `appsettings.json`.

Example for a local default SQL Server instance:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=.;Database=TravelAgencyDb;Trusted_Connection=True;TrustServerCertificate=True;"
  }
}
```

**4. Apply database migrations**

In Visual Studio, open **Package Manager Console**, select `TravelAgencyExploreGo.Data` as the default project, and run:

```powershell
Update-Database
```

**5. Run the application**

Set the web project as the startup project and press **F5**.

The application initializes its sample data and administrator account during startup.

For the complete installation guide, including database configuration and troubleshooting, open the dedicated installation page.

<div align="center">

### 📖 [How to Install & Run ExploreGo](docs/INSTALLATION.md)

</div>

---

## 🔐 Authentication & Authorization

ExploreGo uses **ASP.NET Core Identity** for account management and authentication.

The application supports two main types of users:

| Role | Permissions |
|------|-------------|
| **User** | Browse trips, make reservations, and manage personal bookings |
| **Admin** | Manage destinations, trips, and booking requests |

### Development Administrator Account

For local testing, the application seeds an administrator account:

| Email | Password |
|-------|----------|
| `admin@explorego.com` | `Admin123!` |

> **Important:** This account is intended for local development and project evaluation only. Its credentials should be changed before deploying the application publicly.

Regular users can register through the application's registration page.

---

## 🛡️ Validation & Data Integrity

ExploreGo implements server-side and client-side validation to help prevent incorrect data from being submitted.

The application uses:

- Data Annotation attributes on models
- `ModelState` validation in controllers
- Razor validation messages
- Client-side form validation
- Business rules for trip dates, pricing, and available seats
- Booking status checks and role-based restrictions

These validations help protect the database and ensure that bookings follow the application's business rules.

---

## 📸 Application Screenshots

The Screenshots section presents the main pages of the application, including the homepage, destinations, trips, booking interface, and administration panel.

<div align="center">

### 🖼️ [View Application Screenshots](docs/SCREENSHOTS.md)

</div>

---

## 📚 Documentation

For more information, explore the documentation:

| Documentation | Description |
|---------------|-------------|
| [Overview](README.md) | General information about ExploreGo |
| [Installation](docs/INSTALLATION.md) | How to configure and run the application |
| [Features](docs/FEATURES.md) | Detailed explanation of application features |
| [Architecture](docs/ARCHITECTURE.md) | Project structure, layers, and data models |
| [Screenshots](docs/SCREENSHOTS.md) | Application interface and screenshots |

---

<div align="center">

### ✈️ ExploreGo

**Discover. Explore. Travel.**

Developed for the **SoftUni ASP.NET Fundamentals** course.

</div>
