using Microsoft.AspNetCore.Identity;

namespace EntitiesAdmin.Data.Entities
{
    public class User : IdentityUser
    {
        public Employees Employee { get; set; }
    }
}
