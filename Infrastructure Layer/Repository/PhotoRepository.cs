using Infrastructure_Layer.Data;
using MahalShop.Core.Entities;
using MahalShop.Core.Interface;

namespace Infrastructure_Layer.Repository
{
    public class PhotoRepository : GenricRepository<Photo>, IPhotoRepository
    {
        public PhotoRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
