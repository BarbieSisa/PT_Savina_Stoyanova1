
using BussinessLayer;
using DataLayer2;
using System;
using System.Collections.Generic;

namespace TestingLayer1
{
   public class Program
    {
        static SavinaStoyanova_23DBContext dbContext;
        static AirportsContext AirportsContext;

        static void Main(string[] args)
        {
            try
            {
                dbContext = new SavinaStoyanova_23DBContext();
                AirportsContext = new AirportsContext(dbContext);

                //TestAirportContextCreate();
                //TestAirportContextRead();
                //TestAirportContextReadWithInnerJoin();
                //TestAirportContextReadAll();
                //TestAirportContextReadAllWithInnerJoin();
                //TestAirportContextUpdate();
                TestAirportContextDelete();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + " :(");
            }

        }

        static void TestAirportContextCreate()
        {
            Airport Airport = new Airport(1, "Champaine,Rome", 300300);
            AirportsContext.Create(Airport);
            Console.WriteLine("Airport created successfully! :)");
        }

        static void TestAirportContextRead()
        {
            Airport Airport = AirportsContext.Read(2);

            Console.WriteLine(Airport);
        }

        static void TestAirportContextReadWithInnerJoin()
        {
            Airport Airport = AirportsContext.Read(2, true);

            Console.WriteLine(Airport);
        }

        static void TestAirportContextReadAll()
        {
            IEnumerable<Airport> Airports = AirportsContext.ReadAll();

            foreach (Airport Airport in Airports)
            {
                Console.WriteLine(Airport);
            }
        }

        static void TestAirportContextReadAllWithInnerJoin()
        {
            IEnumerable<Airport> Airports = AirportsContext.ReadAll(true);

            foreach (Airport Airport in Airports)
            {
                Console.WriteLine(Airport);
            }
        }

        static void TestAirportContextUpdate()
        {
            Airport AirportFromDb = AirportsContext.Read(3);
            Console.WriteLine("Before: ");
            Console.WriteLine(AirportFromDb);

            AirportFromDb.Name = "MainItaly";
            AirportsContext.Update(AirportFromDb);

            Airport updatedAirportFromDb = AirportsContext.Read(3);
            Console.WriteLine("After: ");
            Console.WriteLine(updatedAirportFromDb);
        }


        static void TestAirportContextDelete()
        {
            Console.Write("Id = ");
            int id = Convert.ToInt32(Console.ReadLine());
            Airport AirportFromDb = AirportsContext.Read(id);

            Console.WriteLine("Before: {0}", AirportFromDb);
            AirportsContext.Delete(id);

            AirportFromDb = AirportsContext.Read(id);

            if (AirportFromDb == null)
            {
                Console.WriteLine($"Airport with Id {id} deleted successfully!");
            }
        }

    }
}
