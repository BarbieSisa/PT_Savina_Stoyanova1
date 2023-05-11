using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer
{
    public class Airport
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public decimal? TotalProfit { get; set; }
        public List<Reservation> Reservations { get; set; }
        private Airport()
        {
            Reservations = new List<Reservation>();
        }

        public Airport(int iD, string name, decimal? totalProfit)
        {
            ID = iD;
            Name = name;
            TotalProfit = totalProfit;
            Reservations = new List<Reservation>();
        }
    }
}
