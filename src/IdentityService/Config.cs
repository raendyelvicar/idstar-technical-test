using Duende.IdentityServer.Models;

namespace IdentityService;

public static class Config
{
    public static IEnumerable<IdentityResource> IdentityResources =>
        new IdentityResource[]
        {
            new IdentityResources.OpenId(),
            new IdentityResources.Profile(),
        };

    public static IEnumerable<ApiScope> ApiScopes =>
        new ApiScope[]
        {
            new ApiScope("transactionApp", "Transaction app full access"),
        };

    public static IEnumerable<Client> Clients =>
        new Client[]
        {
            new Client
            {
                ClientId = "postman",
                ClientName = "Postman",
                AllowedScopes = { "openid", "profile", "transactionApp" },
                RedirectUris = {"https://www.getpostman.com/oauth2/callback"},
                ClientSecrets = new[] { new Secret("postman".Sha256()) },
                AllowedGrantTypes = {GrantType.ResourceOwnerPassword},
            },
            new Client
            {
                ClientId = "clientApp",
                ClientName = "clientApp",
                AllowedScopes = { "openid", "profile", "transactionApp" },
                RedirectUris = {"http://localhost:3000/api/auth/callback/id-server"},
                ClientSecrets = new[] { new Secret("secret".Sha256()) },
                AllowedGrantTypes = GrantTypes.CodeAndClientCredentials,
                AllowOfflineAccess = true,
                RequirePkce = false,
                AccessTokenLifetime = 3600*24*30,
                AlwaysIncludeUserClaimsInIdToken = true
            },

            
        };
}
