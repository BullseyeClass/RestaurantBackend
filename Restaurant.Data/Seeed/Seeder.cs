using Microsoft.AspNetCore.Identity;
using Restaurant.Data.Context;
using Restaurant.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Data.Seeed
{
    public class Seeder
    {
        public async static Task Seed(RoleManager<IdentityRole> roleManager, UserManager<Customer> userManager, MyAppContext dbContext)
        {
            await dbContext.Database.EnsureCreatedAsync();
            await SeedRoles(roleManager, dbContext);
            await SeedUser(userManager, roleManager, dbContext);
            await SeedCustomerSupport(dbContext);
            await SeedProduct(dbContext);
            await SeedAddress(dbContext);
        }
        private static async Task SeedRoles(RoleManager<IdentityRole> roleManager, MyAppContext dbContext)
        {
            if (!dbContext.Roles.Any())
            {
                var roles = SeederHelper<string>.GetData("Roles.json");
                foreach (var role in roles)
                {
                    await roleManager.CreateAsync(new IdentityRole { Name = role });
                }
            }
        }
        private static async Task SeedUser(UserManager<Customer> userManager, RoleManager<IdentityRole> roleManager, MyAppContext dbContext)
        {
            if (!dbContext.Users.Any())
            {
                var users = SeederHelper<Customer>.GetData("Customer.json");
                foreach (var user in users)
                {
                    user.EmailConfirmed = true;
                    var result = await userManager.CreateAsync(user, "Rest@123");

                    if (result.Succeeded)
                    {
                        // Check if the role exists before attempting to add it
                        var customerRoleExists = await roleManager.RoleExistsAsync("Customer");
                        if (customerRoleExists)
                        {
                            await userManager.AddToRoleAsync(user, "Customer");
                        }
                    }
                }
            }


        }

        private static async Task SeedCustomerSupport(MyAppContext dbContext)
        {
            if (!dbContext.CustomerSupports.Any())
            {
                var products = SeederHelper<CustomerSupport>.GetData("CustomerSupport.json");
                await dbContext.CustomerSupports.AddRangeAsync(products);
                await dbContext.SaveChangesAsync();
            }
        }
        private static async Task SeedProduct(MyAppContext dbContext)
        {
            if (!dbContext.Products.Any())
            {
                var products = SeederHelper<Product>.GetData("Product.json");
                await dbContext.Products.AddRangeAsync(products);
                await dbContext.SaveChangesAsync();
            }
        }

        private static async Task SeedAddress(MyAppContext dbContext)
        {
            if (!dbContext.Addresses.Any())
            {
                var products = SeederHelper<Address>.GetData("Address.json");
                await dbContext.Addresses.AddRangeAsync(products);
                await dbContext.SaveChangesAsync();
            }
        }

    }
}
