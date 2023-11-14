using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Identity.Models;

public class UserRole : IdentityUserRole<int>
{
    public User User { get; set; }
    public Role Role { get; set; }
}