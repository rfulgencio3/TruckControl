using System;

namespace TruckControl.API.Utils.Exceptions
{
    [Serializable]
    public class FabricationYearException : Exception
    {
        public FabricationYearException() : base() { }
        public FabricationYearException(string message) : base(message) { }
        public FabricationYearException(string message, Exception inner) : base(message, inner) { }

        // A constructor is needed for serialization when an
        // exception propagates from a remoting server to the client.
        protected FabricationYearException(System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }

        public Exception YearException()
        {
            string description = $"FabricationYear must be the current year, { DateTime.UtcNow.Year }.";

            return new FabricationYearException(description);
        }
    }
}
