using AutoMapper;
using Infrastructure_Layer.Data;
using MahalShop.Core.Interface;
using MahalShop.Core.IService;

namespace Infrastructure_Layer.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IImageMangementService _imageMangementService;
        public UnitOfWork(ApplicationDbContext context, IMapper mapper, IImageMangementService imageMangementService)
        {
            _context = context;
            _mapper = mapper;
            _imageMangementService = imageMangementService;
            ProductRepository = new ProductRepository(_context, _mapper, _imageMangementService);
            CategoryRepository = new CategoryRepository(_context);
            PhotoRepository = new PhotoRepository(_context);

        }
        public IProductRepository ProductRepository { get; }

        public ICategoryRepository CategoryRepository { get; }

        public IPhotoRepository PhotoRepository { get; }


    }
}
