using Infrastructure_Layer.Data;
using MahalShop.Core.Entities;
using MahalShop.Core.Interface;

namespace Infrastructure_Layer.Repository
{
    public class ProductRepository : GenricRepository<Product>, IProductRepository
    {
        public ProductRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
