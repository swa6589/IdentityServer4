
using IdentityServer4.API.Models;
using IdentityServer4.Models;
using IdentityServer4.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer4.API.Security
{
    public class ResourceOwnerPasswordValidator : IResourceOwnerPasswordValidator
    {
        private readonly IAuthRepository _authRep;
        public ResourceOwnerPasswordValidator(IAuthRepository authRep)
        {
            _authRep = authRep; //Dependency inyection to call the methods in the ValidateAsync Method.
        }

        /**
         * The “ValidateAsync” method in the  code simply uses the “AuthRepository” to search the Users in the webservice verify their password.
         * */
        public Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
        {
            var task = _authRep.ValidateUserAsync(context.UserName, context.Password);
         
            if (Convert.ToBoolean(task)) // if the user is valid
            {
                context.Result = new GrantValidationResult(context.UserName, "password", null, "local", null); //this will set the userID that we well use to get the claims in the ProfileService.cs
            }
            else
            {
                context.Result = new GrantValidationResult(TokenRequestErrors.InvalidGrant, "The user or password are incorrect", null);
            }
            return Task.FromResult(context.Result);
        }
    }
}