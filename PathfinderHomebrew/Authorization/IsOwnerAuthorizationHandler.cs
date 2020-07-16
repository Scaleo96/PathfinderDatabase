using PathfinderHomebrew.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using Microsoft.VisualBasic;

namespace PathfinderHomebrew.Authorization
{
    public class IsOwnerAuthorizationHandler : AuthorizationHandler<OperationAuthorizationRequirement, string>
    {
        UserManager<IdentityUser> _userManager;

        public IsOwnerAuthorizationHandler(UserManager<IdentityUser>
            userManager)
        {
            _userManager = userManager;
        }

        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, OperationAuthorizationRequirement requirement, string resource)
        {
            if (context.User == null || resource == null)
            {
                return Task.CompletedTask;
            }

            //if (requirement.Name != Constants.CreateOperationName &&
            //    requirement.Name != Constants.ReadOperationName &&
            //    requirement.Name != Constants.UpdateOperationName &&
            //    requirement.Name != Constants.DeleteOperationName)
            //{
            //    return Task.CompletedTask;
            //}

            if (resource == _userManager.GetUserId(context.User))
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}
