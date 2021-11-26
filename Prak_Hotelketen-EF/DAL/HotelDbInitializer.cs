using System;
using System.Collections.Generic;
using System.Linq;
using HK.BL.Domain;
using Microsoft.EntityFrameworkCore;

namespace HK.DAL
{
    internal class HotelDbInitializer
    {
        public static void Initialize(HotelDbContext ctx, bool shouldDropCreate)
        {
            if (shouldDropCreate)
            {
                ctx.Database.EnsureDeleted();
            }
            ctx.Database.EnsureCreated();
            if (!ctx.Hotels.Any())
            {
                Seed(ctx);
            }
        }

        private static void Seed(HotelDbContext ctx)
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
            
            ctx.Hotels.Add(h1);
            ctx.Hotels.Add(h2);
            ctx.Hotels.Add(h3);
            ctx.Hotels.Add(h4);

            ctx.SaveChanges();
            DetachAllEntities(ctx);
        }
        
        private static void DetachAllEntities(HotelDbContext ctx)
        {
            var changedEntriesCopy = ctx.ChangeTracker.Entries()
                .Where(e => e.State == EntityState.Added ||
                            e.State == EntityState.Modified ||
                            e.State == EntityState.Deleted)
                .ToList();
            foreach (var entry in changedEntriesCopy)
                entry.State = EntityState.Detached;
        }
    }
}