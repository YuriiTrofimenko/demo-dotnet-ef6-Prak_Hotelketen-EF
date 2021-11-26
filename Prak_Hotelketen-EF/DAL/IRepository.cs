using System.Collections.Generic;
using HK.BL.Domain;

namespace HK.DAL
{
    public interface IRepository
    {
        IEnumerable<Hotel> ReadAllHotels();
        int CountAllHotels();
        Hotel ReadHotel(int id);
        Hotel ReadHotel(string name);
        Hotel ReadHotelWithMaxCapacity();
        IEnumerable<Hotel> ReadHotelsWithRestaurant();
        IEnumerable<Hotel> ReadHotelsOfType(HotelType type);
        IEnumerable<Hotel> ReadHotelsOfAYear(int year);
        IEnumerable<Hotel> ReadHotelsOfZipCode(string zipCode);
        IEnumerable<Hotel> ReadHotelsWithLetterOrWord(string text);
        void CreateHotel(Hotel hotelToInsert);
        void UpdateHotel(int hotelId, double nieuwePrijs);
        void DeleteHotel(Hotel hotelToDelete);
    }
}