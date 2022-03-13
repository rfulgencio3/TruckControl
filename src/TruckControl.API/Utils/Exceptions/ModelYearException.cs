using System;

namespace TruckControl.API.Utils.Exceptions
{
    [Serializable]
    public class ModelYearException : Exception
    {
        public ModelYearException() : base() { }
        public ModelYearException(string message) : base(message) { }
        public ModelYearException(string message, Exception inner) : base(message, inner) { }

        // A constructor is needed for serialization when an
        // exception propagates from a remoting server to the client.
        protected ModelYearException(System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }

        public Exception YearException()
        {
            string description = $"ModelYear must be { DateTime.UtcNow.Year } or { DateTime.UtcNow.Year + 1 }.";

            return new FabricationYearException(description);
        }
    }
}
