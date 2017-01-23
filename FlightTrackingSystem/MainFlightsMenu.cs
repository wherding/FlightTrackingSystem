using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightTrackingSystem
{
    class MainFlightsMenu
    { 
        public List<Flight> flightList { get; set; }

        // Displays the system header
        public void PrintHeader()
        {
            Console.Clear();
            PrintingSystem.WriteCenteredLine("Phoenix Air");
            Console.WriteLine();
            PrintingSystem.WriteCenteredLine("Flight Inventory and Tracking System");
            PrintingSystem.WriteCenteredLine("*** FITS ***");
            Console.WriteLine("\n");
        }


        // new version of "selection menu"
        public void DisplayMainMenu()
        {

            Console.Clear();
            PrintHeader();

            //Displays information to the screen to have user make selection
            Console.WriteLine("\nSee Options below... \n");
            Console.WriteLine("1. Display Flight List");
            Console.WriteLine("2. Add New Flight");
            Console.WriteLine("3. Select Flight");
            Console.WriteLine("4. Search by Passenger");
            Console.WriteLine("5. Exit");


            string userInput;
            do
            {
                Console.Write("\nPlease Enter a selection: ");
                userInput = Console.ReadLine();
            } while (!UserInputHandler.checkUserInputInRange(userInput, 1, 5));

            switch (Convert.ToInt32(userInput))
            {
                case 1:
                    DisplayFlightList();
                    FlightTracker.Pause();
                    FlightTracker.Reset();
                    break;
                case 2:
                    AddNewFlight();
                    break;
                case 3:
                    SelectFlight();
                    break;
                case 4:
                    SearchByPassenger();
                    break;
                default:
                    System.Environment.Exit(0);
                    break;
            }
        }

        

        private void DisplayFlightList()
        {
            int count = 1;
            foreach (Flight flight in flightList)
            {
                Console.WriteLine("{0}. {1}", count, flight.ToString());
                count++;
            }
        }

        private void AddNewFlight()
        {

        }

        private void SelectFlight()
        {
            // display flights
            DisplayFlightList();

            // select a flight prompt
            string userInput;
            do
            {
                Console.Write("\nPlease Enter a selection: ");
                userInput = Console.ReadLine();
            } while (!UserInputHandler.checkUserInputInRange(userInput, 1, flightList.Count));

            // handle user input
            int flightIndex = Convert.ToInt32(userInput);
            Flight selectedFlight = flightList.ElementAt(flightIndex);
            SelectedFlightMenu.DisplayFlightOptionsMenu();
        }

        private void SearchByPassenger()
        {

        }
        
    }
}
