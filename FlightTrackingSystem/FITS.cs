//William Herding Jason Lewis cis 345 t th 4:30pm
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HomelandSecurity;

namespace FlightTrackingSystem
{
    class FITS
    {
        //creating class objects
        Flight flights = new Flight();
        HomelandSecurity.TSA tsa = new HomelandSecurity.TSA();        
        
        //creating class arrays
        private Flight[] loadedFlights = new Flight[20];
        FlaggedPassenger[] flaggedPassgenger;
        

        //creating class variables
        private int flightSelected;
        string userSelection;
        bool repeatInput = false;
        int counter = 0;
        private static int flightCount = 0;

        

        /*static void Main(string[] args)
        {
            FITS fits = new FITS();

            //calls method to display header (system header)
            fits.Header();

            //loading premade flights into flight array
            fits.LoadTempData();
            fits.loadedFlights[0].LoadTempPassenger();
            fits.loadedFlights[1].loadTempPassenger1();
            fits.loadedFlights[2].loadTempPassenger2();
            //calls method in Selection class to prompt user to make a selection
            fits.SelectionMenu();
        }*/

        //method used to display system name to user
        public void Header()
        {
            Console.Clear();
            WriteCenteredLine("Phoenix Air");
            Console.WriteLine();
            WriteCenteredLine("Flight Inventory and Tracking System");
            WriteCenteredLine("*** FITS ***");
        }

        //method used to center system name to user
        public void WriteCenteredLine(string stringVariable)
        {
            int x;
            x = ((Console.WindowWidth + stringVariable.Length) / 2);
            Console.WriteLine("{0," + x + "}", stringVariable);
        }

        //method that inserts 3 prescheduled flights into the flight system
        public void LoadTempData()
        {
            loadedFlights[FlightCount] = new Flight(flights.FlightNumber = "378", flights.Departure = "Palma de Mallorca", flights.Destination = "Punta Gorda");
            flightCount++;
            loadedFlights[FlightCount] = new Flight(flights.FlightNumber = "495", flights.Departure = "Tortoli", flights.Destination = "Dusseldor");
            flightCount++;
            loadedFlights[FlightCount] = new Flight(flights.FlightNumber = "273", flights.Departure = "Amarillo", flights.Destination = "Fukushima");
            flightCount++;
        }
        //first method user sees to begin their selection process
        public void SelectionMenu()
        {
            // ****
            // edited version to be pulled to master
            // ****
            do
            {
                Console.Clear();
                Header();
                Console.WriteLine("\n");
                
                //Displays information to the screen to have user make selection
                Console.WriteLine("\nSee Options below... \n");
                Console.WriteLine("1. Display Flight List");
                Console.WriteLine("2. Add New Flight");
                Console.WriteLine("3. Select Flight");
                Console.WriteLine("4. Search by Passenger");
                Console.WriteLine("5. Exit");
                Console.Write("\nPlease Enter a selection: ");
                userSelection = Console.ReadLine();
                if (userSelection != "1" && userSelection != "2" && userSelection != "3" && userSelection != "4" && userSelection != "5")
                {
                    Console.Write("\nInvalid entry. Please try again.");
                    userSelection = Console.ReadLine();
                }
            } while (userSelection != "1" && userSelection != "2" && userSelection != "3" && userSelection != "4" && userSelection != "5");

            do
            {
                Console.Clear();
                Header();
                Console.WriteLine("\n");
                WriteCenteredLine("Current Flights\n");

                //switch statement to act off of user's selection
                switch (userSelection)
                {
                    case "1":
                        /*WriteCenteredLine("Current Flights\n");*/
                        DisplayFlights();
                        Pause();
                        Console.Clear();
                        SelectionMenu();
                        break;
                    case "2":
                        CreateFlight();
                        SelectionMenu();
                        break;
                    case "3":
                        do
                        {
                            try
                            {
                                repeatInput = false;
                                DisplayFlights();
                                Console.Write("\nSelect a Flight: ");
                                flightSelected = Convert.ToInt32(Console.ReadLine());
                                flightSelected--;
                            }
                            catch (NullReferenceException)
                            {
                                Console.WriteLine("");
                            }

                            catch (OverflowException)
                            {
                                if (counter == 2)
                                {
                                    Console.WriteLine("This is the third error!");
                                    Console.WriteLine("You are having problems entering the data. Press any key to quit.");
                                    Console.ReadLine();
                                    System.Environment.Exit(0);
                                }
                                Console.WriteLine("There was an error. The number was too big. Try again.\n");
                                repeatInput = true;
                                counter++;
                            }
                            catch (FormatException)
                            {
                                if (counter == 2)
                                {
                                    Console.WriteLine("\nThis is the third error!");
                                    Console.WriteLine("You are having problems entering the data. Press any key to quit.");
                                    Console.ReadKey();
                                    System.Environment.Exit(0);
                                }
                                if (flightSelected > FlightCount)
                                {
                                    Console.Write("\nInvalid entry!");
                                    Pause();
                                    repeatInput = true;
                                    return;
                                }
                                else
                                {
                                    Console.WriteLine("There was an error. Entry must be numberic. Please try again.");
                                    Pause();
                                    repeatInput = true;
                                }
                                counter++;
                            }

                            Console.Clear();
                            Header();
                            Console.WriteLine("\n");
                            WriteCenteredLine("Current Flights\n");

                        } while (repeatInput == true);
                        SelectedFlightMenu();
                        break;
                    case "4":
                        SearchByPassenger();
                        SelectionMenu();
                        break;
                    case "5":
                        System.Environment.Exit(0);
                        break;
                }
            } while (userSelection != "5");
        }


