using System;
using System.ComponentModel.DataAnnotations;

namespace HK.BL.Domain
{
    public class Hotel
    {
        public int HotelId { get; set; }
        [StringLength(20)]
        [Required]
        public string Name { get; set; }
        [Required]
        public HotelType Type { get; set; }
        public DateTime? FoundingDate { get; set; }
        public string ZipCode { get; set; }
        public string Country { get; set; }
        public bool HasRestaurant { get; set; }
        public double? Price { get; set; }
        public int? Capacity { get; set; }
    }
}