﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;

namespace BugTracker.Extensions
{
    public static class IdentityExtensions
    {
        public static int? GetCompanyId(this IIdentity identity)
        {
            Claim claim = ((ClaimsIdentity)identity).FindFirst("CompanyId");
            return (claim != null) ? int.Parse(claim.Value) : null;

            // Another way to write return ternary (three part statement) above.
            //int result = 0;
            //if (claim != null)
            //{
            //    result = int.Parse(claim.Value);
            //}
            //else
            //{
            //    result = 0;
            //}
            //return result;
        }
    }
}
