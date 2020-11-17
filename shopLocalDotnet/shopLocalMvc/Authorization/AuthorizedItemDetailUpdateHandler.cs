using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Identity;
using shopLocalCommonModels.DbEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace shopLocalMvc.Authorization
{
    //ensures that account logged in is allowed to make changes to product information
    public class AuthorizedItemDetailUpdateHandler : AuthorizationHandler<OperationAuthorizationRequirement, ItemEntity>
    {
        private UserManager<IdentityUser> userManager;

        public AuthorizedItemDetailUpdateHandler(UserManager<IdentityUser> _userManager)
        {
            userManager = _userManager;
        }

        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, OperationAuthorizationRequirement requirement, ItemEntity resource)
        {
            if (context.User == null || resource == null)
            {
                return Task.CompletedTask;
            }

            if(resource.OwnerId.ToString() == userManager.GetUserId(context.User))
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}
