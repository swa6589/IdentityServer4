using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer4.API.Enityframework.Context
{
    public class User
    {
        [Key]
        public string Id { get; set; }
        public string SubjectId { get; set; }
        public string Username { get; set; }
        public string PasswordSalt { get; set; }
        public string PasswordHash { get; set; }
        public string ProviderName { get; set; }
        public string ProviderSubjectId { get; set; }
    }
}
