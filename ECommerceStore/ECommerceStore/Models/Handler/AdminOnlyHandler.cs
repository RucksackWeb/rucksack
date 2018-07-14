using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceStore.Models.Handler
{
    public class AdminOnlyHandler : AuthorizationHandler<AdminOnlyRequirement>
    {

        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, AdminOnlyRequirement requirement)
        {
            if(context.User == null)
            {
                return Task.CompletedTask;
            }

            if (context.User.IsInRole(ApplicationRoles.Admin))
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }

    }
}
