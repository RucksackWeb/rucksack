﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;


namespace ECommerceStore.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool Subscribe { get; set; }
    }

    public static class ApplicationRoles
    {
        public const string Member = "Member";
        public const string Admin = "Admin";
    }
}
