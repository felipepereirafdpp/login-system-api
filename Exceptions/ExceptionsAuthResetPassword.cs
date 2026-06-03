namespace Login_system.Exceptions
{
    public class ExceptionsAuthResetPassword : Exception
    {
        public ExceptionsAuthResetPassword(): base("Falha ao resetar senha. ") { }
        public ExceptionsAuthResetPassword(string message) : base(message) { }
        public ExceptionsAuthResetPassword(string message, Exception innerException) : base(message, innerException) { }
    }
}
