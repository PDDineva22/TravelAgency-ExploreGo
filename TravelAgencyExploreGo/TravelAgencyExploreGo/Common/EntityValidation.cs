namespace TravelAgencyExploreGo.Common
{
    public class EntityValidation
    {
        // User Begin
        public const int userFirstNameLengthMax = 50;
        public const int userFirstNameLengthMin = 1;
        public const int userLastNameLengthMax = 50;
        public const int userLastNameLengthMin = 1;
        // User End

        // Destination Begin
        public const int destinationNameLengthMax = 15;
        public const int destinationNameLengthMin = 2;
        public const int destinationCountryLengthMax = 20;
        public const int destinationCountryLengthMin = 2;
        public const int destinationDescriptionLengthMax = 30;
        public const int destinationDescriptionLengthMin = 5;
        public const int destinationImageUrlLengthMax = 500;
        // Destination End

        // Trip Begin
        public const int tripTitleLengthMax = 20;
        public const int tripTitleLengthMin = 5;
        public const string tripPraceValueMax = "100000";
        public const string tripPraceValueMin = "0.10";
        public const int tripAvailableSeatsCountMax = 1000;
        public const int tripAvailableSeatsCountMin = 1;
        // Trip End

        // Booking Begin
        public const int bookingPeopleCountValueMax = 1000;
        public const int bookingPeopleCountValueMin = 1;
        public const string bookingTotalPriceValueMax = "100000";
        public const string bookingTotalPriceValueMin = "10";
        // Booking End
    }
}
