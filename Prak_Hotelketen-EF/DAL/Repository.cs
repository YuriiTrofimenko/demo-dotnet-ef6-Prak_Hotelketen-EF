using System;
using System.Collections.Generic;
using HK.BL.Domain;

namespace HK.DAL
{
    public class Repository : IRepository
    {
        public IEnumerable<Hotel> ReadAllHotels()
        {
            throw new NotImplementedException();
        }

        public int CountAllHotels()
        {
            throw new NotImplementedException();
        }

        public Hotel ReadHotel(int id)
        {
            throw new NotImplementedException();
        }

        public Hotel ReadHotel(string name)
        {
            throw new NotImplementedException();
        }

        public Hotel ReadHotelWithMaxCapacity()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Hotel> ReadHotelsWithRestaurant()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Hotel> ReadHotelsOfType(HotelType type)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Hotel> ReadHotelsOfAYear(int year)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Hotel> ReadHotelsOfZipCode(string zipCode)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Hotel> ReadHotelsWithLetterOrWord(string text)
        {
            throw new NotImplementedException();
        }

        public void CreateHotel(Hotel hotelToInsert)
        {
            throw new NotImplementedException();
        }

        public void UpdateHotel(int hotelId, double nieuwePrijs)
        {
            throw new NotImplementedException();
        }

        public void DeleteHotel(Hotel hotelToDelete)
        {
            throw new NotImplementedException();
        }
    }
}