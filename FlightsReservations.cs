using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer
{
    public class FlightsReservations
    {
        [ForeignKey("Flight")]
        public int FligthID { get; set; }
        public int ReservationID { get; set; }
        public Flight Flight { get; set; }
        public Reservation Reservation{ get; set; }
        private FlightsReservations()
        {

        }

        public FlightsReservations(int fligthID, int reservationID)
        {
            FligthID = fligthID;
            ReservationID = reservationID;
        }
    }
}
