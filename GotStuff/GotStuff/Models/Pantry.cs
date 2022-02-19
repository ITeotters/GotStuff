using Microsoft.AspNetCore.Identity;

namespace GotStuff.Models
{
    public class Pantry
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<AppUser> AppUsers { get; set; }

        public Pantry()
        {
            this.AppUsers = new HashSet<AppUser>();
        }
    }
}
