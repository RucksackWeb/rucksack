using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceStore.Models.Handler
{
    public class SubscriberFeatureRequirement : IAuthorizationRequirement
    {
        public bool Subscription { get; set; }

        public SubscriberFeatureRequirement(bool subscribed)
        {
            Subscription = subscribed;
        }
    }
}
