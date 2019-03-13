using EX03.GarageLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EX3Garage.Logic
{
    /**
     * o Color – Gray, Blue, White, Black 
     * o Number of doors – 2, 3, 4, or 5
    * */

    public abstract class Car : Vehicle
    {
        private readonly eCarNumberOfDoors m_numberOfDoors;
        private eColor m_color;
        private WheelInformation m_wheelInformation; 
       // private string m_wheelManufacturer;
        
        public Car(eColor i_color, eCarNumberOfDoors i_numberOfDoors, VehicleInformation i_vehicleInformation, string i_wheelManufacturer) : base(i_vehicleInformation)
        {
            m_wheelInformation = new WheelInformation(32, 4, i_wheelManufacturer);
            base.WheelInformation = m_wheelInformation;
            m_numberOfDoors = i_numberOfDoors;
            m_color = i_color;

        }

        public enum eCarNumberOfDoors
        {
            TwoDoors = 2,
            ThreeDoors = 3,
            FourDoors = 4,
            FiveDoors = 5,
        }

        public enum eColor
        {
            Grey,
            Blue,
            White,
            Black
        }

        public eCarNumberOfDoors NumberofDoors
        {
            get
            {
                return m_numberOfDoors;
            }
        }

        public eColor Color
        {
            get
            {
                return m_color;
            }
        }

        public override StringBuilder DisplayVehicleInformation()
        {
            string newLine = System.Environment.NewLine;
            StringBuilder displayInfo = base.DisplayVehicleInformation();
            displayInfo.AppendFormat("Car color: {1}{0}Number of Doors: {2}{0}", newLine, this.m_color, (int)this.m_numberOfDoors);
            return displayInfo;
        }
    }
}
