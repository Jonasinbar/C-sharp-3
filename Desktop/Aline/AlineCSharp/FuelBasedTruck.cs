using EX03.GarageLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EX3Garage.Logic
{

    public class FuelBasedTruck : Truck
    {

        private const float m_MaxFuelAmountLiters = 115f;
        private FuelEngine m_FuelEngine;


        public FuelBasedTruck(bool i_isCooled, float i_cargoVolume, VehicleInformation i_vehicleInformation, string i_wheelManufacturer) : base(i_isCooled, i_cargoVolume, i_vehicleInformation, i_wheelManufacturer)
        {
            m_FuelEngine = new FuelEngine(m_MaxFuelAmountLiters, 0, FuelEngine.eFuelType.Octane96);
            //i_vehicleInformation.VehicleType = VehicleInformation.eVehicleType.FuelBasedTruck;
        }

        public FuelEngine FuelEngine
        {
            get
            {
                return m_FuelEngine;
            }
        }

        public float MaxFuelAmountLiters
        {
            get
            {
                return m_MaxFuelAmountLiters;
            }
        }

        public override StringBuilder DisplayVehicleInformation()
        {
            string borders = "==============================================";
            string newLine = System.Environment.NewLine;
            StringBuilder displayInfo = base.DisplayVehicleInformation();
            displayInfo.AppendFormat("Engine Type: {1}{0}Current Fuel Status: {2}{0}Maximum Fuel Capacity in Liters: {3}{0}Vehicle Type: {4}{0}", newLine, "Fuel Engine", m_FuelEngine.RemainingEnergy, this.MaxFuelAmountLiters, "Fuel Based Truck");
            displayInfo.Append(borders);
            return displayInfo;
        }

        /* public override void FillVehicleProperties()
         {
             m_vehiclePropertyTitles = new string[] { "Status in Garage", "Vehicle Type", "Model Name", "Owner Name",  "Tire Manufacturer", "Number of Wheels" , "Tire Maximum Air Pressure" , "Engine Type", "Fuel Type", "Maximum Liters Fuel in the Engine" , "Cargo Volume" , "The Truck Is Cooled" };
             m_vehicleProperties = new Object[] { m_vehicleStatus, "Fuel-Powered Truck" , ModelName , OwnerName ,  Wheels[0].ManufacturerName , "12" , Wheels[0].MaxAirPressureRecommended , "Fuel-Based Engine" , FuelEngine.FuelType, FuelEngine.MaxEnergy , CargoVolume , IsCooled};
         }*/
    }
}
