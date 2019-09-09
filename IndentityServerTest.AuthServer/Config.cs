using IdentityServer4.Models;
using IndentityServerTest.BusinessLayer;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace IndentityServerTest.AuthServer
{
    public class Config
    {
        private static UserRepository _users;

        public Config(UserRepository users)
        {
            _users = users;
        }

        // Clients allowed to access resources from Auth Server
        public static IEnumerable<Client> GetClients()
        {
            var data = _users.GetAll();

            return data.Select(i => new Client
            {
                ClientId = i.Username,
                AllowedGrantTypes = GrantTypes.ClientCredentials,
                ClientSecrets =
                {
                    new Secret(i.Password.Sha256())
                },
                AllowedScopes = { "sample-project" },
                Claims = new List<Claim>
                {
                    new Claim("userid", i.ID.ToString()),
                    new Claim("first_name", i.FirstName),
                    new Claim("other_names", i.OtherNames),
                    new Claim("last_name", i.LastName),
                    new Claim("role", i.Role),
                }
            });
        }

        // APIs allowed to access the Auth server
        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource>
            {
                new ApiResource("sample-project", "Sample Project API")
            };
        }
    }
}
