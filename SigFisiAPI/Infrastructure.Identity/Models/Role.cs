using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Identity.Models;

public class Role : IdentityRole<int>
{
    public ICollection<UserRole> UserRoles { get; set; }
}