using System;
using HK.BL.Domain;

namespace HK.DAL
{
    internal class HotelDbInitializer
    {
        private static void Seed()
        {
            Hotel h1 = new Hotel()
            {
                Type = HotelType.Hotel,
                Name = "Radison",
                Capacity = 150,
                Country = "BE",
                Price = 564.14,
                FoundingDate = new DateTime(2015, 12, 1),
                ZipCode = "2000",
                HasRestaurant = true
            };

            Hotel h2 = new Hotel()
            {
                Type = HotelType.ParkFly,
                Name = "Accor",
                Capacity = 250,
                Country = "be",
                Price = 60.10,
                FoundingDate = new DateTime(1999, 12, 11),
                ZipCode = "2000"
            };

            Hotel h3 = new Hotel()
            {
                Type = HotelType.ParkFly,
                Name = "Charion Shiphol",
                Capacity = 250,
                Country = "nl",
                Price = 49.99,
                FoundingDate = new DateTime(2015, 06, 16),
                ZipCode = "NL-1000",
                HasRestaurant = true
            };

            Hotel h4 = new Hotel()
            {
                Type = HotelType.ParkFly,
                Name = "Sandman",
                ZipCode = "NL-2000",
                HasRestaurant = false
            };
        }
    }
}