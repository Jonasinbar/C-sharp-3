using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EX03.GarageLogic;
using EX3Garage.Logic;

namespace Ex03.ConsoleUI
{
    public class UserInterface
    {
        private static Garage m_garage = new Garage();

        public static void Main()
        {
            UserInterface user = new UserInterface();
            //user.insertVehicle(m_garage);
            user.insertVehicle(m_garage);
            // m_garage.Insert(1, user.getVehicleInformation("123"), user.getSpecificVehicleInformation("123", eType.Car));

        
            m_garage.ChangeVehicleStatus("123", Vehicle.eVehicleStatus.PayedFor);
            m_garage.DisplayFullGarageInformation();
            m_garage.InflateTiresToMaximum("123");
            System.Console.WriteLine(m_garage.getVehicle("123").Wheels[0].CurrentAirPressure);
            System.Console.WriteLine(m_garage.getVehicle("123").Wheels[1].CurrentAirPressure);
        }
   
        public void run()
        {

        }

        //Here we write "The Garage Services Menu"
        //Runs on a loop while the user doesn"t choose to exit the garage
        //press 1 to insert 2 to see 3 to.....9 to exit garage (program ends)
        //
        

        public static object CheckParsing(string i_Input, Type i_Type)
        {
            object res = new object();
            bool successParse = false;

            if (i_Type == typeof(float))
            {
                float resFloat;
                successParse = float.TryParse(i_Input, out resFloat);

                if (successParse == false)
                {
                    throw new FormatException();
                }
                else
                {
                    res = resFloat;
                }
            }
            else if (i_Type == typeof(int))
            {
                int resInt;
                successParse = int.TryParse(i_Input, out resInt);

                if (successParse == false)
                {
                    throw new FormatException();
                }
                else
                {
                    res = resInt;
                }
            }
            else if (i_Type == typeof(bool))
            {
                if (i_Input == "Y" || i_Input == "y")
                {
                    successParse = true;
                    res = true;
                }
                else if (i_Input == "N" || i_Input == "n")
                {
                    successParse = true;
                    res = false;
                }
                else
                {
                    throw new FormatException();
                }
            }
            else if (i_Type == typeof(Car.eColor))
            {
                res = Enum.Parse(typeof(Car.eColor), i_Input);
            }
            else if (i_Type == typeof(Car.eCarNumberOfDoors))
            {
                res = Enum.Parse(typeof(Car.eCarNumberOfDoors), i_Input);
            }
            else if (i_Type == typeof(Motorcycle.eLicense))
            {
                res = Enum.Parse(typeof(Motorcycle.eLicense), i_Input);
            }
            else if (i_Type == typeof(string))
            {
                res = (string)i_Input;
            }
            else
            {
                throw new FormatException();
            }

            return res;
        }

        public void insertVehicle(Garage i_garage)
        {
            string newLine = System.Environment.NewLine;
            System.Console.WriteLine("Please insert a license number:");
            string licenseNumber = CheckParsing(System.Console.ReadLine(), typeof(int)).ToString();


            if (i_garage.VehicleIsInGarage(licenseNumber))
            {
                System.Console.WriteLine(string.Format("The vehicle with license number {0} is already in the garage", licenseNumber));
                i_garage.ChangeVehicleStatus(licenseNumber, Vehicle.eVehicleStatus.InRepair);
            }
            else  
            {
                System.Console.WriteLine(string.Format("Please select a number according to a vehicle type out of the following: {0}" +
                    "1 - Electric Car {0}2 - Fuel-Based Car {0}3 - Electric Motorcycle {0}4 - Fuel-Based Motorcycle {0}5 - Fuel-Based Truck", newLine));

                int vehicleType = GetValidNumberOption(1, 5, System.Console.ReadLine());

                    i_garage.Insert(vehicleType, getVehicleInformation(licenseNumber), getSpecificVehicleInformation(licenseNumber, (CreateVehicle.eVehicleType)vehicleType));
            }
        }


