using Microsoft.AspNetCore.Identity;

namespace GotStuff.Models
{
    public class AppUser : IdentityUser
    {
        public string FullName { get; set; }
        public ICollection<Pantry> Pantries { get; set; }

        public AppUser()
        {
            this.Pantries = new HashSet<Pantry>();
        }
    }
}
