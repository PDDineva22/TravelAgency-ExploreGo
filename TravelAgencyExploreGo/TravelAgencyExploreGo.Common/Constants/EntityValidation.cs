namespace TravelAgencyExploreGo.Common
{
    public class EntityValidation
    {
        // User Begin
        public const int UserFirstNameLengthMax = 50;
        public const int UserFirstNameLengthMin = 1;
        public const int UserLastNameLengthMax = 50;
        public const int UserLastNameLengthMin = 1;
        public const int UserPasswordLengthMax = 8;
        public const int UserPasswordLengthMin = 1;
        public const string UserEmailRegex = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
        // User End

        // Destination Begin
        public const int DestinationNameLengthMax = 15;
        public const int DestinationNameLengthMin = 2;
        public const int DestinationCountryLengthMax = 20;
        public const int DestinationCountryLengthMin = 2;
        public const int DestinationDescriptionLengthMax = 200;
        public const int DestinationDescriptionLengthMin = 10;
        public const int DestinationImageUrlLengthMax = 500;
        // Destination End

        // Trip Begin
        public const int TripTitleLengthMax = 100;
        public const int TripTitleLengthMin = 5;
        public const string TripPriceValueMax = "100000";
        public const string TripPriceValueMin = "0.10";
        public const string TripDiscountPriceValueMax = "10000";
        public const string TripDiscountPriceValueMin = "1";
        public const int TripAvailableSeatsCountMax = 500;
        public const int TripAvailableSeatsCountMin = 1;
        public const int TripImageUrlLengthMax = 500;
        public const int TripDescriptionLengthMax = 200;
        public const int TripDescriptionLengthMin = 10;
        // Trip End

        // Booking Begin
        public const int BookingPeopleCountValueMax = 500;
        public const int BookingPeopleCountValueMin = 1;
        public const string BookingTotalPriceValueMax = "100000";
        public const string BookingTotalPriceValueMin = "10";
        // Booking End
    }
}
