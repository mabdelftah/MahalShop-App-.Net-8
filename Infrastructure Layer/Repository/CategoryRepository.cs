using Infrastructure_Layer.Data;
using MahalShop.Core.Entities;
using MahalShop.Core.Interface;

namespace Infrastructure_Layer.Repository
{
    public class CategoryRepository : GenricRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
