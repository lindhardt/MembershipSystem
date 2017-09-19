using Microsoft.AspNet.Identity.EntityFramework;

namespace MembershipSystem.Models
{
    public class User : IdentityUser<int, UserLogin, UserRole, UserClaim>
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
    }
}