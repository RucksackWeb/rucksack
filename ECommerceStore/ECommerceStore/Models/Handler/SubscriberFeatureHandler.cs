using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceStore.Models.Handler
{
    public class SubscriberFeatureHandler : AuthorizationHandler<SubscriberFeatureRequirement>
    {

        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, SubscriberFeatureRequirement requirement)
        {
            //if(context.User == null)
            //{
            //    return Task.CompletedTask;
            //}

            if(context.User.HasClaim(c => c.Type == "Subscription"))
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}
