    using Login_system.Models;
    using Microsoft.EntityFrameworkCore;

    public class Login_systemContext(DbContextOptions<Login_systemContext> options) : DbContext(options)
    {
        public DbSet<Users> Users { get; set; }
        public DbSet<PasswordResetToken> PasswordResetTokens { get; set; }
    }
