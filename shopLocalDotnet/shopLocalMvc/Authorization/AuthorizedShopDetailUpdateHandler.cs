using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using shopLocalDataAccess.Entities;
using Microsoft.AspNetCore.Identity;


namespace shopLocalMvc.Authorization
{
    //ensures that the account logged in, is allowed to make changes to account information
    public class AuthorizedShopDetailUpdateHandler : AuthorizationHandler<OperationAuthorizationRequirement,ShopEntity>
    {
        private UserManager<IdentityUser> userManager;

        public AuthorizedShopDetailUpdateHandler(UserManager<IdentityUser> _userManager)
        {
            userManager = _userManager;
        }
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, OperationAuthorizationRequirement requirement, ShopEntity resource)
        {
            //context.User.HasClaim(claim => claim.)
            if(context.User == null || resource == null)
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
