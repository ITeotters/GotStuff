using System.ComponentModel;

namespace GotStuff.ViewModels
{
    public class KnownProductsListVm
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [DisplayName("Stock Count")]
        public DateTime DefaultShelfLife { get; set; }

        public KnownProductsListVm()
        {

        }
    }
}
