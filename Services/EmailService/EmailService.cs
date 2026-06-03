using Resend;

namespace Login_system.Services.EmailService
{
    public class EmailsService
    {
        // permite enviar email usando a API do Resend, que é uma plataforma
        private readonly IResend _resend;

        // Construtor da classe EmailsService
        public EmailsService(IConfiguration configuration)
        {
            _resend = ResendClient.Create(
                configuration["Resend:ApiKey"]
            );
        }

        // Método público assíncrono que envia um email de recuperação de senha para o usuário
        public async Task EnviarEmail(string email, string token)
        {
            await _resend.EmailSendAsync(new EmailMessage()
            {
                From = "onboarding@resend.dev",
                To = email,
                Subject = "Recuperação de senha",
                HtmlBody = $"""
                <h2>Recuperação de senha</h2>
                <p>Seu código é:</p>
                <strong>{token}</strong>
                """
            });
        }
    }
}