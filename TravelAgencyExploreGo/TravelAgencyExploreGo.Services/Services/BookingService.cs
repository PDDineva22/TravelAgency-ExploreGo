using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgencyExploreGo.Common;
using TravelAgencyExploreGo.Data;
using TravelAgencyExploreGo.Data.Models.Entities;
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

            decimal price = trip.DiscountPrice.HasValue && trip.DiscountPrice.Value < trip.Price
                ? trip.DiscountPrice.Value
                : trip.Price;

            decimal totalPrice = price * dto.PeopleCount;
            if (totalPrice < decimal.Parse(EntityValidation.BookingTotalPriceValueMin,
                   System.Globalization.CultureInfo.InvariantCulture) ||totalPrice > decimal.Parse(
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
    }
}
