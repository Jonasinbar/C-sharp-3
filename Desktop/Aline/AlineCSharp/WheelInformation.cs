using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EX03.GarageLogic
{
    public class WheelInformation
    {
        private float m_maxAirPressure;
        private int m_numberOfWheels;
        private string m_wheelManufacturer;

        public WheelInformation(float i_maxAirPressure, int i_numberOfwheels, string i_wheelManufacturer)
        {
            m_maxAirPressure = i_maxAirPressure;
            m_numberOfWheels = i_numberOfwheels;
            m_wheelManufacturer = i_wheelManufacturer;
        }
        public float MaxAirPressure
        {
            get
            {
                return m_maxAirPressure;
            }
            set
            {
                m_maxAirPressure = value; 
            }
        }

        public int NumberOfWheels
        {
            get
            {
                return m_numberOfWheels;
            }
            set
            {
                m_numberOfWheels = value;
            }
        }

        public string WheelManufacturer
        {
            get
            {
                return m_wheelManufacturer;
            }
            set
            {
                m_wheelManufacturer = value;
            }
        }


    }
}
