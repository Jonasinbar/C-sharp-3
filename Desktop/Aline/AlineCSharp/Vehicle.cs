using EX03.GarageLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EX3Garage.Logic
{

    public abstract class Vehicle
    {

        protected internal eVehicleStatus m_vehicleStatus;
        private List<Wheel> m_wheels;
        private VehicleInformation m_vehicleInformation;
        private WheelInformation m_wheelInformation;

        public Vehicle(VehicleInformation i_vehicleInformation)
        {
            m_vehicleInformation = i_vehicleInformation;
            m_vehicleStatus = eVehicleStatus.InRepair;
            m_wheels = new List<Wheel>();
            
        }

        public VehicleInformation VehicleInformation
        {
            get
            {
                return m_vehicleInformation;
            }
            set
            {
                m_vehicleInformation = value;
            }
        }

        public WheelInformation WheelInformation
        {
            get
            {
                return m_wheelInformation;
            }
            set
            {
                m_wheelInformation = value;
                for (int i = 0; i < m_wheelInformation.NumberOfWheels; i++)
                {
                    m_wheels.Add(new Wheel(m_wheelInformation.WheelManufacturer, 0, m_wheelInformation.MaxAirPressure));
                }
            }
        }
        public enum eVehicleStatus
        {
            InRepair,
            Repaired,
            PayedFor,
        }

           
        public List<Wheel> Wheels
        {
            get
            {
                return m_wheels;
            }
        }

        public virtual StringBuilder DisplayVehicleInformation()
        {
            string borders = "==============================================";
            string newLine = System.Environment.NewLine;
            StringBuilder displayInfo = new StringBuilder();
            displayInfo.AppendLine(borders);
            displayInfo.AppendFormat("License Number: {1}{0}Model Name: {2}{0}Owner Name: {3}{0}Owner Phone Number {4}{0}" +
                "Vehicle Status: {5}{0}Wheel Manufacturer: {6}{0}Wheel Current Air Pressure: {7}{0}Wheel Max Air Pressure: {8}{0}",
                newLine, m_vehicleInformation.LicenseNumber, m_vehicleInformation.ModelName, m_vehicleInformation.OwnerName, 
                m_vehicleInformation.OwnerPhoneNumber, this.m_vehicleStatus, m_wheelInformation.WheelManufacturer,  
                m_wheels[0].CurrentAirPressure,  m_wheelInformation.MaxAirPressure);
            return displayInfo;
        }

    }
}
