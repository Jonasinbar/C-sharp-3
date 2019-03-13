using EX3Garage.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EX03.GarageLogic
{
    /**
     *  code which creates new object from the Vehicle class
     *  This class may also hold the supported vehicle types list. 
     *  This class cannot address the user, neither directly, nor indirectly. 
    **/


    //No idea what he wants - need to facebook him about this**********
    public class CreateVehicle
    {
        public enum eVehicleType
        {
            ElectricCar = 1,
            FuelBasedCar = 2,
            ElectricMotorcycle = 3,
            FuelBasedMotorcycle = 4,
            FuelBasedTruck = 5,
        }

       /* public eVehicleType VehicleType
        {
            get
            {
                return m_vehicleType;
            }
            set
            {
                m_vehicleType = value;
            }
        }*/
        public static Vehicle CreateNewVehicle(eVehicleType i_VehicleType, VehicleInformation i_vehicleInformation, Dictionary<string, Object> i_specificInformation)
        {
            Vehicle newVehicle;

            switch (i_VehicleType)
            {
                case eVehicleType.ElectricCar:
                    newVehicle = CreateElectricCar(i_vehicleInformation, i_specificInformation);
                    break;
                case eVehicleType.ElectricMotorcycle:
                    newVehicle = CreateElectricMotorcycle(i_vehicleInformation, i_specificInformation);
                    break;
                case eVehicleType.FuelBasedCar:
                    newVehicle = CreateFuelCar(i_vehicleInformation, i_specificInformation);
                    break;
                case eVehicleType.FuelBasedMotorcycle:
                    newVehicle = CreateFuelMotorcycle(i_vehicleInformation, i_specificInformation);
                    break;
                case eVehicleType.FuelBasedTruck:
                    newVehicle = CreateFuelTruck(i_vehicleInformation, i_specificInformation);
                    break;
                default: throw new ArgumentException();
            }

            return newVehicle;
        }

        public static ElectricCar CreateElectricCar(VehicleInformation i_vehicleInformation, Dictionary<string, Object> i_specificInformation)
        {
            Car.eColor color = (Car.eColor) i_specificInformation["Color"];
            Car.eCarNumberOfDoors numOfDoors = (Car.eCarNumberOfDoors) i_specificInformation["Number Of Doors"];
            string wheelManufacturer = (string)i_specificInformation["Wheel Manufacturer"];
            ElectricCar electricCar = new ElectricCar(color, numOfDoors, i_vehicleInformation, wheelManufacturer);
            return electricCar;

        }

        public static ElectricMotorcycle CreateElectricMotorcycle(VehicleInformation i_vehicleInformation, Dictionary<string, Object> i_specificInformation)
        {
            Motorcycle.eLicense license = (Motorcycle.eLicense) i_specificInformation["License"];
            int engineVolume = (int) i_specificInformation["Engine Volume"];
            string wheelManufacturer = (string) i_specificInformation["Wheel Manufacturer"];
            ElectricMotorcycle electricMoto = new ElectricMotorcycle(license, engineVolume, i_vehicleInformation, wheelManufacturer);
            return electricMoto;
        }

        public static FuelBasedCar CreateFuelCar(VehicleInformation i_vehicleInformation, Dictionary<string, Object> i_specificInformation)
        {
            Car.eColor color = (Car.eColor)i_specificInformation["Color"];
            Car.eCarNumberOfDoors numOfDoors = (Car.eCarNumberOfDoors)i_specificInformation["Number Of Doors"];
            string wheelManufacturer = (string)i_specificInformation["Wheel Manufacturer"];
            FuelBasedCar fuelCar = new FuelBasedCar(color, numOfDoors, i_vehicleInformation, wheelManufacturer);
            return fuelCar;
        }

        public static FuelBasedMotorcycle CreateFuelMotorcycle(VehicleInformation i_vehicleInformation, Dictionary<string, Object> i_specificInformation)
        {
            Motorcycle.eLicense license = (Motorcycle.eLicense)i_specificInformation["License"];
            int engineVolume = (int)i_specificInformation["Engine Volume"];
            string wheelManufacturer = (string)i_specificInformation["Wheel Manufacturer"];
            FuelBasedMotorcycle fuelMoto = new FuelBasedMotorcycle(license, engineVolume, i_vehicleInformation, wheelManufacturer);
            return fuelMoto;
        }

        public static FuelBasedTruck CreateFuelTruck(VehicleInformation i_vehicleInformation, Dictionary<string, Object> i_specificInformation)
        {
            bool isCooled = (bool)i_specificInformation["Is Cooled"];
            float cargoVolume = (float)i_specificInformation["Cargo Volume"];
            string wheelManufacturer = (string)i_specificInformation["Wheel Manufacturer"];
            FuelBasedTruck fuelTruck = new FuelBasedTruck(isCooled, cargoVolume, i_vehicleInformation, wheelManufacturer);
            return fuelTruck;
        }

    }
}

