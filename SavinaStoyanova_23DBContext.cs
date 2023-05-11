using System;
using BussinessLayer;
using Microsoft.EntityFrameworkCore;

namespace DataLayer
{
    public class SavinaStoyanova_23DBContext : DbContext
    {
        public SavinaStoyanova_23DBContext()
        {

        }

        public SavinaStoyanova_23DBContext(DbContextOptions contextOptions) : base(contextOptions)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-HAD030U\\SQLEXPRESS01;Database=SavinaStoyanova_23DB;Trusted_Connection=True;");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FlightsReservations>().HasKey(fr => new { fr.FligthID, fr.ReservationID });
            modelBuilder.Entity<FlightsReservations>().HasOne(fr => fr.Reservation).WithMany(r => r.Flights).HasForeignKey(fr => fr.ReservationID);
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Airport> Airports { get; set; }
        public DbSet<Flight> Flights { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<FlightsReservations> FlightsReservations { get; set; }
    }
}
