namespace GotStuff.Models
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ExpirationDate { get; set; }
        public string AcquiredDate { get; set; }

        public Item()
        {

        }

        // TODO: Maybe have categories?
    }
}
