using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GotStuff.ViewModels
{
    public class KnownProductVm
    {
        public int KnownProductId { get; set; }

        [Required]
        public string Name { get; set; }

        [DisplayName("Shelf Life")]
        public int DefaultShelfLife { get; set; }

        public KnownProductVm()
        {

        }
    }
}
