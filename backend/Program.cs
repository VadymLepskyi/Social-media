using Microsoft.EntityFrameworkCore;
using backend.Infrastructure.Data;
 
var builder = WebApplication.CreateBuilder(args);
// PostgreSQL provider
var connectionString = "Host=localhost;Port=5432;Database=socialMediaDatabase;Username=keycloak;Password=keycloak";

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(connectionString));
/// The authentication srvice: Keycloak
builder.Services.AddAuthentication("Bearer")
    .AddJwtBearer("Bearer", options =>
    {
        options.Authority = "http://localhost:8080/realms/MyProjectRealm";
        options.Audience = "account";
        options.RequireHttpsMetadata = false;
    });
builder.Services.AddAuthorization();

var app = builder.Build();

// Add auth middleware
app.UseAuthentication();
app.UseAuthorization();
app.Run();


