using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightTrackingSystem
{
    class FlightTracker
    {
        private static MainFlightsMenu menu;
        private static List<Flight> loadedFlights = new List<Flight>();

        static void Main(string[] args)
        {
            LoadTempData();


            menu = new MainFlightsMenu();
            menu.flightList = loadedFlights; // *** make sure this call is a copy and not a reference
            
            //calls method in Selection class to prompt user to make a selection
            menu.DisplayMainMenu();
        }

        //method that inserts 3 prescheduled flights and their passengers into the flight system
        private static void LoadTempData()
        {
            Flight a = new Flight("378", "Palma de Mallorca", "Punta Gorda");
            a.LoadTempPassenger();
            Flight b = new Flight("495", "Tortoli", "Dusseldor");
            b.loadTempPassenger1();
            Flight c = new Flight("273", "Amarillo", "Fukushima");
            c.loadTempPassenger2();

            loadedFlights.Add(a);
            loadedFlights.Add(b);
            loadedFlights.Add(c);
        }

        public static void Pause()
        {
            Console.Write("\n\nPress any key to continue...");
            Console.ReadKey(true);
        }

        public static void Reset()
        {
            Console.Clear();
            menu.DisplayMainMenu();
        }
    }
}
