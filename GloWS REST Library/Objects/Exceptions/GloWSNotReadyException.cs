namespace MyDHLAPI_REST_Library.Objects.Exceptions
{
    public class GloWSNotReadyException : System.Exception
    {
        private const string _msg = "The object hasn't been initialized with the GloWS parameters.";

        public GloWSNotReadyException()
            : base(_msg)
        { }

        public GloWSNotReadyException(string message)
            : base(_msg, new System.Exception(message))
        { }

        public GloWSNotReadyException(string message, System.Exception innerException)
            : base(_msg, new System.Exception(message, innerException))
        { }

        public GloWSNotReadyException(System.Exception innerException)
            : base(_msg, innerException)
        { }
    }
}
