using BussinessLayer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class AirportsContext : IDb<Airport, int>
    {
        private readonly SavinaStoyanova_23DBContext dbContext;

        public AirportsContext(SavinaStoyanova_23DBContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Create(Airport item)
        {
            try
            {
                dbContext.Airports.Add(item);
                dbContext.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }


        public Airport Read(int key, bool useNavigationalProperties = false)
        {
            try
            {
                if (useNavigationalProperties)
                {
                    return dbContext.Airports.Include(a => a.Reservations).FirstOrDefault(a => a.ID == key);
                }
                else
                {
                    return dbContext.Airports.Find(key);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<Airport> ReadAll(bool useNavigationalProperties = false)
        {
            try
            {
                IQueryable<Airport> query = dbContext.Airports;

                if (useNavigationalProperties)
                {
                    query = query.Include(a => a.Reservations);
                }

                return query.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Update(Airport item, bool useNavigationalProperties = false)
        {
            try
            {
                Airport airportFromDb = Read(item.ID, useNavigationalProperties);

                if (airportFromDb == null)
                {
                    Create(item);
                    return;
                }

                airportFromDb.Name = item.Name;
                airportFromDb.TotalProfit = item.TotalProfit;
              

                if (useNavigationalProperties)
                {
                    List<Reservation> Reservations = new List<Reservation>();

                    foreach (Reservation r in item.Reservations)
                    {
                        Reservation reservationFromDb = dbContext.Reservations.Find(r.ID);

                        if (reservationFromDb != null)
                        {
                            Reservations.Add(reservationFromDb);
                        }
                        else
                        {
                            Reservations.Add(r);
                        }

                    }

                    airportFromDb.Reservations = Reservations;
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
                Airport AirportFromDb = Read(key);

                if (AirportFromDb != null)
                {
                    dbContext.Airports.Remove(AirportFromDb);
                    dbContext.SaveChanges();
                }
                else
                {
                    throw new InvalidOperationException("Airport with that ID does not exist!");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
