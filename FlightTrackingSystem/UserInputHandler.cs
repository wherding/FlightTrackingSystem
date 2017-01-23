using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightTrackingSystem
{
    class UserInputHandler
    {
        /// <summary>
        /// Check for invalid user input during menu selection
        /// </summary>
        /// <param name="input"></param>
        /// <param name="low"></param>
        /// <param name="high"></param>
        /// <returns></returns>
        public static bool checkUserInputInRange(string input, int low, int high)
        {
            try
            {
                int userInputInteger = Convert.ToInt32(input);

                if (userInputInteger >= low && userInputInteger <= high)
                {
                    return true;
                }
                else throw new OverflowException();
            }
            catch (OverflowException)
            {
                Console.WriteLine("{0} is outside the range possible options.", input);
            }
            catch (FormatException)
            {
                Console.WriteLine("The input '{0}' is not in a recognizable format.", input);
            }

            return false;
        }
    }
}
