//using Hangfire.Dashboard;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MES.Web.Models
{
    public class HangfireDashboardAuthorizationFilter  /*IDashboardAuthorizationFilter*/
    {
        //public bool Authorize([NotNull]DashboardContext context)
        //{
        //    var httpContext = context.GetHttpContext();
        //    var useRole = httpContext.User.FindFirst(ClaimTypes.Role)?.Value;
        //    //return useRole == AppRoles.RoleEnums.HangfireOpenUser.ToString();
        //    //return useRole == "Admin";
        //    //return httpContext.User.Identity.IsAuthenticated;
        //    return true;
        //}
    }
}
