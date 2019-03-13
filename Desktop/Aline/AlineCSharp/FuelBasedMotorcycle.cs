using EX03.GarageLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EX3Garage.Logic
{

    
    public class FuelBasedMotorcycle : Motorcycle
    {
        private const float m_MaxFuelAmountLiters = 6f;
        private FuelEngine m_fuelEngine;

        public FuelBasedMotorcycle(eLicense i_license, int i_engineVolume, VehicleInformation i_vehicleInformation, string i_wheelManufacturer) : base(i_license, i_engineVolume,i_vehicleInformation, i_wheelManufacturer)
        {
            m_fuelEngine = new FuelEngine(m_MaxFuelAmountLiters, 0, FuelEngine.eFuelType.Octane96);
            //i_vehicleInformation.VehicleType = VehicleInformation.eVehicleType.FuelBasedMotorcycle;
        }

        public FuelEngine FuelEngine
        {
            get
            {
                return m_fuelEngine;
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
            displayInfo.AppendFormat("Engine Type: {1}{0}Current Fuel Status: {2}{0}Maximum Fuel Capacity in Liters: {3}{0}Vehicle Type: {4}{0}", newLine, "Fuel Engine", m_fuelEngine.RemainingEnergy, this.MaxFuelAmountLiters, "Fuel Based Motorcycle");
            displayInfo.Append(borders);
            return displayInfo;
        }
    }

}
