using System;
using System.Security.Claims;
using Festival.Ms.DAL.Interfaces.Repositories;
using Festival.Ms.DAL.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace Festival.Ms.CrossCutting.Register
{
    public static class AuthorizationDependencies
    {
        public static IServiceCollection AddAuthorizationDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.Authority = $"https://{configuration["Auth0:Domain"]}/";
                options.Audience = configuration["Auth0:Audience"];
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    NameClaimType = ClaimTypes.NameIdentifier
                };

                options.TokenValidationParameters = new TokenValidationParameters
                {
                    NameClaimType = ClaimTypes.Role,
                };

                options.Events = new JwtBearerEvents()
                {
                    OnMessageReceived = msg =>
                    {
                        var token = msg?.Request.Headers.Authorization.ToString();
                        string path = msg?.Request.Path ?? "";
                        if (!string.IsNullOrEmpty(token))

                        {
                            Console.WriteLine("Access token");
                            Console.WriteLine($"URL: {path}");
                            Console.WriteLine($"Token: {token}\r\n");
                        }
                        else
                        {
                            Console.WriteLine("Access token");
                            Console.WriteLine("URL: " + path);
                            Console.WriteLine("Token: No access token provided\r\n");
                        }
                        return Task.CompletedTask;
                    },

                    OnTokenValidated = ctx =>
                    {
                        Console.WriteLine();
                        Console.WriteLine("Claims from the access token");
                        if (ctx?.Principal != null)
                        {
                            foreach (var claim in ctx.Principal.Claims)
                            {
                                Console.WriteLine($"{claim.Type} - {claim.Value}");
                            }
                        }
                        Console.WriteLine();
                        return Task.CompletedTask;
                    },
                };
            });
            var domain = $"https://{configuration["Auth0:Domain"]}/";


            RegistryFestivalsPolicy(services, domain);
            return services;
        }

        private static void RegistryFestivalsPolicy(IServiceCollection services, string domain)
        {
            List<string> list = new List<string> { "read:festival" };
            services
                .AddAuthorization(options =>
                {
                    options.AddPolicy(
                      "createFestival",
                      policy => policy.Requirements.Add(
                        new HasScopeRequirement(list, domain)
                      )
                    );
                });
        }
    }

}