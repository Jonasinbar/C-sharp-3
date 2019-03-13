using EX03.GarageLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EX3Garage.Logic
{
    public class ElectricCar : Car
    {

        private ElectricEngine m_ElectricEngine;
        private const float m_maxBatteryHours = 3.2f;

        public ElectricCar(eColor i_color, eCarNumberOfDoors i_numberOfDoors, VehicleInformation i_vehicleInformation, string i_wheelManufacturer) : base(i_color, i_numberOfDoors, i_vehicleInformation, i_wheelManufacturer)
        {
            m_ElectricEngine = new ElectricEngine(m_maxBatteryHours, 0);
            //i_vehicleInformation.VehicleType = VehicleInformation.eVehicleType.ElectricCar;
        }

        public ElectricEngine ElectricEngine
        {
            get
            {
                return m_ElectricEngine;
            }

        }

        public float MaxEngineOperateHours
        {
            get
            {
                return m_maxBatteryHours;
            }
        }

        public override StringBuilder DisplayVehicleInformation()
        {
            string borders = "==============================================";
            string newLine = System.Environment.NewLine;
            StringBuilder displayInfo = base.DisplayVehicleInformation();
            displayInfo.AppendFormat("Engine Type: {1}{0}Current Battery Status: {2}{0}Maximum Battery-Life in Hours: {3}{0}Vehicle Type: {4}{0}", newLine, "Electric Engine", m_ElectricEngine.RemainingEnergy, this.MaxEngineOperateHours, "Electric Car");
            displayInfo.Append(borders);
            return displayInfo;
        }
    }
}
