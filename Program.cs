using BarotraumaJWT.Data;
using BarotraumaJWT.Extensions;
using BarotraumaJWT.Interfaces;
using BarotraumaJWT.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.SwaggerAuthConfigure();
builder.Services.AddControllers();
builder.Services.AddScoped<AppDbContext>();
builder.Services.AddScoped<IPasswordHasher, BcryptHasher>();
builder.Services.AddScoped<ITokenManager, TokenService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<ICharacterService, CharacterService>();
builder.Services.ConfigureJwtAuthentication(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
