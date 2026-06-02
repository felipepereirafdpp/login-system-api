namespace Login_system.Exceptions
{
    public class ExceptionsAuthFogotPassword:Exception
    {
        public ExceptionsAuthFogotPassword() : base("Email não encontrado. ") { }

        public ExceptionsAuthFogotPassword (string message) : base(message) { }

        public ExceptionsAuthFogotPassword(string message, Exception innerException) : base(message, innerException) { }
    }
