using System;
using HK.BL.Domain;

namespace HK.UI.CA
{
    internal static class PrintExtensionMethods
    {
        internal static string AllInfo(this Hotel hotel)
        {
            return String.Format("({0}) {1} ({2}) is founded on {3}, has an average price of {4:0.0}, "
                                 + "\nexists in country {5} (zipcode {6}) "
                                 + "\nhas {7} restaurant and the available capacity is {8}. "
                                 + "\n"
                , hotel.HotelId
                , hotel.Name
                , hotel.Type.ToString()
                , hotel.FoundingDate.HasValue
                    ? hotel.FoundingDate.Value.ToString("dd/MM/yyyy")
                    : "no founding date available"
                , hotel.Price ?? 0
                , String.IsNullOrEmpty(hotel.Country) ? "-" : hotel.Country.ToUpper()
                , hotel.ZipCode
                , hotel.HasRestaurant ? "a" : "no"
                , hotel.Capacity ?? 0
            );
        }

        internal static string ShortInfo(this Hotel hotel)
        {
            return String.Format("({0}) {1} ({2}) "
                , hotel.HotelId
                , hotel.Name
                , hotel.Type.ToString()
            );
        }
    }
}