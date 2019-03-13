using EX03.GarageLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static EX3Garage.Logic.ValueOutOfRangeException;

namespace EX3Garage.Logic
{
    
    public class Garage
    {
        private Dictionary<string, Vehicle> m_currentGarageVehicles;

        public Garage()
        {
            m_currentGarageVehicles = new Dictionary<string, Vehicle>(200);
        }

        public Dictionary<string, Vehicle> CurrentGarageVehicles
        {
            get
            {
                return m_currentGarageVehicles;
            }
        }

        public Vehicle getVehicle(string i_LicenseNumber)
        {
            if (!VehicleIsInGarage(i_LicenseNumber))
            {
                throw new VehicleNotFoundException(i_LicenseNumber);
            }
            else
            {
                return m_currentGarageVehicles[i_LicenseNumber];
            }
        }

        public void InflateTiresToMaximum(string i_licenseNumber)
        {
            Vehicle vehicle = m_currentGarageVehicles[i_licenseNumber];
            for (int i = 0; i < vehicle.Wheels.Count; i++)
            {
                vehicle.Wheels[i].InflateAction(vehicle.WheelInformation.MaxAirPressure);
            } 
        }

       /* public void Refuel(string i_licenseNumber, FuelEngine.eFuelType i_fuelType, float i_fuelAmount)
        {
            Vehicle vehicle = getVehicleOfType(i_licenseNumber, typeof(FuelEngine.eFuelType));
            CreateVehicle.eVehicleType vehicleType
           
            
        }*/

        public Vehicle getVehicleOfType(string i_licenseNumber, CreateVehicle.eVehicleType i_vehicleType)
        {
            Vehicle vehicle = m_currentGarageVehicles[i_licenseNumber];
            if (!vehicle.GetType().Equals(i_vehicleType))
            {
                throw new InvalidVehicleTypeException();
            }
            return vehicle;
        }
        public void Insert(int i_vehicleType, VehicleInformation i_vehicleInformation, Dictionary<string, Object> i_specificInformation)
        {
            string licenseNumber = i_vehicleInformation.LicenseNumber;
            Vehicle vehicle = CreateVehicle.CreateNewVehicle((CreateVehicle.eVehicleType)i_vehicleType, i_vehicleInformation, i_specificInformation);
            m_currentGarageVehicles.Add(licenseNumber, vehicle);
            
        }
       
        public void ChangeVehicleStatus(string i_licenseNumber, Vehicle.eVehicleStatus i_newStatus)
        {
            Vehicle vehicle = getVehicle(i_licenseNumber);
            vehicle.m_vehicleStatus = i_newStatus;
        }
        
        
        public void DisplayFullGarageInformation()
        {
            System.Console.WriteLine("Total Number of Vehicles in the Garage: " + m_currentGarageVehicles.Count);
            foreach (KeyValuePair<string, Vehicle> vehicle in m_currentGarageVehicles)
            {
                System.Console.WriteLine(vehicle.Value.DisplayVehicleInformation());
            }
        }

        public string GetTypesOfVehicles()
        {
            StringBuilder stringBuilder = new StringBuilder();
            int index = 1;
            foreach (CreateVehicle.eVehicleType currentType in Enum.GetValues(typeof(CreateVehicle.eVehicleType)))
            {
                stringBuilder.AppendFormat("{0} - {1}{2}", index.ToString(), currentType.ToString(), Environment.NewLine);
                index++;
            }

            return stringBuilder.ToString();
        }

            // possibly string format to לתפור that shit 
        public void DisplayGarageInformation()
        {
            string borders = "=============================================";
            System.Console.WriteLine("Total Number of Vehicles in the Garage: " + m_currentGarageVehicles.Count);
            foreach (KeyValuePair <string, Vehicle> license  in m_currentGarageVehicles)
            {
                System.Console.WriteLine(borders);
                System.Console.WriteLine("Vehicle with License Number  " + license.Key + ": " + license.Value.m_vehicleStatus);
            }
        }
        
        public bool VehicleIsInGarage(string i_LicenseNumber)
        {
            return m_currentGarageVehicles.ContainsKey(i_LicenseNumber);
        }
    }
}