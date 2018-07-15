using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ECommerceStore.Models.Handler
{
    public class SubscriberFeatureRequirement : IAuthorizationRequirement
    {
        public Claim Subscription { get; set; }

        public SubscriberFeatureRequirement(Claim subscribed)
        {
            Subscription = subscribed;
        }
    }
}
