using System.Threading.Tasks;
using PathfinderHomebrew.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Identity;

namespace PathfinderHomebrew.Authorization
{
    public class ManagerAuthorizationHandler : AuthorizationHandler<OperationAuthorizationRequirement, string>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, OperationAuthorizationRequirement requirement, string resource)
        {
            if (context.User == null || resource == null)
            {
                return Task.CompletedTask;
            }

            // If not asking for approval/reject, return.
            //if (requirement.Name != Constants.ApproveOperationName &&
            //    requirement.Name != Constants.RejectOperationName)
            //{
            //    return Task.CompletedTask;
            //}

            // Managers can approve or reject.
            if (context.User.IsInRole("Manager"))
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}
