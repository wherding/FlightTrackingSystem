//William Herding Jason Lewis cis 345 t th 4:30 pm
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HomelandSecurity;

namespace FlightTrackingSystem
{
    class Flight
    {
        private string flightNumber = "";
        private string departure = "";
        private string destination = "";
        private int passCount = 0;
        
        Passenger passenger = new Passenger();

        Passenger[] passengerArray= new Passenger[20];
        
        public string FlightNumber
        {
            get
            {
                return this.flightNumber;
            }
            set
            {
                this.flightNumber = value;
            }
        }

        public string Departure
        {
            get
            {
                return this.departure;
            }
            set
            {
                this.departure = value;
            }
        }

        public string Destination
        {
            get
            {
                return this.destination;
            }
            set
            {
                this.destination = value;
            }
        }
                
        public int PassCount
        {
            get
            {
                return passCount;
            }
            set
            {
                passCount = value;
            }
        }
        public Passenger[] PassengerArray
        {
            get
            {
                return passengerArray;
            }
            set
            {
                passengerArray = value;
            }
        }

        public Flight()
        {
        }

        public Flight(string flightNumber, string departure, string destination)
        {
            passengerArray = new Passenger[20];

            this.flightNumber = flightNumber;
            this.departure = departure;
            this.destination = destination; 
        }

        public void LoadTempPassenger()
        {
            passengerArray[0] = new Passenger("Joe", "Doe", "007");
            PassCount++;
            passengerArray[1] = new Passenger("Jane", "Lane", "008");
            PassCount++;
            passengerArray[2] = new Passenger("Nick", "Jones", "001");
            PassCount++;
            passengerArray[3] = new Passenger("Jason", "Lewis", "002");
            PassCount++;
            passengerArray[4] = new Passenger("Will", "Herding", "003");
            PassCount++;
            passengerArray[5] = new Passenger("Sterling", "Archer", "004");
            PassCount++;
            passengerArray[6] = new Passenger("Altaf", "Ahmad", "020");
            PassCount++;
        }

        public void loadTempPassenger1()
        {
            passengerArray[0] = new Passenger("Sheldon", "Cooper", "006");
            PassCount++;
            passengerArray[1] = new Passenger("Altaf", "Ahmad", "020");
            PassCount++;
            passengerArray[2] = new Passenger("Mark", "Hoppus", "009");
            PassCount++;
            passengerArray[3] = new Passenger("Travis", "Barker", "010");
            PassCount++;
            passengerArray[4] = new Passenger("Thomas", "DeLonge", "011");
            PassCount++;
            passengerArray[5] = new Passenger("Dave", "Bayley", "012");
            PassCount++;
            passengerArray[6] = new Passenger("Joe", "Seaward", "013");
            PassCount++;
            passengerArray[7] = new Passenger("Drew", "MacFarlane", "014");
            PassCount++;
        }
        public void loadTempPassenger2()
        {
            passengerArray[0] = new Passenger("Bill", "Nye", "015");
            PassCount++;
            passengerArray[1] = new Passenger("Neil", "Tyson", "016");
            PassCount++;
            passengerArray[2] = new Passenger("Lawrence", "Krauss", "017");
            PassCount++;
            passengerArray[3] = new Passenger("Richard", "Dawkins", "018");
            PassCount++;
            passengerArray[4] = new Passenger("Michio", "Kaku", "019");
            PassCount++;
            passengerArray[5] = new Passenger("Altaf", "Ahmad", "020");
            PassCount++;
            passengerArray[6] = new Passenger("Elon", "Musk", "021");
            PassCount++;

        }

        public void AddPassenger()
        {
            Console.Write("Enter Passenger First Name: ");
            passenger.FirstName = Console.ReadLine();
            Console.Write("Enter Passenger Last Name: ");
            passenger.LastName = Console.ReadLine();
            Console.Write("Enter Passenger Loyalty Number: ");
            passenger.LoyaltyNumber = Console.ReadLine();

            passengerArray[PassCount] = new Passenger(passenger.FirstName, passenger.LastName, passenger.LoyaltyNumber);
            passCount++;
        }
        
        
    }
}
