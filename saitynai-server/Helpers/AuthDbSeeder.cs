using Microsoft.AspNetCore.Identity;
using saitynai_server.Auth;
using saitynai_server.Auth.Model;

namespace saitynai_server.Helpers
{
    public class AuthDbSeeder
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AuthDbSeeder(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task SeedAsync()
        {
            await AddDefaultRoles();
            await AddAdminUser();
        }

        private async Task AddDefaultRoles()
        {
            foreach (var role in Roles.All)
            {
                var roleExists = await _roleManager.RoleExistsAsync(role);
                if (!roleExists)
                    await _roleManager.CreateAsync(new IdentityRole(role));
            }
        }

        private async Task AddAdminUser()
        {
            var newAdminUser = new User
            {
                UserName = "admin",
                Email = "admin@email.com"
            };

            var existingAdminUser = await _userManager.FindByNameAsync(newAdminUser.UserName);
            if (existingAdminUser == null)
            {
                var createAdminUserResult = await _userManager.CreateAsync(newAdminUser, "password123");
                if (createAdminUserResult.Succeeded)
                {
                    await _userManager.AddToRoleAsync(newAdminUser, Roles.Admin);
                }
            }
        }
    }
}
