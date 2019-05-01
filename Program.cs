using System;

namespace Waterspillfromhole
{
    class Program
    {
        static bool IsTooBig (Volume test, Volume tester) //Method to test one rectangle shape to see if the second can go into it
        {//Testing the biggest and smallest sides of each shape
            if (tester.BiggestNum() < test.BiggestNum())
                return true;
            if (tester.MidNum() < test.MidNum())
                return true;
            if (tester.SmallestNum() < test.SmallestNum())
                return true;
            return false;
        }

        static double Input (string message) //Method to show a message and recive data from the user
        {
            Console.WriteLine(message);
            return Convert.ToDouble(Console.ReadLine());
        }
        static void Main(string[] args)
        {
            Volume Pit = new Volume(2, 1.5, 40);            //Insilize pit object with info on size
            Volume water = new Volume(2, 1.5, 40 - 0.80);   //Insilize water object with info on size
            //////////////////////////Saif 1 removed parts/////////////////////////////
            //Volume tresure = new Volume(1.4, 1.2, 5.2);   //Insilize tresure object with info on size
            ///////////////////////////////////////////////////////////////////////////
            
            /////Insilize tresure object with info on size with data given from the user using methoed Input
            Volume tresure = new Volume(Input("Please enter tresure width in meters: "), Input("Please enter tresure length in meters: "), Input("Please enter tresure highet in meters: "));

            if (IsTooBig(tresure, water))//Testing to make sure the tresure the user input can get into the water in the pit
            {
                Console.WriteLine("The tresure is too big to get into the pit");
                Console.ReadLine();
            }
            else //If the tresure can fit into the pit
            {
                //Mesure the amount of water leaving the pit or water left in volume
                double temp = Pit.GetVolume() - water.GetVolume() - tresure.GetVolume(); 
                temp = Math.Round(temp, 2, MidpointRounding.ToEven); //rount up the number so can deal with neater numbers
                if (temp < 0.0000000001)//if there is water leaving the pit (over 0 in case the number is a little off)
                    Console.WriteLine("The amount of water overflowing from the pit is {0} meter kob", (temp * (-1)).ToString("0.00"));
                else   //In case the water dose not pass the top of the Pit
                    Console.WriteLine("The highet before hitting the water from the top of the pit is {0} meters", (temp / (2 * 1.5)).ToString("0.00"));
                Console.ReadLine();
            }
        }
    }

    class Volume    //Class to to hold varibales and functions for dealing with the volume
    {
        double x;       //Biggest side of the object
        double y;       //Middle sized side of the object
        double z;       //Smallest sized side of the object
        double volume;  //Varibale to deal with volume

        public Volume (double width, double length, double depth)
        {//Constractor for the Volume class to input and order the varibales
            x = width;
            y = length;
            z = depth;

            //Area to deal with ordering the varaibles by size
            if (x < y)
            {
                x += y;
                y = x - y;
                x -= y;
            }
            if (y < z)
            {
                y += z;
                z = y - z;
                y -= z;
                if (x < y)
                {
                    x += y;
                    y = x - y;
                    x -= y;
                }
            }

            volume = x * y * z;
        }

        public double GetVolume () //Return volume of object
        {
            return volume;
        }

        public double BiggestNum() //Returns the biggest sized side of the object
        {
            return x;
        }

        public double MidNum()      //Returns the middle sized side of the object
        {
            return y;
        }

        public double SmallestNum() //Returns the smallest sized side of the object
        {
            return z;
        }
    }
}
