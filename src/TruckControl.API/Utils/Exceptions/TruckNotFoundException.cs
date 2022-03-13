using System;

namespace TruckControl.API.Utils.Exceptions
{
    [Serializable]
    public class TruckNotFoundException : Exception
    {
        public TruckNotFoundException() : base() { }
        public TruckNotFoundException(string message) : base(message) { }
        public TruckNotFoundException(string message, Exception inner) : base(message, inner) { }

        // A constructor is needed for serialization when an
        // exception propagates from a remoting server to the client.
        protected TruckNotFoundException(System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }

        public Exception NotExist(int id)
        {
            string description = $"Truck with id: { id }, does not exist.";

            return new FabricationYearException(description);
        }
    }
}