        //second selection menu user may see based off of selections from first selection menu
        public void SelectedFlightMenu()
        {
            string check;

            do
            {
                //Displays information to the screen to have user make selection
                Console.Clear();
                Header();
                Console.WriteLine("\n");
                for (int i = 0; i < loadedFlights.Length; i++)
                {
                    //just added this try and the null reference catch in an effort to make program more robust.
                    try
                    {
                        if (i == flightSelected)
                        {
                            Console.WriteLine("\t\t{0,-3} {1,-20} {2,5} {3,-20}", loadedFlights[i].FlightNumber,
                                     loadedFlights[i].Departure, "-->", loadedFlights[i].Destination);
                        }
                    }
                    //just added this catch in an effort to make program mroe robust. 
                    catch (NullReferenceException)
                    {
                        Console.WriteLine("invalid input. plz try again.");
                    }
                }
            } while (false);
                /*
                Console.WriteLine("\nSee Options below... \n");
                Console.WriteLine("1. Display Passenger Manifest");
                Console.WriteLine("2. Edit Flight Information");
                Console.WriteLine("3. Add New Passenger to Manifest");
                Console.WriteLine("4. Run Passenger Security Check");
                Console.WriteLine("5. Exit to FITS");
                Console.Write("\nPlease Enter a selection: ");
                userSelection = Console.ReadLine();
                if (userSelection != "1" && userSelection != "2" && userSelection != "3" && userSelection != "4" && userSelection != "5")
                {
                    Console.Write("\nInvalid entry. Please try again.");
                    Console.ReadLine();
                }
            } while (userSelection != "1" && userSelection != "2" && userSelection != "3" && userSelection != "4" && userSelection != "5");
            */
            do
            {
                Console.Clear();
                Header();
                Console.WriteLine("\n");
                WriteCenteredLine("Current Flights\n");

                //switch statement to act off of users selection
                switch (userSelection)
                {
                    case "1":
                        DisplayPassenger();
                        //Console.ReadLine();
                        Pause();
                        SelectedFlightMenu();
                        break;
                    case "2":
                        for (int i = 0; i < loadedFlights.Length; i++)
                        {
                            if (i == flightSelected)
                            {
                                Console.WriteLine("{0,-3} {1,-20} {2,5} {3,-20}", loadedFlights[i].FlightNumber,
                                         loadedFlights[i].Departure, "-->", loadedFlights[i].Destination);
                            }
                        }
                        Console.Write("\nEnter New 3 digit Flight Number: ");
                        check = Console.ReadLine();
                        if (Convert.ToInt32(check.Length) != 3)
                        {
                            Console.Write("\n\tInvalid entry.");
                            Pause();
                            break;
                        }
                        loadedFlights[flightSelected].FlightNumber = check;
                        Console.Write("Enter New Departure City: ");
                        loadedFlights[flightSelected].Departure = Console.ReadLine();
                        Console.Write("Enter New Destination City: ");
                        loadedFlights[flightSelected].Destination = Console.ReadLine();
                        Console.WriteLine("\nThe Flight information has been updated...");
                        Pause();
                        SelectedFlightMenu();
                        break;
                    case "3":
                        loadedFlights[flightSelected].AddPassenger();
                        
                        SelectedFlightMenu();
                        break;
                    case "4":
                        ClearFlag();
                        Runcheck();
                        SelectedFlightMenu();
                        break;
                    case "5":
                        Console.Clear();
                        Header();
                        SelectionMenu();
                        break;
                }
            } while (userSelection != "5");
        }

        

        //Selecting a flight from list of flights in system
        public void SelectFlight()
        {
            int selectedflight;
            do
            {
                try
                {

                    Console.Write("Enter Line Number for Flight: ");
                    selectedflight = Convert.ToInt32(Console.ReadLine());
                    repeatInput = false;
                }
                catch (OverflowException)
                {
                    if (counter == 2)
                    {
                        Console.WriteLine("This is the third error!");
                        Console.WriteLine("You are having problems entering the data. Goodbye!");
                        Pause();
                        System.Environment.Exit(0);
                    }
                    Console.WriteLine("There was an error. The number was too big.");
                    Pause();
                    Console.Clear();
                    repeatInput = true;
                    counter++;
                }
                catch (FormatException)
                {
                    if (counter == 2)
                    {
                        Console.WriteLine("\nThis is the third error!");
                        Console.WriteLine("You are having problems entering the data. Goodbye!");
                        Pause();
                        System.Environment.Exit(0);
                    }
                    if (Convert.ToInt32(Console.ReadLine()) > loadedFlights.Length)
                    {
                        Console.Write("\nInvalid entry.");
                        Pause();
                        repeatInput = true;
                        //return;
                    }
                    Console.WriteLine("There was an error. Entry must be numberic. Please try again.");
                    Pause();
                    Console.Clear();
                    repeatInput = true;
                    counter++;
                }

            } while (repeatInput == true);

        }
        
