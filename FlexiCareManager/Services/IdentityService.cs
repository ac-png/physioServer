using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using FlexiCareManager.Data;

namespace FlexiCareManager.Services;

public class IdentityService
{
    public static async Task CreateUser(UserStore<IdentityUser> userStore, string name, string email)
    {
        var user = new IdentityUser
        {
            Email = email,
            NormalizedEmail = email.ToUpper(),
            UserName = email,
            NormalizedUserName = email.ToUpper(),
            PhoneNumber = "+111111111111",
            EmailConfirmed = true,
            PhoneNumberConfirmed = true,
            SecurityStamp = Guid.NewGuid().ToString("D")
        };

        var password = new PasswordHasher<IdentityUser>();
        var hashed = password.HashPassword(user, "Password1!");
        user.PasswordHash = hashed;

        var result = await userStore.CreateAsync(user);
    }

    public static async Task AddRoles(UserManager<IdentityUser> userManager, string email, String[] roles)
    {
        var user = await userManager.FindByEmailAsync(email);
        var result = await userManager.AddToRolesAsync(user!, roles);
    }

}
