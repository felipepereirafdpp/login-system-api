using Resend;

namespace Login_system.Services.EmailService
{
    public class EmailsService
    {
        private readonly IResend _resend;

        public EmailsService(IConfiguration configuration)
        {
            _resend = ResendClient.Create(
                configuration["Resend:ApiKey"]
            );
        }

        public async Task EnviarEmail(string email, string token)
        {
            var html = GerarHtmlEmail(token);

            await _resend.EmailSendAsync(new EmailMessage()
            {
                From = "onboarding@resend.dev",
                To = email,
                Subject = "Recuperação de senha",
                HtmlBody = html
            });
        }

        private static string GerarHtmlEmail(string token)
        {
            return
                "<!DOCTYPE html>" +
                "<html lang='pt-BR'>" +
                "<head>" +
                "<meta charset='UTF-8'>" +
                "<meta name='viewport' content='width=device-width, initial-scale=1.0'>" +
                "<style>" +
                "* { margin: 0; padding: 0; box-sizing: border-box; }" +
                "body { font-family: -apple-system, BlinkMacSystemFont, 'Segoe UI', sans-serif; background: #f4f4f5; padding: 40px 16px; }" +
                ".wrapper { max-width: 520px; margin: 0 auto; background: #fff; border-radius: 12px; overflow: hidden; }" +
                ".header { background: #1a1a2e; padding: 32px; text-align: center; }" +
                ".header-icon { font-size: 24px; margin-bottom: 12px; }" +
                ".header-label { font-size: 12px; color: rgba(255,255,255,0.6); letter-spacing: 0.08em; text-transform: uppercase; }" +
                ".body { padding: 32px 40px; }" +
                "h2 { font-size: 22px; font-weight: 600; color: #111; margin-bottom: 8px; }" +
                ".subtitle { font-size: 15px; color: #6b7280; line-height: 1.7; margin-bottom: 24px; }" +
                ".code-box { background: #f5f5f0; border: 1px solid #e0dfd8; border-radius: 8px; padding: 20px; text-align: center; margin-bottom: 24px; }" +
                ".code-label { font-size: 11px; color: #6b7280; letter-spacing: 0.06em; text-transform: uppercase; margin-bottom: 8px; }" +
                ".code { font-family: 'Courier New', monospace; font-size: 30px; font-weight: 700; color: #1a1a2e; letter-spacing: 0.2em; }" +
                ".alert { background: #eff6ff; border-radius: 8px; padding: 14px 16px; margin-bottom: 24px; }" +
                ".alert-text { font-size: 13px; color: #1d4ed8; line-height: 1.5; }" +
                ".footer-note { font-size: 13px; color: #9ca3af; line-height: 1.7; }" +
                ".footer { border-top: 1px solid #f0f0f0; padding: 20px 40px; text-align: center; font-size: 12px; color: #9ca3af; }" +
                "</style>" +
                "</head>" +
                "<body>" +
                "  <div class='wrapper'>" +
                "    <div class='header'>" +
                "      <div class='header-icon'>&#128274;</div>" +
                "      <p class='header-label'>Suporte de conta</p>" +
                "    </div>" +
                "    <div class='body'>" +
                "      <h2>Recuperação de senha</h2>" +
                "      <p class='subtitle'>Recebemos uma solicitação para redefinir a senha da sua conta. Use o código abaixo para continuar.</p>" +
                "      <div class='code-box'>" +
                "        <p class='code-label'>Seu código de verificação</p>" +
                "        <p class='code'>" + token + "</p>" +
                "      </div>" +
                "      <div class='alert'>" +
                "        <p class='alert-text'>&#9201; Este código expira em <strong>15 minutos</strong>. Não compartilhe com ninguém.</p>" +
                "      </div>" +
                "      <p class='footer-note'>Se você não solicitou a recuperação de senha, ignore este e-mail.</p>" +
                "    </div>" +
                "    <div class='footer'>Enviado por <strong>Login System</strong></div>" +
                "  </div>" +
                "</body>" +
                "</html>";
        }
    }
}