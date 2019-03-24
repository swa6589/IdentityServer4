using IdentityServer4.API.Enityframework.Context;
using IdentityServer4.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using IdentityServer4.API.Security;
using System.Threading.Tasks;

namespace IdentityServer4.API.Infrastructure
{
    public class AuthRepository : IAuthRepository
    {
        private ApplicationDbContext db;

        public AuthRepository(ApplicationDbContext context)
        {
            db = context;
        }

        public async Task<string> GetUserCredentials(string username)
        {
            // Return the string with the credentiasl  
            return null;
        }
        public async Task<bool> ValidateUserAsync(string username, string password)
        {
            var user = db.Users.Where(u => String.Equals(u.Username, username)).FirstOrDefault();
            if (user == null) return false;

            bool result = SHA256.VerifyHash(password, user.PasswordHash);

            return result;
        }
    }
}
