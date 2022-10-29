using Microsoft.AspNetCore.Authorization;

namespace saitynai_server.Auth.Model
{
    public class AuthorizeByRolesAttribute : AuthorizeAttribute
    {
        public AuthorizeByRolesAttribute(params string[] roles)
        {
            Roles = String.Join(',', roles);
        }

        public AuthorizeByRolesAttribute(IReadOnlyCollection<string> allRoles)
        {
            Roles = String.Join(',', allRoles);
        }
    }
}
