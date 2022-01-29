using System.ComponentModel;

namespace GotStuff.ViewModels
{
    public class KnownProductsListVm
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [DisplayName("Shelf Life")]
        public int DefaultShelfLife { get; set; }

        public KnownProductsListVm()
        {

        }
    }
}
