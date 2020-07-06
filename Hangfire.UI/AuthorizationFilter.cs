using Hangfire.Dashboard;

namespace Hangfire.UI
{
    public class AuthorizationFilter : IDashboardAuthorizationFilter
    {
        public bool Authorize(DashboardContext context)
        {
            var httpContext = context.GetHttpContext();

            // Allow all authenticated users to see the Dashboard (potentially dangerous).
            return true;
        }
    }
}
