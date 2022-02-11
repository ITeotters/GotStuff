using Microsoft.AspNetCore.Identity;

namespace GotStuff.Models
{
    public class Pantry
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string UserId { get; set; }
        public IdentityUser User  { get; set; }
    }
}
