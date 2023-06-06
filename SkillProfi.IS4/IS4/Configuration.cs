using IdentityModel;
using IdentityServer4;
using IdentityServer4.Models;

namespace IS4
{
    public static class Configuration
    {
        public static IEnumerable<Client> GetClients() => new List<Client>() 
        {
            new Client()
            {
                ClientId = "AspClient",
                ClientSecrets = { new Secret("Asp.Secret".ToSha256()) },
                AllowedGrantTypes = GrantTypes.Code,
                RedirectUris =
                {
                    "https://localhost:../signin-oidc"
                },
                AllowedScopes =
                {
                    "api",
                    IdentityServerConstants.StandardScopes.OpenId,
                    IdentityServerConstants.StandardScopes.Profile,
                },
               PostLogoutRedirectUris =
               {
                    "https://localhost:../signout-callback-oidc"
               }
            }
        };
        public static IEnumerable<IdentityResource> GetIdentityResources() => new List<IdentityResource>()
        {
            new IdentityResources.OpenId(),
            new IdentityResources.Profile(),
        };
        public static IEnumerable<ApiResource> GetApiResources() => new List<ApiResource>()
        {
            new ApiResource("api", "My Api", new [] { JwtClaimTypes.Name })
            {
                Scopes = { "api" }
            }
        };
        public static IEnumerable<ApiScope> GetApiScopes() => new List<ApiScope>()
        {
            new ApiScope("api")
        };
        
    }
}
