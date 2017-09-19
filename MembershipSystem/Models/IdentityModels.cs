using Microsoft.AspNet.Identity.EntityFramework;

namespace MembershipSystem.Models
{
    public class UserRole : IdentityUserRole<int>
    {
    }

    public class UserLogin : IdentityUserLogin<int>
    {
    }

    public class UserClaim : IdentityUserClaim<int>
    {
    }
}