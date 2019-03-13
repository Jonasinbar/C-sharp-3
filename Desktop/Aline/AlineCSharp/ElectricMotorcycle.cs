using EX03.GarageLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EX3Garage.Logic
{

    public class ElectricMotorcycle : Motorcycle
    {
        private ElectricEngine m_ElectricEngine;
        private const float m_MaxEngineOperateHours = 1.8f;
        public ElectricMotorcycle(eLicense i_license, int i_engineVolume, VehicleInformation i_vehicleInformation, string i_wheelManufacturer) : base(i_license, i_engineVolume, i_vehicleInformation, i_wheelManufacturer)
        {
            m_ElectricEngine = new ElectricEngine(m_MaxEngineOperateHours, 0);
           // i_vehicleInformation.VehicleType = VehicleInformation.eVehicleType.ElectricMotorcycle;
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
                return m_MaxEngineOperateHours;
            }
        }


        public override StringBuilder DisplayVehicleInformation()
        {
            string borders = "==============================================";
            string newLine = System.Environment.NewLine;
            StringBuilder displayInfo = base.DisplayVehicleInformation();
            displayInfo.AppendFormat("Engine Type: {1}{0}Current Battery Status: {2}{0}Maximum Battery-Life in Hours: {3}{0}Vehicle Type: {4}{0}", newLine, "Electric Engine", m_ElectricEngine.RemainingEnergy, this.MaxEngineOperateHours, "Electric Motorcycle");
            displayInfo.Append(borders);
            return displayInfo;
        }

    }
}
