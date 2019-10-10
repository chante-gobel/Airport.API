using Microsoft.AspNetCore.Authorization;

namespace Airport.API.Authorization
{
    public class OnlyThirdPartiesRequirement: IAuthorizationRequirement
    {
    }
}
