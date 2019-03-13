using EX03.GarageLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EX3Garage.Logic
{


    public abstract class Motorcycle : Vehicle
    {
        private eLicense m_license;
        private readonly int m_engineVolume;
        private WheelInformation m_wheelInformation;



        public Motorcycle(eLicense i_license, int i_engineVolume, VehicleInformation i_vehicleInformation, string i_wheelManufacturer) : base(i_vehicleInformation)
        {
            m_license = i_license;
            m_engineVolume = i_engineVolume;
            m_wheelInformation = new WheelInformation(32, 2, i_wheelManufacturer);
            base.WheelInformation = m_wheelInformation;
        }

        public enum eLicense
        {
            A,
            A1,
            B1,
            B2,
        }

        public eLicense License
        {
            get
            {
                return m_license;
            }
        }

        public int EngineVolume
        {
            get
            {
                return m_engineVolume;
            }
        }

        public override StringBuilder DisplayVehicleInformation()
        {
            string newLine = System.Environment.NewLine;
            StringBuilder displayInfo = base.DisplayVehicleInformation();
            displayInfo.AppendFormat("License Type: {1}{0}Engine Volume: {2}{0}", newLine, this.m_license, this.m_engineVolume);
            return displayInfo;
        }
    }
}
