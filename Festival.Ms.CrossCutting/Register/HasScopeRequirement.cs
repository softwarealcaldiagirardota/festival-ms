using System;
using Microsoft.AspNetCore.Authorization;

public class HasScopeRequirement : IAuthorizationRequirement
{
    public string Issuer { get; }
    public List<string> Scope { get; }

    public HasScopeRequirement(List<string> scope, string issuer)
    {
        Scope = scope ?? throw new ArgumentNullException(nameof(scope));
        Issuer = issuer ?? throw new ArgumentNullException(nameof(issuer));
    }
}