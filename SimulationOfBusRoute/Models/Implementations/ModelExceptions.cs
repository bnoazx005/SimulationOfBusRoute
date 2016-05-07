using System;


namespace SimulationOfBusRoute.Models.Implementations
{
    public class CInvalidModelStateException : Exception
    {
        public CInvalidModelStateException(string message) :
            base(message)
        {
        }
    }

    public class CInvalidRouteConfiguration : Exception
    {
        public CInvalidRouteConfiguration(string message) :
            base(message)
        {
        }
    }
}
