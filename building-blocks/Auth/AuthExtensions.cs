using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authentication.JwtBearer;
namespace BuildingBlocks.Auth;

public static class AuthExtensions
{
    public static void IServiceCollection AddKeyCloakAuth(
        this IServiceCollection services,
        IConfiguration configuration
    ){
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
        .AddJwtBearer(options =>
        {
            options.Authority = configuration["Keycloak:Authority"];
            options.Audience = configuration["Keycloak:Audience"];
            options.RequireHttpsMetadata = false;
        });
        services.AddAuthorization();

        return services;
    }
}
