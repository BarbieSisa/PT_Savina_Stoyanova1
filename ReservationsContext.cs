using BussinessLayer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class ReservationsContext : IDb<Reservation, int>
    {
        private readonly SavinaStoyanova_23DBContext dbContext;

        public ReservationsContext(SavinaStoyanova_23DBContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Create(Reservation item)
        {
            try
            {
                Airport AirportFromDb = dbContext.Airports.Find(item.AirportID);

                if (AirportFromDb != null)
                {
                    item.Airport = AirportFromDb;
                }

                dbContext.Reservations.Add(item);
                dbContext.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Reservation Read(int key, bool useNavigationalProperties = false)
        {
            try
            {
                IQueryable<Reservation> query = dbContext.Reservations;

                if (useNavigationalProperties)
                {
                    query = query.Include(r => r.Airport)
                        
                        .Include(r => r.Flights);
                }

                return query.FirstOrDefault(p => p.ID == key);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<Reservation> ReadAll(bool useNavigationalProperties = false)
        {
            try
            {
                IQueryable<Reservation> query = dbContext.Reservations;

                if (useNavigationalProperties)
                {
                    query = query.Include(r => r.Airport) 
                                 .Include(r => r.Flights);
                }

                return query.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Update(Reservation item, bool useNavigationalProperties = false)
        {
            try
            {
                Reservation reservationFromDb = Read(item.ID, useNavigationalProperties);

                if (reservationFromDb == null)
                {
                    Create(item);
                    return;
                }

                reservationFromDb.ReservedSeats = item.ReservedSeats;
                reservationFromDb.Tickets = item.Tickets;
                reservationFromDb.Price = item.Price;

                if (useNavigationalProperties)
                {
                    Airport AirportFromDb = dbContext.Airports.Find(item.AirportID);

                    if (AirportFromDb != null)
                    {
                        reservationFromDb.Airport = AirportFromDb;
                    }
                    else
                    {

                        reservationFromDb.Airport = item.Airport;
                    }



                    List<FlightsReservations> FlightsReservations = new List<FlightsReservations>();

                    foreach (FlightsReservations fr in item.Flights)
                    {
                        FlightsReservations frFromDb = dbContext.FlightsReservations.Find(fr.FligthID, fr.ReservationID);

                        if (frFromDb != null)
                        {
                            FlightsReservations.Add(frFromDb);
                        }
                        else
                        {
                            FlightsReservations.Add(fr);
                        }
                    }


                    reservationFromDb.Flights = FlightsReservations;
                }

                dbContext.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Delete(int key)
        {
            try
            {
                Reservation reservationFromDb = Read(key);

                if (reservationFromDb != null)
                {
                    dbContext.Reservations.Remove(reservationFromDb);
                    dbContext.SaveChanges();
                }
                else
                {
                    throw new InvalidOperationException("Reservation with that ID does not exist!");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
