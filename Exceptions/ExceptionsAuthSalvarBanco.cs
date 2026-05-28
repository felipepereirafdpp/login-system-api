namespace Login_system.Exceptions
{
    public class ExceptionsAuthSalvarBanco:Exception
    {
        
        // Construtor padrão sem mensagem
        public ExceptionsAuthSalvarBanco() : base("Falha ao salvar usuario.") { }

        // Construtor que permite passar uma mensagem personalizada
        public ExceptionsAuthSalvarBanco(string message) : base(message) { }

        // Construtor para quando você quer envelopar outra exceção dentro desta (Inner Exception)
        public ExceptionsAuthSalvarBanco(string message, Exception innerException) : base(message, innerException) { }


    }




}

