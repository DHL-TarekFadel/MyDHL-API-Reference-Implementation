namespace MyDHLAPI_REST_Library.Objects.Exceptions
{
    [System.Serializable]
    public class MyDHLAPINotReadyException : System.Exception
    {
        private const string _msg = "The object hasn't been initialized with the MyDHL API parameters.";

        public MyDHLAPINotReadyException()
            : base(_msg)
        { }

        public MyDHLAPINotReadyException(string message)
            : base(_msg, new System.Exception(message))
        { }

        public MyDHLAPINotReadyException(string message, System.Exception innerException)
            : base(_msg, new System.Exception(message, innerException))
        { }

        public MyDHLAPINotReadyException(System.Exception innerException)
            : base(_msg, innerException)
        { }

        protected MyDHLAPINotReadyException(System.Runtime.Serialization.SerializationInfo serializationInfo, System.Runtime.Serialization.StreamingContext streamingContext)
            : base (serializationInfo, streamingContext)
        { }
    }
}
