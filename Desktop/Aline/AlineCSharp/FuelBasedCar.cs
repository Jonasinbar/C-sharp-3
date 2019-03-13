using EX03.GarageLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EX3Garage.Logic
{

    public class FuelBasedCar : Car
    {
        //change this
        private FuelEngine m_FuelEngine;
        private const float m_MaxFuelAmountLiters = 45f;

        public FuelBasedCar(eColor i_color, eCarNumberOfDoors i_numberOfDoors, VehicleInformation i_vehicleInformation, string i_wheelManufacturer) : base(i_color, i_numberOfDoors, i_vehicleInformation, i_wheelManufacturer)
        {
            m_FuelEngine = new FuelEngine(m_MaxFuelAmountLiters, 0, FuelEngine.eFuelType.Octane98);
           // i_vehicleInformation.VehicleType = VehicleInformation.eVehicleType.FuelBasedCar;
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
            displayInfo.AppendFormat("Engine Type: {1}{0}Current Fuel Status: {2}{0}Maximum Fuel Capacity in Liters: {3}{0}Vehicle Type: {4}{0}", newLine, "Fuel Engine", m_FuelEngine.RemainingEnergy, this.MaxFuelAmountLiters, "Fuel Based Car");
            displayInfo.Append(borders);
            return displayInfo;
        }
    }
}
