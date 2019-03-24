using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer4.API.Models
{
    public class ValidateUser
    {
      
        public string NetworkName { get; set; }

        public int? NextPasswordChange { get; set; }


        public int? Result { get; set; }

        public string SessionID { get; set; }
      
        public int? UserID { get; set; }

        public string UserName { get; set; }
    }
}
