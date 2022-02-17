namespace GotStuff.Models
{
    public class PantryUsers
    {
        public int PantryId { get; set; }
        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }
        public Pantry Pantry { get; set; }
    }
}
