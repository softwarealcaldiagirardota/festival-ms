using System;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using System.Linq;

public class HasScopeHandler : AuthorizationHandler<HasScopeRequirement>
{
    protected override Task HandleRequirementAsync(
      AuthorizationHandlerContext context,
      HasScopeRequirement requirement
    )
    {
        // If user does not have the scope claim, get out of here
        if (!context.User.HasClaim(c => c.Type == "permissions" && c.Issuer == requirement.Issuer))
            return Task.CompletedTask;

        // Split the scopes string into an array
        var permisions = context.User
              .FindAll(c => c.Type == "permissions").ToArray();
        List<string> list = new List<string>();
        foreach (var item in permisions)
        {
            list.Add(item.Value);
        }
        var scopePermissions = requirement.Scope;



        bool allPermissionsMatch = true;

        foreach (var permission in scopePermissions)
        {
            if (!list.Contains(permission))
            {
                allPermissionsMatch = false;
                break;
            }
        }

        if (allPermissionsMatch)
        {
            // Si todos los permisos de scopePermissions coinciden con elementos en list, pasa
            context.Succeed(requirement);
        }
        else
        {
            context.Fail();
        }

        return Task.CompletedTask;
    }
}