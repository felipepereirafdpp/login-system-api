namespace Login_system.Dto.Auth;

public class ResponseTokenDTO
{
    public string Token { get; set; }
    public DateTime ExpiresAt { get; set; }
    public Guid UserId { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    
}
