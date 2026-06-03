using Login_system.Interfaces;
using Login_system.Services.Auth;
using Login_system.Services.EmailService;
using Login_system.Services.User;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Connection String
var connectionString = builder.Configuration.GetConnectionString("Login_systemContext")
    ?? throw new InvalidOperationException("Connection string 'Login_systemContext' not found.");

// DbContext
builder.Services.AddDbContext<Login_systemContext>(options =>
    options.UseSqlServer(connectionString));

// Controllers
builder.Services.AddControllers();

// OpenAPI
builder.Services.AddOpenApi();


// ===================== JWT AUTH =====================
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes("FELIPE_12092008_MINHA_CHAVE_DA_API")
        ),
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateLifetime = true,
        ClockSkew = TimeSpan.Zero
    };
});

// Authorization
builder.Services.AddAuthorization();


// ===================== SERVICES =====================
// Email Service (IMPORTANTE)
builder.Services.AddScoped<EmailsService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IAuthService, AuthService>();

var app = builder.Build();


// ===================== PIPELINE =====================
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();