        private int getVehicleType()
        {
            int vehicleType = (int) CheckParsing(System.Console.ReadLine(), typeof(int));
            if(vehicleType <=5 && vehicleType >= 1)
            {
                return vehicleType;
            }
            else
            {
                throw new IllegalArgumentException();
            }
        }

        public VehicleInformation getVehicleInformation(string i_licenseNumber)
        {
            System.Console.WriteLine("Please enter model name:");
            string modelName = System.Console.ReadLine();
            System.Console.WriteLine("Please enter owner name:");
            string ownerName = System.Console.ReadLine();
            System.Console.WriteLine("Please enter owner's phone number:");
            string ownerPhoneNumber = CheckParsing(System.Console.ReadLine(), typeof(int)).ToString();
            VehicleInformation vehicleInfo = new VehicleInformation(modelName, i_licenseNumber, ownerName, ownerPhoneNumber);
            return vehicleInfo;
        }

        private Dictionary<string, Object> getSpecificVehicleInformation(string i_licenseNumber, CreateVehicle.eVehicleType i_vehicleType)
        {
            Dictionary<string, Object> specificInformation = new Dictionary<string, object>(4);
            Console.WriteLine("Please enter the wheel manufacturer:");
            specificInformation.Add("Wheel Manufacturer", System.Console.ReadLine());
            switch (i_vehicleType)
            {
                case CreateVehicle.eVehicleType.ElectricCar:
                case CreateVehicle.eVehicleType.FuelBasedCar:

                    Console.WriteLine("Please enter the color:");
                    specificInformation.Add("Color", CheckParsing(System.Console.ReadLine(), typeof(Car.eColor)));
                    Console.WriteLine("Please enter the number of doors:");
                    specificInformation.Add("Number Of Doors", CheckParsing(System.Console.ReadLine(), typeof(Car.eCarNumberOfDoors)));
                    break;


                case CreateVehicle.eVehicleType.ElectricMotorcycle:
                case CreateVehicle.eVehicleType.FuelBasedMotorcycle:

                    Console.WriteLine("Please enter the license type");
                    specificInformation.Add("License", CheckParsing(System.Console.ReadLine(), typeof(Motorcycle.eLicense)));
                    Console.WriteLine("Please enter the engine volume:");
                    specificInformation.Add("Engine Volume", CheckParsing(System.Console.ReadLine(), typeof(int)));
                    break;

                case CreateVehicle.eVehicleType.FuelBasedTruck:
                    Console.WriteLine("Please enter if the car is cooled (Y/N)");
                    specificInformation.Add("Is Cooled", CheckParsing(System.Console.ReadLine(), typeof(bool)));
                    Console.WriteLine("Please enter the cargo volume");
                    specificInformation.Add("Cargo Volume", CheckParsing(System.Console.ReadLine(), typeof(float)));
                    break;

                default: throw new ArgumentException();
            }

            return specificInformation;
        }

        public int GetValidNumberOption(int i_min, int i_max, string i_value)
        {
            if (i_value.All(Char.IsDigit))
            {
                if (int.Parse(i_value) >= i_min || int.Parse(i_value) <= i_max)
                {
                    return int.Parse(i_value);
                }
            }
            throw new IllegalArgumentException();
        }



        private void garageServicesMessage()
        {
            System.Console.WriteLine(
            @" 
                                        Garage Services 
    ================================================================================
            
    Press 1 - Display License Numbers and Status of Vehicles Currently in the Garage
    Press 2 - Display Vehicle Information
    Press 3 - Insert Vehicle in the Garage
    Press 4 - Inflate Vehicle Tires
    Press 5 - Change Vehicle Status
    Press 6 - Charge Vehicle (Electric Engine)
    Press 7 - Refuel Vehicle (Fuel Based Engine)
    Press 8 - QUIT GARAGE

    ================================================================================");
        }

    }
}
