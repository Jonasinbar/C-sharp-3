using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EX3Garage.Logic
{
    public class FuelEngine : Engine
    {
        private eFuelType m_FuelType;

        public FuelEngine(float i_MaxFuelAmount, float i_CurrentFuelAmount, eFuelType i_fuelType) : base(i_MaxFuelAmount, i_CurrentFuelAmount)
        {
            m_FuelType = i_fuelType;
        }

        public enum eFuelType
        {
            Soler,
            Octane98,
            Octane96,
            Octane95
        }

        /**
         * recieves how much fuel to add and changes the ammount
         * only if the fuel is correct and the tank is less than / = to full
         * */
        public void FillFuel(float i_fuelToAdd, eFuelType i_fuelType)
        {
            if(i_fuelType == m_FuelType)
            {
                base.FillEnergy(i_fuelToAdd);
            }
            else
            {
                //write this exception
                throw new Exception();
            }

        }

        public eFuelType FuelType
        {
            get
            {
                return m_FuelType;
            }
        }
    }
}
