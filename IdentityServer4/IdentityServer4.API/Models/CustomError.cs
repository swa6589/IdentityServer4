using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer4.API.Models
{
    public class CustomError
    {
        public int Code { get; set; }
        public int HttpCode { get; set; }
        public string Message { get; set; }
        public string Description { get; set; }
    }
}
