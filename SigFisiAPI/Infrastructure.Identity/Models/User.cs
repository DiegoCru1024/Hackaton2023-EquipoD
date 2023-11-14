using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Identity.Models;

public class User : IdentityUser<int>
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public ICollection<IdentityUserClaim<int>>? Claims { get; set; }
    public ICollection<IdentityUserLogin<int>>? Logins { get; set; }
    public ICollection<IdentityUserToken<int>>? Tokens { get; set; }
    public ICollection<UserRole>? UserRoles { get; set; }
}