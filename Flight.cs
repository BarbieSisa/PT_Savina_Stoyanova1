using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer
{
    public class Flight
    {
        public int ID { get; set; }
        public string DestinationName { get; set; }
        [Range(1, 1500, ErrorMessage = "Flight time must be [1;1500]")]
        public int? FlightTime { get; set; }
        public List<FlightsReservations> Reservations { get; set; }
        private Flight()
        {
            Reservations = new List<FlightsReservations>();
        }
        public Flight(int iD, string destinationName, int? flightTime)
        {
            ID = iD;
            DestinationName = destinationName;
            FlightTime = flightTime;
            Reservations = new List<FlightsReservations>();
        }

    }
}