        public void DisplayFlights()
        {
            for (int i = 0; i < FlightCount; i++)
            {
                Console.WriteLine("\n\t{0,-1}. {1,-10} {2,-20} {3,5} {4,-20}", i + 1, loadedFlights[i].FlightNumber,
                             loadedFlights[i].Departure, "-->", loadedFlights[i].Destination);
            }
        }

        public void CreateFlight()
        {
            string newlyCreatedFlight ="";
            bool valid = true;
            string departure;
            string destination;

            do
            {
                valid = true;
                Header();
                Console.Write("\n\nPlease enter a Flight#: ");
                newlyCreatedFlight = Console.ReadLine();
                
                if (newlyCreatedFlight.Length > 10 || newlyCreatedFlight == "")
                {
                    Console.Write("\nInvalid entry. Please try again.\t");
                    Pause();
                    valid = false;
                }
            } while (valid == false);

            Console.Write("Please enter Departure City: ");
            departure = Console.ReadLine();
            Console.Write("Please enter Destination City: ");
            destination = Console.ReadLine();
            flights = new Flight(newlyCreatedFlight, departure, destination);
            loadedFlights[FlightCount] = flights;
            flightCount++;
            Console.Write("Your Flight has been added.");
            Pause();
        }
        
        public static void Pause()
        {
            Console.Write("\n\nPress any key to continue...");
            Console.ReadKey(true);
        }

        public Flight[] LoadedFlights
        {
            get
            {
                return loadedFlights;
            }
            set
            {
                loadedFlights = value;
            }
        }

        public static int FlightCount
        {
            get
            {
                return flightCount;
            }
        }

        //Displays passenger manifest
        public void DisplayPassenger()
        {
            string flag;

            Console.WriteLine("{0,-8}  {1,-12}  {2,-12}  {3,-8}", "Loyalty#", "First Name", "Last Name", "Flagged");
            Console.WriteLine("");
            for (int i = 0; i < loadedFlights[flightSelected].PassCount; i++)
            {
                if (loadedFlights[flightSelected].PassengerArray[i].SecurityFlag==true)
                {
                    flag = "!!!";
                }
                else
                {
                    flag = "";
                }
                Console.WriteLine("{0,-8}  {1,-12}  {2,-12}  {3,-8}", loadedFlights[Convert.ToInt32(flightSelected)].PassengerArray[i].LoyaltyNumber,
                   loadedFlights[Convert.ToInt32(flightSelected)].PassengerArray[i].FirstName, loadedFlights[Convert.ToInt32(flightSelected)].PassengerArray[i].LastName, flag);
            }
        }

        public void SearchByPassenger()
        {
            string firstName;
            string lastName;
            Console.Write("Enter First Name: ");
            firstName = Console.ReadLine().ToUpper();
            Console.Write("Enter Last Name: ");
            lastName = Console.ReadLine().ToUpper();

            Console.WriteLine("{0,-10}  {1,-12}  {2,-12}  {3,-8}", "Flight#", "First Name", "Last Name",  "Loyalty#");
            for (int i = 0; i < flightCount; i++)
            {
                for (int j = 0; j < loadedFlights[i].PassCount; j++)
                {
                    if (firstName == loadedFlights[i].PassengerArray[j].FirstName.ToUpper() && lastName == loadedFlights[i].PassengerArray[j].LastName.ToUpper())
                        Console.WriteLine("{0,-10}  {1,-12}  {2,-12}  {3,-8} ", loadedFlights[i].FlightNumber, loadedFlights[i].PassengerArray[j].FirstName, loadedFlights[i].PassengerArray[j].LastName, loadedFlights[i].PassengerArray[j].LoyaltyNumber);
                }
            }
            Pause();
        }
        public void ClearFlag()
        {
            for (int i = 0; i < LoadedFlights[flightSelected].PassCount; i++)
            {
                LoadedFlights[flightSelected].PassengerArray[i].SecurityFlag = false;
            }
        }

        public void Runcheck()
        {
            flaggedPassgenger = tsa.RunSecurityCheck(LoadedFlights[flightSelected].PassengerArray, LoadedFlights[flightSelected].PassCount);
            for (int i = 0; i < flaggedPassgenger.Length; i++)
            {
                for (int j = 0; j < LoadedFlights[flightSelected].PassCount; j++)
                {
                    if (flaggedPassgenger[i].LoyaltyNumber == loadedFlights[flightSelected].PassengerArray[j].LoyaltyNumber)
                    {
                        loadedFlights[flightSelected].PassengerArray[j].SecurityFlag = true;
                    }
                }
            }
        }
        public FITS()
        {

        }
        public FITS(string flightNumber, string departure, string destination)
        {
            flights.FlightNumber = flightNumber;
            flights.Departure = departure;
            flights.Destination = destination;
        }
    }
}
