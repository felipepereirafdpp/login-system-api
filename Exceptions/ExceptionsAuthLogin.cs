namespace Login_system.Exceptions
{
    public class ExceptionsAuthLogin : Exception
    {
        // Construtor padrão sem mensagem
        public ExceptionsAuthLogin() : base("Email ou senha invalidos") { }

        // Construtor que permite passar uma mensagem personalizada
        public ExceptionsAuthLogin(string message) : base(message) { }

        // Construtor para quando você quer envelopar outra exceção dentro desta (Inner Exception)
        public ExceptionsAuthLogin(string message, Exception innerException) : base(message, innerException) { }
    }
}
