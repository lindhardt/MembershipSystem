using Microsoft.AspNet.Identity.EntityFramework;

namespace MembershipSystem.Models
{
    public class Role : IdentityRole<int, UserRole>
    {
        public int RoleId { get; set; }
    }
}