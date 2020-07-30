﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace BlogIT.Models
{
    public class IdentityHelper
    {
        public const string Admin = "Admin";
        public const string User = "User";

        public static void SetIdentityOptions(IdentityOptions options)
        {
            // Signin options
            options.SignIn.RequireConfirmedEmail = false;
            options.SignIn.RequireConfirmedPhoneNumber = false;
            // Set Password strength
            options.Password.RequireDigit = true;
            options.Password.RequireLowercase = false;
            options.Password.RequireUppercase = false;
            options.Password.RequiredLength = 8;
            options.Password.RequireNonAlphanumeric = false;
        }

        public static async Task CreateRoles(IServiceProvider provider, params string[] roles)
        {
            RoleManager<IdentityRole> roleManager = provider.GetRequiredService<RoleManager<IdentityRole>>();

            // Create the role if it does not exist
            foreach (string role in roles)
            {
                bool doesRoleExist = await roleManager.RoleExistsAsync(role);

                if (!doesRoleExist)
                {
                    await roleManager.CreateAsync(new IdentityRole(role));
                }
            }
        }
    }
}