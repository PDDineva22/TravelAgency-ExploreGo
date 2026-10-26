using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgencyExploreGo.Common;
using TravelAgencyExploreGo.Data;
using TravelAgencyExploreGo.Data.Models.Entities;
using TravelAgencyExploreGo.Data.Models.Enums;
using TravelAgencyExploreGo.Models.DTOs.Trip;
using TravelAgencyExploreGo.Services.Contracts;

namespace TravelAgencyExploreGo.Services.Services
{
    public class BookingService : IBookingService
    {
        private readonly TravelAgencyDbContext dbContext;

        public BookingService(TravelAgencyDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        /// <summary>
        /// Creates a new booking request for a trip
        /// Checks the user, trip availability and calculates the total price
        /// </summary>
        public bool CreateBooking(Guid userId, CreateBookingDto dto)
        {
            if(userId == Guid.Empty || dto.TripId == Guid.Empty || dto.PeopleCount < EntityValidation.BookingPeopleCountValueMin
                || dto.PeopleCount > EntityValidation.BookingPeopleCountValueMax)
            {
                return false;
            }
            bool userExist = dbContext.Users.Any(u => u.Id == userId);
            Trip trip = dbContext.Trips.Find(dto.TripId);
            
            if(!userExist || trip == null || trip.StartDate <= DateTime.UtcNow || dto.PeopleCount > trip.AvailableSeats)
            {
                return false;
            }
            // Use the discounted price if the trip has an active discount
            decimal price = trip.DiscountPrice.HasValue && trip.DiscountPrice.Value < trip.Price
                ? trip.DiscountPrice.Value
                : trip.Price;

            decimal totalPrice = price * dto.PeopleCount;
            if (totalPrice < decimal.Parse(EntityValidation.BookingTotalPriceValueMin, System.Globalization.CultureInfo.InvariantCulture) ||totalPrice > decimal.Parse(
                       EntityValidation.BookingTotalPriceValueMax,
                          System.Globalization.CultureInfo.InvariantCulture))
            {
                return false;
            }

            Booking newBooking = new Booking
            {
                Id = Guid.NewGuid(),
                UserId = userId,
                TripId = dto.TripId,
                PeopleCount = dto.PeopleCount,
                TotalPrice = totalPrice
            };

            dbContext.Bookings.Add(newBooking);
            dbContext.SaveChanges();

            return true;
        }
        /// <summary>
        /// Gets all bookings with their trips and users for the admin panel
        /// </summary>
        public List<Booking> GetAllBookings()
        {
            List<Booking> allBookings = dbContext.Bookings
                .Include(b => b.Trip)
                .Include(b => b.User)
                .OrderByDescending(b => b.BookingDate)
                .ThenBy(b => b.TotalPrice)
                .ThenBy(b => b.PeopleCount)
                .ToList();

            return allBookings;
        }

        public List<Booking> GetUserBookings(Guid userId)
        {
            List<Booking> allBookings = dbContext.Bookings
                .Include(b => b.Trip)
                .Where(b => b.UserId == userId)
                .OrderByDescending(b => b.TotalPrice)
                .ThenByDescending(b => b.BookingDate)
                .ToList();

            return allBookings;
        }

        public bool RejectBooking(Guid bookingId)
        {
            Booking? booking = dbContext.Bookings.Find(bookingId);

            if(booking == null) return false;
            if(booking.BookingStatus != BookingStatus.Pending) return false;

            booking.BookingStatus = BookingStatus.Cancelled;
            dbContext.SaveChanges();

            return true;
        }
        public bool ConfirmBooking(Guid bookingId)
        {
            Booking? booking = dbContext.Bookings
                .Include(b => b.Trip)
                .FirstOrDefault(b => b.Id == bookingId);
            
            // Here is used shorter way of if conditiion
            if(booking == null) return false;
            if(booking.BookingStatus != BookingStatus.Pending) return false;
            if(booking.Trip.StartDate <= DateTime.UtcNow) return false;
            if (booking.PeopleCount > booking.Trip.AvailableSeats) return false;

            // Seats are reduced only after the admin confirms the booking
            booking.Trip.AvailableSeats -= booking.PeopleCount;
            booking.BookingStatus = BookingStatus.Confirmed;

            dbContext.SaveChanges();

            return true;
        }
        /// <summary>
        /// Allows a user to cancel their own booking before the trip starts
        /// </summary>
        public bool CancelBooking(Guid bookingId, Guid userId)
        {
            Booking? booking = dbContext.Bookings
                .Include(b => b.Trip)
                .FirstOrDefault(b => b.Id == bookingId && b.UserId == userId);

            // Here is used shortened way for the validation conditions
            if (booking == null) return false;
            if (booking.BookingStatus == BookingStatus.Cancelled) return false;
            if (booking.Trip.StartDate <= DateTime.UtcNow) return false;

            // Return the reserved seats if the booking was already confirmed
            if (booking.BookingStatus == BookingStatus.Confirmed)
            {
                booking.Trip.AvailableSeats += booking.PeopleCount;
            }

            booking.BookingStatus = BookingStatus.Cancelled;

            dbContext.SaveChanges();

            return true;
        }
    }
}
