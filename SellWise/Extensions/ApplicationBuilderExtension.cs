using Microsoft.AspNetCore.Identity;
using SellWise.Infrastructure.Data.Models;
using static SellWise.Infrastructure.Constants.AdminConstant;

namespace SellWise.Extensions
{
    public static class ApplicationBuilderExtension
    {
        public static async Task CreateAdminRoleAsync(this IApplicationBuilder app)
        {
            using IServiceScope scope = app.ApplicationServices.CreateScope();
            UserManager<Cashier> userManager = scope.ServiceProvider.GetRequiredService<UserManager<Cashier>>();
            RoleManager<IdentityRole> roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            if (userManager != null && roleManager != null && await roleManager.RoleExistsAsync(AdminRoleName) == false)
            {
                IdentityRole role = new IdentityRole(AdminRoleName);
                await roleManager.CreateAsync(role);

                Cashier admin = await userManager.FindByEmailAsync("admin@mail.com");

                if (admin != null)
                {
                    await userManager.AddToRoleAsync(admin, role.Name);
                }
            }

        }
    }
}
