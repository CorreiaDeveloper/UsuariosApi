using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace UsuariosApi.Authorization
{
    public class IdadeAuthorization : AuthorizationHandler<IdadeMinima>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, IdadeMinima requirement)
        {
            var BirthDateClaim = context.User.FindFirst(claim => claim.Type == ClaimTypes.DateOfBirth);

            if (BirthDateClaim is null)
                return Task.CompletedTask;

            var BirthDate = Convert.ToDateTime(BirthDateClaim.Value);

            var ageUser = DateTime.Today.Year - BirthDate.Year;

            if (BirthDate > DateTime.Today.AddYears(-ageUser))
                ageUser--;

            if (ageUser >= requirement.Age)
                context.Succeed(requirement);

            return Task.CompletedTask;
        }
    }
}