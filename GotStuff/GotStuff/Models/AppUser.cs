using Microsoft.AspNetCore.Identity;

namespace GotStuff.Models
{
    public class AppUser : IdentityUser
    {
        public string FullName { get; set; }
        public List<Pantry> Pantries { get; set; }
    }
}
