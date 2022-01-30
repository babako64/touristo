using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace SearchService.API.Entities
{
    public class Search
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public IList<Flight> Flights { get; set; }
        public IList<Hotel> Hotels { get; set; }
    }

    public class Flight
    {
        public Guid FlightId { get; set; }
        public int SeatAvailable { get; set; }
        public IList<FlightSection> Sections { get; set; }
    }

    public class FlightSection
    {
        public Guid FlightSectionId { get; set; }
        public string FlightNumber { get; set; }
        public string OriginCityCode { get; set; }
        public string DestinationCityCode { get; set; }
        public string OriginCityName { get; set; }
        public string DestinationCityName { get; set; }
        public string OriginAirportName { get; set; }
        public string DestinationAirportName { get; set; }
        public double Price { get; set; }
        public string Currency { get; set; }
        public string AirlineName { get; set; }
        public TimeSpan FlightSectionDuration { get; set; }
    }

    public class Hotel
    {
        public Guid HotelId { get; set; }
        public string Name { get; set; }
        public short Rate { get; set; }
        public string HotelCode { get; set; }
        public String CityCode { get; set; }
        public string CityName { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Phone { get; set; }

        public IList<HotelRoom> Rooms { get; set; }
    }

    public class HotelRoom
    {
        public Guid HotelRoomId { get; set; }
        public string Category { get; set; }
        public int Beds { get; set; }
        public string BedType { get; set; }
        public Guest Guest { get; set; }
        public double Price { get; set; }
        public string Currency { get; set; }
        public string Description { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
    }

    public class Guest
    {
        public int AdultCount { get; set; }
        public int ChildCount { get; set; }
    }
}
