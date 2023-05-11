using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BussinessLayer
{
    public class Reservation
    {
        [Key]
        public int ID { get; set; }
        [Range(0, 300, ErrorMessage = "Reserved seats must be [0;300]")]
        public int ReservedSeats { get; set; }
        [Range(0, 300, ErrorMessage = "Tickets must be [0;300]")]
        public int Tickets { get; set; }
        [Range(0, 30000, ErrorMessage = "Price must be [0;30000]")]
        public decimal Price { get; set; }
        public Airport Airport { get; set; }

        [ForeignKey("AirportID")]
        public int AirportID { get; set; }
        public List<FlightsReservations> Flights { get; set; }
         private Reservation()
        {
            Flights = new List<FlightsReservations>(); 
        }

        public Reservation(int iD, int reservedSeats, int tickets, decimal price, int airportID)
        {
            ID = iD;
            ReservedSeats = reservedSeats;
            Tickets = tickets;
            Price = price;
            AirportID = airportID;
            Flights = new List<FlightsReservations>();
        }
    }
}
