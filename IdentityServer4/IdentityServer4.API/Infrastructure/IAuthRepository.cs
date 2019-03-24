using IdentityServer4.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer4.API
{
    public interface IAuthRepository
    {
        Task<bool> ValidateUserAsync(string username, string password);
        Task<string> GetUserCredentials(string username);
    }
}
