using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static IdentityServer4.IdentityServerConstants;
using System.Security.Claims;

using IdentityServer4.Models;
using IdentityServer4.Test;

namespace IdentityServer4.API
{
    public static class Config
    {
        public static IEnumerable<IdentityResource> GetIdentityScopes()
        {
            return new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResources.Email(),
                new IdentityResource
                {
                    Name = "role",
                }
            };
        }

        public static IEnumerable<ApiResource> GetApiScopes()
        {
            return new List<ApiResource>
            {
                new ApiResource
                {
                    Name = "api",
                    DisplayName = "SRP API",
                    Description = "SRP API Scope"
                },

                 new ApiResource("write", "Write")
                
            };
        }

        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>
            {
                
                new Client
                {
                    ClientId = "client",
                    ClientName = "API Client",
                    ClientSecrets = {new Secret("secretkey" .Sha256())},
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    Enabled = true,
                    AccessTokenType = AccessTokenType.Jwt,
                    AllowedScopes = new List<string>
                    {
                        StandardScopes.OpenId,
                        StandardScopes.Profile,
                        StandardScopes.Email,
                        StandardScopes.OfflineAccess,
                        "role",
                        "write"
                    }
                }
            };
        }

        public static List<TestUser> GetUsers()
        {
            return new List<TestUser>
            {
                new TestUser
                {
                    SubjectId = "1",
                    Username = "Swathi",
                    Password = "cdrtest",
                    Claims = new List<Claim>
                    {
                        new Claim("name", "swathi"),
                        new Claim("given-name", "swathi nagaraj"),
                        new Claim("family-name", "nagaraj"),
                        new Claim("website", "www.google.com"),
                        new Claim("email", "swathi.nagaraj@cgi.com"),
                        new Claim("role", "admin"),
                    }
                },
                        new TestUser
                {
                    SubjectId = "2",
                    Username = "Imshad",
                    Password = "cdrtest",
                    Claims = new List<Claim>
                    {
                        new Claim("name", "Imshad"),
                        new Claim("given-name", "Imshad Alam"),
                        new Claim("family-name", "Alam"),
                        new Claim("website", "www.google.com"),
                        new Claim("email", "imshad.alam@cgi.com"),
                        new Claim("role", "admin"),
                    }
                }

                    };
        }
    }
}
