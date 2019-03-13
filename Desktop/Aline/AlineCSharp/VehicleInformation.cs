using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EX3Garage.Logic;

namespace EX03.GarageLogic
{
    public class VehicleInformation
    {
        private string m_modelName;
        private string m_licenseNumber;
        private string m_ownerName;
        private string m_ownerPhoneNumber;
        private Engine m_engine;

        public VehicleInformation(string i_modelName, string i_licenseNumber, string i_ownerName, string i_ownerPhoneNumber)
        {
            m_modelName = i_modelName;
            m_licenseNumber = i_licenseNumber;
            m_ownerName = i_ownerName;
            m_ownerPhoneNumber = i_ownerPhoneNumber;
        }

        public Engine Engine
        {
            get
            {
                return m_engine;
            }
            set
            {
                m_engine = value;
            }
        }
        public string LicenseNumber
        {
            get
            {
                return m_licenseNumber;
            }
            set
            {
                m_licenseNumber = value;
            }
        }

       
        public string OwnerPhoneNumber
        {
            get
            {
                return m_ownerPhoneNumber;
            }
            set
            {
                m_ownerPhoneNumber = value;
            }
        }

        public string OwnerName
        {
            get
            {
                return m_ownerName;
            }
            set
            {
                m_ownerName = value;
            }
        }

        public string ModelName
        {
            get
            {
                return m_modelName;
            }
            set
            {
                m_modelName = value;
            }
        }
        
        

       /* public void DisplayVehicleInformation()
        {
            string borders = "==============================================";
            System.Console.WriteLine(borders);
            System.Console.WriteLine("Vehicle License Plate Number -  " + m_licenseNumber + " Information:");
            System.Console.WriteLine(borders);
            for (int i = 0; i < m_vehiclePropertyTitles.Length; i++)
            {
                System.Console.WriteLine("  " + m_vehiclePropertyTitles[i] + ": " + m_vehicleProperties[i]);
            }
        }*/
    }
}
