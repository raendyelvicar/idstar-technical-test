using System.Security.Claims;
using Duende.IdentityServer.Models;
using Duende.IdentityServer.Services;
using IdentityModel;
using IdentityService.Models;
using Microsoft.AspNetCore.Identity;

namespace IdentityService;
public class CustomProfileService : IProfileService
{
    private readonly UserManager<ApplicationUser> _userManager;

    public CustomProfileService(UserManager<ApplicationUser> userManager)
    {
        _userManager = userManager;
    }
    public async Task GetProfileDataAsync(ProfileDataRequestContext context)
    {
        var user = await _userManager.GetUserAsync(context.Subject);
        var existingClaims = await _userManager.GetClaimsAsync(user);   

        var claims = new List<Claim>
        {
            new Claim("sub", user.Id),
            new Claim("username", user.UserName),
            new Claim("email", user.Email)
        };

        context.IssuedClaims.AddRange(claims);

        var userIdClaim = claims.FirstOrDefault(x => x.Type == JwtClaimTypes.Subject);
        if (userIdClaim == null)
        {
            userIdClaim = claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier);
        } 
        if (userIdClaim == null)
        {
            throw new Exception("Unknown userid");
        } else {
            context.IssuedClaims.Add(userIdClaim);
        }

    }

    public Task IsActiveAsync(IsActiveContext context)
    {
        return Task.CompletedTask;
    }
}
