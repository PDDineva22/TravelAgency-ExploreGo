
<div align="center">

# ExploreGo — Features

Discover destinations, explore trips, and manage your bookings.

<img src="https://img.shields.io/badge/TRAVELER_FEATURES-0969DA?style=for-the-badge" alt="Traveler Features">
<img src="https://img.shields.io/badge/ADMIN_PANEL-00897B?style=for-the-badge" alt="Admin Panel">
<img src="https://img.shields.io/badge/BOOKING_SYSTEM-6F42C1?style=for-the-badge" alt="Booking System">

</div>

---

## Destinations & Trips

- Browse available destinations and trips.
- View trip details, including dates, prices, images, and available seats.
- Discover exclusive deals with discounted prices.
- Explore travel offers without creating an account.

## User Accounts

- Register and log in using ASP.NET Core Identity.
- Access personal bookings after logging in.
- Manage reservations through a personal booking section.

## Booking System

Users can book trips for one or more travelers. The total price is calculated automatically based on the selected trip and number of people.

### Booking Statuses

| Status | Description |
|--------|-------------|
| ?? **Pending** | Waiting for administrator approval |
| ?? **Confirmed** | Approved by an administrator |
| ?? **Cancelled** | Cancelled by the user or rejected by an administrator |

Users can view their bookings and cancel eligible reservations before the trip starts.

Available seats are updated when a booking is confirmed or a confirmed booking is cancelled.

---

<div align="center">

<img src="https://img.shields.io/badge/ADMINISTRATION-00897B?style=for-the-badge" alt="Administration">

</div>

## Administration Panel

The administration panel is available only to users with the **Admin** role.

### Destination Management

Administrators can create, view, edit, and delete destinations.

Destinations associated with existing trips cannot be deleted.

### Trip Management

Administrators can:

- Create trips with destinations, dates, prices, images, and available seats.
- Edit existing trip information.
- Delete trips that have no bookings.
- Add discounted prices for exclusive offers.

### Booking Management

Administrators can view all reservations and approve or reject pending bookings.

---

## Validation & Security

ExploreGo includes server-side and client-side validation to help maintain correct data.

- Validation of trip dates and prices.
- Available-seat checks before accepting bookings.
- Role-based authorization for administrator pages.
- User-specific authorization when cancelling bookings.
- Restrictions on editing or deleting trips with existing bookings.

---

<div align="center">

<a href="../README.md">
  <img src="https://img.shields.io/badge/Back_to_Overview-0969DA?style=flat-square" alt="Back to Overview">
</a>

</div>

