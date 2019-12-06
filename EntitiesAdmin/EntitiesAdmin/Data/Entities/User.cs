using Microsoft.AspNetCore.Identity;

namespace EntitiesAdmin.Data.Entities
{
    public class User : IdentityUser
    {
        public Employee Employee { get; set; }
    }
}
