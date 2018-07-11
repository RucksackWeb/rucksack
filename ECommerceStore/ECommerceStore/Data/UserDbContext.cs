using ECommerceStore.Models;
using Microsoft.AspNetCore.Identity.EntityFramerworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace ECommerceStore.Data
{
    public class UserDbContext : IdentityDbContext<ApplicationUser>
    {
        public UserDbContext(DbContextOptions<UserDbContext> option) : base(option)
        {

        }
    }
}
