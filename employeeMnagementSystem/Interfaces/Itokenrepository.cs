using Microsoft.AspNetCore.Identity;

namespace WebApplication1.Interfaces
{
    public interface Itokenrepository
    {
        string CreateJWTToken(IdentityUser user , List<string> roles);
    }
}
