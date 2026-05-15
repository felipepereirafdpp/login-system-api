using System.ComponentModel.DataAnnotations;

namespace Login_system.Models;

public class Users
{

    [Key] public Guid Id { get; set; }
    [Required] [StringLength(150)] public string Name { get; set; }
    [Required] public string Email { get; set; }
    [Required] public string PasswordHash { get; set; }
    public string? EmailVerificationToken { get; set; }
    public DateTime CreateDate { get; set; } = DateTime.UtcNow; // força a data de criação para o momento atual
    public List<PasswordResetToken> PasswordResetTokens { get; set; } // Um usuario pode ter vários tokens de redefinição de senha
}
