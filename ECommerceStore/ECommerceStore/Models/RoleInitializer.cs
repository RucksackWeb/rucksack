using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using ECommerceStore.Data;
using System.Threading.Tasks;

namespace ECommerceStore.Models
{
    public class RoleInitializer
    {
        private static readonly List<IdentityRole> Roles = new List<IdentityRole>()
        {
            new IdentityRole {Name = ApplicationRoles.Admin,
                NormalizedName = ApplicationRoles.Admin.ToUpper(),
                ConcurrencyStamp = Guid.NewGuid().ToString()},
            new IdentityRole {Name = ApplicationRoles.Member,
                NormalizedName = ApplicationRoles.Member.ToUpper(),
                ConcurrencyStamp = Guid.NewGuid().ToString()}

        };

        public static void SeedData(IServiceProvider serviceProvider, UserManager<ApplicationUser> userManager)
        {
            using (var dbContext =
                new UserDbContext(serviceProvider.GetRequiredService<DbContextOptions<UserDbContext>>()))
            {
                dbContext.Database.EnsureCreated();
                AddRoles(dbContext);
                //AddUser(dbContext, userManager);
                //AddUserRoles(dbContext);
            }

        }

        private static void AddRoles(UserDbContext dbContext)
        {
            if (dbContext.Roles.Any()) return;
            foreach (var role in Roles)
            {
                dbContext.Roles.Add(role);
                dbContext.SaveChanges();
            }
        }
    }
}
