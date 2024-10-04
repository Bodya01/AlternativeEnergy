using Duende.IdentityServer;
using Duende.IdentityServer.Models;
using IdentityModel;

namespace AlternativeEnergy.Identity.API
{
    public static class AuthConfig
    {
        public static IEnumerable<IdentityResource> IdentityResources =>
            new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
            };

        public static IEnumerable<ApiScope> ApiScopes =>
            new List<ApiScope>
            {
                new ApiScope("aeAPI", "Alternative Energy API")
            };

        public static IEnumerable<ApiResource> ApiResources =>
            new List<ApiResource>
            {
                new ApiResource("AlternativeEnergyAPI", "Alternative Energy API", [JwtClaimTypes.Name])
                {
                    Scopes = { "aeAPI" }
                }
            };

        public static IEnumerable<Client> Clients =>
            new List<Client>
            {
                new Client
                {
                    ClientId = "AlternativeEnergyUI",
                    ClientName = "Alternative Energy UI",
                    AccessTokenType = AccessTokenType.Jwt,
                    AllowedGrantTypes = GrantTypes.Code,
                    RequirePkce = true,
                    RequireClientSecret = false,
                    RequireConsent = false,
                    AllowAccessTokensViaBrowser = true,
                    AlwaysIncludeUserClaimsInIdToken = true,
                    AccessTokenLifetime = 36000,
                    RedirectUris = new List<string> { "https://localhost:44344/signin-oidc", "https://oauth.pstmn.io/v1/callback" },
                    PostLogoutRedirectUris = { "https://localhost:44344/signout-oidc" },
                    AllowedCorsOrigins = { "https://localhost:44344" },
                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "aeAPI"
                    },
                    Enabled = true
                }
            };
    }
}
