using System.ComponentModel.DataAnnotations;

namespace Login_system.Models;

public class PasswordResetToken
{
   [Key] public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public string Token { get; set; }
    public DateTime CreateDate { get; set; } = DateTime.UtcNow; // Data de criação do token
    public DateTime ExpiresAt { get; set; }
    public bool Used { get; set; }
    public Users User { get; set; }
}

