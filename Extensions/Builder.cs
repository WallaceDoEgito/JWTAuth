using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

namespace BarotraumaJWT.Extensions;

public static class Builder
{
    public static IServiceCollection SwaggerConfigure(this IServiceCollection services)
    {
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "BarotraumaJWT", Version = "v1" });

            c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme() 
            { 
                Name = "Authorization", 
                Type = SecuritySchemeType.ApiKey, 
                Scheme = "Bearer", 
                BearerFormat = "JWT", 
                In = ParameterLocation.Header, 
                Description =
                    "JWT Authorization Header - utilizado com Bearer Authentication.\r\n\r\n" +
                    "Digite 'Bearer' [espaço] e então seu token no campo abaixo.\r\n\r\n" +
                    "Exemplo (informar sem as aspas): 'Bearer 12345abcdef'",
            }); 
            c.AddSecurityRequirement(new OpenApiSecurityRequirement 
            { 
                { 
                    new OpenApiSecurityScheme 
                    { 
                        Reference = new OpenApiReference 
                        { 
                            Type = ReferenceType.SecurityScheme, 
                            Id = "Bearer" 
                        } 
                    }, 
                    new string[] {} 
                } 
            });  
        });
        return services;
    }

    public static IServiceCollection ConfigureJwtAuthentication(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidIssuer = configuration["JWTConfig:Issuer"],
                ValidateAudience = true,
                ValidAudience = configuration["JWTConfig:Audience"],
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWTConfig:SecretKey"]!))
            };
        });
        return services;
    }
}