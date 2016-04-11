using System;


namespace SimulationOfBusRoute.Utils
{
    public class CInvalidValueException : Exception
    {
        public CInvalidValueException(string message):
            base(message)
        {
        }
    }
}
