using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightTrackingSystem
{
    class SelectedFlightMenu
    {

        public static void DisplayFlightOptionsMenu()
        {
            Console.WriteLine("\nSee Options below... \n");
            Console.WriteLine("1. Display Passenger Manifest");
            Console.WriteLine("2. Edit Flight Information");
            Console.WriteLine("3. Add New Passenger to Manifest");
            Console.WriteLine("4. Run Passenger Security Check");
            Console.WriteLine("5. Exit to FITS");

            string userInput;
            do
            {
                Console.Write("\nPlease Enter a selection: ");
                userInput = Console.ReadLine();
            } while (!UserInputHandler.checkUserInputInRange(userInput, 1, 5));

            switch (Convert.ToInt32(userInput))
            {
                case 1:
                    FlightTracker.Reset();
                    //DisplayPassengerManifest();
                    break;
                case 2:
                    //EditFlightInformation(); *new class
                    break;
                case 3:
                    //AddNewPassengerToManifest();
                    break;
                case 4:
                    //RunPassengerSecurityCheck();
                    break;
                default:
                    System.Environment.Exit(0);
                    break;
            }
        }
    }
}
