using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EX3Garage.Logic
{
    public class ValueOutOfRangeException : Exception
    {
        private float m_maxValue;
        private float m_minValue;
        private const string m_error = "Value out of range - choose another value";

        public ValueOutOfRangeException(float i_minValue, float i_maxValue) : base(m_error)
        {
            m_maxValue = i_minValue;
            m_minValue = i_maxValue;
        }
        public float MaxValue
        {
            get
            {
                return m_maxValue;
            }
            set
            {
                m_maxValue = value;
            }
        }
        public float MinValue
        {
            get
            {
                return m_minValue;
            }
            set
            {
                m_minValue = value;
            }
        }
    }

    public class VehicleNotFoundException : Exception
    {
        private const string m_error = "Vehicle not found, please enter another license number";

        public VehicleNotFoundException(string i_licenseNumber) : base(m_error)
        {
        }

    }

    public class InvalidVehicleTypeException : Exception
    {
        private const string m_error = "Vehicle type is invalid, please try again";

        public InvalidVehicleTypeException() : base(m_error)
        {
        }
    }

    public class IllegalArgumentException : Exception
    {
        private const string m_error = "Your input is not valid. Please enter again";

        public IllegalArgumentException() : base(m_error)
        {
        }
    }
                

}

