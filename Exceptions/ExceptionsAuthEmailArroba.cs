namespace Login_system.Exceptions;

public class EmailSemArrobaException : Exception
{
    // Construtor padrão sem mensagem
    public EmailSemArrobaException() : base("O e-mail informado não contém o caractere '@'.") { }

    // Construtor que permite passar uma mensagem personalizada
    public EmailSemArrobaException(string message) : base(message) { }

    // Construtor para quando você quer envelopar outra exceção dentro desta (Inner Exception)
    public EmailSemArrobaException(string message, Exception innerException) : base(message, innerException) { }


}
