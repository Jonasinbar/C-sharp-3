using EX03.GarageLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EX3Garage.Logic
{


    public abstract class Truck : Vehicle
    {
        private bool m_isCooled;
        private readonly float m_cargoVolume;
        private WheelInformation m_wheelInformation;


        public Truck(bool i_isCooled, float i_cargoVolume,  VehicleInformation i_vehicleInformation, string i_wheelManufacturer) : base(i_vehicleInformation)
        {
            m_isCooled = i_isCooled;
            m_cargoVolume = i_cargoVolume;
            m_wheelInformation = new WheelInformation(28, 12, i_wheelManufacturer);
            base.WheelInformation = m_wheelInformation;
        }

        

        public bool IsCooled
        {
            get
            {
                return m_isCooled;
            }
        }

        public float CargoVolume
        {
            get
            {
                return m_cargoVolume;
            }
        }

        public override StringBuilder DisplayVehicleInformation()
        {
            string newLine = System.Environment.NewLine;
            StringBuilder displayInfo = base.DisplayVehicleInformation();
            displayInfo.AppendFormat("Is Cooled: {1}{0}Cargo Volume: {2}{0}", newLine, IsCooled ? "Yes" : "No", this.m_cargoVolume);
            return displayInfo;
        }
    }
}
