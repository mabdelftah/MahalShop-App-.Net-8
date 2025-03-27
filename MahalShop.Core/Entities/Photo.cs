using System.ComponentModel.DataAnnotations.Schema;

namespace MahalShop.Core.Entities
{
    public class Photo : BaseEntity<int>
    {
        public string ImageName { get; set; }
        public int ProductId { get; set; }
        [ForeignKey(nameof(ProductId))]
        public virtual Product Product { get; set; }
    }
}
