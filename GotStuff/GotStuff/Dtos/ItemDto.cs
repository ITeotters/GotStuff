using System.ComponentModel;

namespace GotStuff.Dtos
{
    public class ItemDto
    {
        [DisplayName("#")]
        public int Id { get; set; }
        public string Name { get; set; }

        public ItemDto()
        {

        }
    }
}
