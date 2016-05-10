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

    public class CInvalidRouteConfigurationException : Exception
    {
        public CInvalidRouteConfigurationException(string message) :
            base(message)
        {
        }
    }

    public class CInvalidStartRouteNodeException : CInvalidRouteConfigurationException
    {
        public CInvalidStartRouteNodeException(string message):
            base(message)
        {
        }
    }

    public class CInvalidEndRouteNodeException : CInvalidRouteConfigurationException
    {
        public CInvalidEndRouteNodeException(string message) :
            base(message)
        {
        }
    }

    public class CNotCompiledDataException : Exception
    {
        public CNotCompiledDataException(string message):
            base(message)
        {
        }
    }

    public class CIncorrectNumOfBusesException : Exception
    {
        public CIncorrectNumOfBusesException(string message):
            base(message)
        {
        }
    }
}
