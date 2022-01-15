namespace GotStuff.Dtos
{
    public class ItemDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }    
        public string AcquiredDate { get; set; }
        public string ExpirationDate { get; set; }

        public ItemDto()
        {

        }
        // TODO: Maybe have categories?
    }
}
