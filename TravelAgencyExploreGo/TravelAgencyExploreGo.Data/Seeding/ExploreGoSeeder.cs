
using Microsoft.EntityFrameworkCore;
using TravelAgencyExploreGo.Data.Models.Entities;

namespace TravelAgencyExploreGo.Data.Seeding
{
    public class ExploreGoSeeder
    {
        public static async Task SeedAsync(TravelAgencyDbContext dbContext)
        {
            if (!await dbContext.Destinations.AnyAsync())
            {
                var destinations = new List<Destination>
                {
                    new Destination
                    {
                        Name = "Istanbul",
                        Country = "Turkey",
                        Description = "Discover a vibrant city where Europe meets Asia.",
                        ImageUrl = "/images/destinations/turkey-istanbul.png"
                    },
                    new Destination
                    {
                        Name = "Antalya",
                        Country = "Turkey",
                        Description = "Relax on beautiful Mediterranean beaches.",
                        ImageUrl = "/images/destinations/turkey-antalya.png"
                    },
                    new Destination
                    {
                        Name = "Berlin",
                        Country = "Germany",
                        Description = "Explore a city filled with history, culture and art.",
                        ImageUrl = "/images/destinations/germany-berlin.png"
                    },
                    new Destination
                    {
                        Name = "Munich",
                        Country = "Germany",
                        Description = "Experience Bavarian culture and beautiful architecture.",
                        ImageUrl = "/images/destinations/germany-munich.png"
                    },
                    new Destination
                    {
                        Name = "Santorini",
                        Country = "Greece",
                        Description = "Admire white houses, blue domes and beautiful sea views.",
                        ImageUrl = "/images/destinations/greece-santorini.png"
                    },
                    new Destination
                    {
                        Name = "Rome",
                        Country = "Italy",
                        Description = "Discover ancient monuments and Italian culture.",
                        ImageUrl = "/images/destinations/italy-rome.png"
                    },
                    new Destination
                    {
                        Name = "Barcelona",
                        Country = "Spain",
                        Description = "Enjoy beautiful architecture, beaches and vibrant streets.",
                        ImageUrl = "/images/destinations/spain-barcelona.png"
                    },
                    new Destination
                    {
                        Name = "Hurghada",
                        Country = "Egypt",
                        Description = "Explore beautiful beaches and the Red Sea.",
                        ImageUrl = "/images/destinations/egypt-hurghada.png"
                    },
                    new Destination
                    {
                        Name = "Phuket",
                        Country = "Thailand",
                        Description = "Discover tropical beaches and stunning islands.",
                        ImageUrl = "/images/destinations/thailand-phuket.png"
                    },
                    new Destination
                    {
                        Name = "Zurich",
                        Country = "Switzerland",
                        Description = "Enjoy beautiful lakes, Swiss streets and Alpine scenery.",
                        ImageUrl = "/images/destinations/switzerland-zurich.png"
                    }
                };

                await dbContext.Destinations.AddRangeAsync(destinations);
                await dbContext.SaveChangesAsync();
            }

            if (await dbContext.Trips.AnyAsync())
                return;

            var destinationsByName = await dbContext.Destinations
                .ToDictionaryAsync(d => d.Name);

            var today = DateTime.Today;

            Trip CreateTrip(string destinationName, string title,
                string description, decimal price, decimal? discountPrice,
                int seats, int startAfterDays, int duration)
            {
                var destination = destinationsByName[destinationName];

                return new Trip
                {
                    Id = Guid.NewGuid(),
                    Title = title,
                    Description = description,
                    Price = price,
                    DiscountPrice = discountPrice,
                    AvailableSeats = seats,
                    StartDate = today.AddDays(startAfterDays),
                    EndDate = today.AddDays(startAfterDays + duration),
                    DestinationId = destination.Id,
                    Image1 = destination.ImageUrl,
                    Image2 = destination.ImageUrl
                };
            }

            var trips = new List<Trip>
            {
                CreateTrip("Istanbul", "Discover Istanbul",
                    "Explore historic streets, beautiful mosques and the Bosphorus.",
                    650m, 520m, 20, 40, 5),

                CreateTrip("Antalya", "Antalya Summer Escape",
                    "Relax on Mediterranean beaches and explore the Turkish coast.",
                    850m, 680m, 25, 70, 7),

                CreateTrip("Berlin", "Berlin City Break",
                    "Discover famous landmarks, museums and German culture.",
                    550m, null, 20, 55, 4),

                CreateTrip("Munich", "Bavarian Adventure",
                    "Explore Munich and experience traditional Bavarian culture.",
                    700m, null, 18, 85, 5),

                CreateTrip("Santorini", "Santorini Dream Holiday",
                    "Enjoy beautiful sunsets, white villages and amazing sea views.",
                    1200m, 950m, 16, 110, 7),

                CreateTrip("Rome", "Discover Ancient Rome",
                    "Visit the Colosseum, Roman Forum and charming Italian streets.",
                    780m, 620m, 22, 65, 5),

                CreateTrip("Barcelona", "Barcelona Getaway",
                    "Discover colorful streets, famous architecture and beaches.",
                    890m, 720m, 20, 95, 6),

                CreateTrip("Hurghada", "Red Sea Paradise",
                    "Enjoy sunny beaches, coral reefs and snorkeling adventures.",
                    1100m, 880m, 25, 125, 7),

                CreateTrip("Phuket", "Tropical Thailand Escape",
                    "Explore tropical islands, exotic landscapes and sandy beaches.",
                    1600m, null, 15, 155, 10),

                CreateTrip("Zurich", "Swiss Alps Experience",
                    "Discover beautiful lakes, charming streets and the Swiss Alps.",
                    1350m, null, 18, 135, 6)
            };

            await dbContext.Trips.AddRangeAsync(trips);
            await dbContext.SaveChangesAsync();
        }
    }
}
