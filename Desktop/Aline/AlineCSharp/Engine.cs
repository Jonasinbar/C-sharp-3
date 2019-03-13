using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EX3Garage.Logic
{
    public abstract class Engine
    {
        private readonly float m_maxEnergy;
        private float m_remainingEnergy;


        public Engine(float i_maxEnergy, float i_remainingEnergy)
        {
            m_maxEnergy = i_maxEnergy;
            m_remainingEnergy = i_remainingEnergy;
        }

        public float MaxEnergy
        {
            get
            {
                return m_maxEnergy;
            }
        }

        public float RemainingEnergy
        {
            get
            {
               return m_remainingEnergy;
            }
        }

        virtual public void FillEnergy(float i_addedEnergy)
        {
            float addedEnergy = m_remainingEnergy + i_addedEnergy;
            if (addedEnergy > m_maxEnergy)
            {
                m_remainingEnergy = m_maxEnergy;
            }
            else
            {
                m_remainingEnergy = addedEnergy;
            }
        }
    }
}