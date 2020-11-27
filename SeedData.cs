﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace leavemanagementsystem
{
    public static class SeedData
    {
        public static void Seed(UserManager<IdentityUser> userManager, 
            RoleManager<IdentityRole> roleManager)
        {
            SeedRoles(roleManager);
            SeedUsers(userManager);
        }

        public static void SeedUsers(UserManager<IdentityUser> userManager)
        {
            if (userManager.FindByNameAsync("admin").Result == null)
            {
                var user = new IdentityUser
                {
                    UserName = "admin@localhost",
                    Email = "admin@localhost"
                };

                var result = userManager.CreateAsync(user, "P@ssw0rd").Result;

                if (result.Succeeded)
                    userManager.AddToRoleAsync(user, "Administrator").Wait();
            }
        }

        public static void SeedRoles(RoleManager<IdentityRole> roleManager)
        {
            if (!roleManager.RoleExistsAsync("Administrator").Result)
            {
                var role = new IdentityRole
                {
                    Name = "Administrator"
                };

                roleManager.CreateAsync(role);
            }

            if (!roleManager.RoleExistsAsync("Employee").Result)
            {
                var role = new IdentityRole
                {
                    Name = "Employee"
                };

                roleManager.CreateAsync(role);
            }
        }
    }
}
