using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceStore.Models.Handler
{
    public class AdminOnlyRequirement : IAuthorizationRequirement
    {
        public ApplicationException AdminRequirement { get; set; }


        public AdminOnlyRequirement(ApplicationException role)
        {
            AdminRequirement = role;
        }
    }
}
