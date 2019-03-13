using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EX3Garage.Logic
{
    public class Wheel
    {
        private readonly string m_manufacturerName;
        private float m_currentAirPressure;
        private readonly float m_maxAirPressureRecommended;

        public Wheel(String i_manufacturerName, float i_currentAirPressure, float i_maxAirPressure) 
        {
            m_manufacturerName = i_manufacturerName;
            m_currentAirPressure = i_currentAirPressure;
            m_maxAirPressureRecommended = i_maxAirPressure;
        }

        /** recieves how much more air to add to a tire 
         * makes sure to not add over the max pressure limit
         * 
         * */

        public void InflateAction(float i_air)
        {
            float addedAir = m_currentAirPressure + i_air;
            if (addedAir > m_maxAirPressureRecommended)
            {
                m_currentAirPressure = m_maxAirPressureRecommended;
            }
            else
            {
                m_currentAirPressure = addedAir;
            }
        }

        public float MaxAirPressureRecommended
        {
            get
            {
                return m_maxAirPressureRecommended;
            }
        }

        public string ManufacturerName
        {
            get
            {
                return m_manufacturerName;
            }
        }

        public float CurrentAirPressure
        {
            get
            {
                return m_currentAirPressure;
            }
        }
    }
}
