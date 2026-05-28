namespace Login_system.Exceptions;

public class EmailJaCadastradoException : Exception
    {
    // Construtor padrão sem mensagem
    public EmailJaCadastradoException() : base("Este e-mail já está cadastrado no sistema.") { }

    // Construtor que permite passar uma mensagem personalizada
    public EmailJaCadastradoException(string message) : base(message) { }

    // Construtor para quando você quer envelopar outra exceção dentro desta (Inner Exception)
    public EmailJaCadastradoException(string message, Exception innerException) : base(message, innerException) { }


}



