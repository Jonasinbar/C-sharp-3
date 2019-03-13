using EX03.GarageLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EX3Garage.Logic
{
    /** Update 13/5
     * 
     * Additional things to fix:
     * 1. Ask about "capacity of garage" in order to initialize lists
     * 2. Add FUEL PERCENTAGE to the Vehicles class
     * 3. Use stringBuilder somewhere
     * 4. Put "fillVehicleProperties in vehicle - there is code repetition
     * 5. Find a way to make vehicle status update automatically when i update it in the garage dictionary and list
     *    right now it's inefficient and repetetive.
     * 6. Ask about the CreateNewVehicle and what exactly he wants us to do there. 
     * 7. Add exceptions to the code in the places where guy wants exceptions.
     * 8. check for code/field repetitions - everything thatis common staysin the "base" level 
     * 
     * 
     * 
     * 
     * */
    public class Program
    {
        public static void Main()
        {
            /*
            //VehicleIndex + VehicleIsInGarage + Insert + ChangeStatus + DisplayFull + Display Testing
            
            ElectricMotorcycle testEM = new ElectricMotorcycle(Motorcycle.elicense.A, 32, "kawasaki", "123435", "uri","054234234", "ninja");
            testEM.FillVehicleProperties();

            FuelBasedMotorcycle testFBM = new FuelBasedMotorcycle(Motorcycle.elicense.B1, 30, "yamaha", "2", "asi", "054234234", "harley");
            testFBM.FillVehicleProperties();

            ElectricCar testEC = new ElectricCar(Car.ecolor.White , 4 , "ferrari", "3", "aline", "054234234", "avi");
            testEC.FillVehicleProperties();

            FuelBasedCar testFBC = new FuelBasedCar(Car.ecolor.White, 4, "toyota", "4", "steve", "054233244", "nimni");
            testFBC.FillVehicleProperties();

            FuelBasedTruck testFBT = new FuelBasedTruck(true, 300, "ford", "5", "amnon", "0542234244", "leeri");
            testFBT.FillVehicleProperties();

            Garage testGarage = new Garage();

            testGarage.Insert(testEM);
            testGarage.Insert(testFBM);
            testGarage.Insert(testEC);
            testGarage.Insert(testFBC);
            testGarage.Insert(testFBT);

            testGarage.ChangeVehicleStatus("2", Vehicle.eVehicleStatus.PayedFor);
            testGarage.ChangeVehicleStatus("123435", Vehicle.eVehicleStatus.Repaired);
            testGarage.ChangeVehicleStatus("3", Vehicle.eVehicleStatus.NotInGarage);

            testGarage.DisplayGarageInformation();
            testGarage.DisplayFullGarageInformation();



            //Filling air in tires testing
            
           /* for (int i = 0; i < testFBT.Wheels.Count; i++)
            {
                System.Console.WriteLine("wheel " + i + " air pressure: " + testFBT.Wheels[i].CurrentAirPressure);
            }
            testGarage.InflateTires("5");
            for (int i = 0; i < testFBT.Wheels.Count; i++)
            {
                System.Console.WriteLine("wheel " + i + " air pressure after filling: " + testFBT.Wheels[i].CurrentAirPressure);
            }
            


            //Display Vehicle testing
            /*
            testGarage.CurrentGarageVehicles[testGarage.VehicleIndex("1")].DisplayVehicleInformation();
            testGarage.CurrentGarageVehicles[testGarage.VehicleIndex("2")].DisplayVehicleInformation();
            testGarage.CurrentGarageVehicles[testGarage.VehicleIndex("3")].DisplayVehicleInformation();
            testGarage.CurrentGarageVehicles[testGarage.VehicleIndex("4")].DisplayVehicleInformation();
            testGarage.CurrentGarageVehicles[testGarage.VehicleIndex("5")].DisplayVehicleInformation();
            
            VehicleInformation vehicleInfo = new VehicleInformation("toyota", "123", "aline", "3294245");
            Dictionary<string, Object> specificInfo = new Dictionary<string, Object>(3);
            specificInfo.Add("Color", Car.ecolor.Black);
            specificInfo.Add("Number Of Doors", 4);
            specificInfo.Add("Wheel Manufacturer", "uri");
            */

            Garage myGarage = new Garage();
            //myGarage.Insert(vehicleInfo, specificInfo);


            VehicleInformation truckInfo = new VehicleInformation("truck", "345", "aline", "05333866");
            Dictionary<string, Object> specificInfoTruck = new Dictionary<string, Object>(3);
            specificInfoTruck.Add("Is Cooled", true);
            specificInfoTruck.Add("Cargo Volume", 50f);
            specificInfoTruck.Add("Wheel Manufacturer", "uri");
            //FuelBasedTruck truck = new FuelBasedTruck(true, 50, truckInfo, "uri");
            //System.Console.WriteLine(truck.DisplayVehicleInformation());

            VehicleInformation FuelMotoInfo = new VehicleInformation("fuelMoto", "567", "shany", "05366866");
            Dictionary<string, Object> specificInfoFuelMoto = new Dictionary<string, Object>(3);
            specificInfoFuelMoto.Add("License", Motorcycle.elicense.A);
            specificInfoFuelMoto.Add("Engine Volume", 50);
            specificInfoFuelMoto.Add("Wheel Manufacturer", "bba");

            myGarage.Insert(4, FuelMotoInfo, specificInfoFuelMoto);
            myGarage.Insert(5, truckInfo, specificInfoTruck);

            VehicleInformation FuelCarInfo = new VehicleInformation("fuelCar", "777", "shay", "05334866");
            Dictionary<string, Object> specificInfoFuelCar = new Dictionary<string, Object>(3);
            specificInfoFuelCar.Add("Color", Car.ecolor.Grey);
            specificInfoFuelCar.Add("Number Of Doors", 3);
            specificInfoFuelCar.Add("Wheel Manufacturer", "bba");

            myGarage.Insert(2, FuelCarInfo, specificInfoFuelCar);
            //  System.Console.WriteLine(myGarage.CurrentGarageVehicles["567"].DisplayVehicleInformation().ToString());
            //System.Console.WriteLine(myGarage.CurrentGarageVehicles["777"].DisplayVehicleInformation().ToString());

            Vehicle vehicle = myGarage.getVehicle("567");
            System.Console.WriteLine(vehicle.GetType());


                /*
                 *    ElectricCar = 1,
                FuelBasedCar = 2,
                ElectricMotorcycle = 3,
                FuelBasedMotorcycle = 4,
                FuelBasedTruck = 5,
                */
        }
    }
}
