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

        public Item(int id, string name, string description, string acquiredDate, string expirationDate)
        {
            this.Id = id;
            this.Name = name;
            this.Description = description;
            this.AcquiredDate = acquiredDate;
            this.ExpirationDate = expirationDate;
        }

        // TODO: Maybe have categories?
    }
}
