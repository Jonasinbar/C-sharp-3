using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EX3Garage.Logic
{

        public class ElectricEngine : Engine
        {


        public ElectricEngine(float i_maxEnergy, float i_remainingEnergy) : base(i_maxEnergy, i_remainingEnergy)
        {
        }

        /**recieves how many hours to add to the engive,
         * charges the abttery while not crossing the limit
         * */
        public void Recharge(float i_hours)
        {
            base.FillEnergy(i_hours);
        }

    }
}
