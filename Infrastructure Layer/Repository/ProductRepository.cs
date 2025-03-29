using AutoMapper;
using Infrastructure_Layer.Data;
using MahalShop.Core.Dtos;
using MahalShop.Core.Entities;
using MahalShop.Core.Interface;
using MahalShop.Core.IService;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure_Layer.Repository
{
    public class ProductRepository : GenricRepository<Product>, IProductRepository
    {
        // Remember Handel IUnitOfWork 
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;
        private readonly IImageMangementService imageMangementService;
        public ProductRepository(ApplicationDbContext context, IMapper mapper, IImageMangementService imageMangementService) : base(context)
        {
            this.mapper = mapper;
            this.context = context;
            this.imageMangementService = imageMangementService;
        }

        public async Task<bool> AddAsync(AddProductDto productDto)
        {
            if (productDto == null) return false;
            var product = mapper.Map<Product>(productDto);
            await context.Products.AddAsync(product);
            await context.SaveChangesAsync();
            var ImagePath = await imageMangementService.AddImageAsync(productDto.Photo, productDto.Name);
            // mapping with photo
            var photo = ImagePath.Select(path => new Photo
            {
                ImageName = path,
                ProductId = product.Id,
            }).ToList();
            await context.Photos.AddRangeAsync(photo);
            await context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> AddAsync(UpdateProductDto updateProductDto)
        {
            if (updateProductDto == null) return false;
            // get product from DB
            var FindProduct = await context.Products.Include(m => m.Category)
                .Include(m => m.Photos)
                .FirstOrDefaultAsync(m => m.Id == updateProductDto.Id);
            if (FindProduct == null) return false;
            // mapping from dto to product
            mapper.Map(FindProduct, updateProductDto);
            // handel Image
            // get Image from DB
            var FindPhoto = await context.Photos.Where(m => m.ProductId == updateProductDto.Id).ToListAsync();
            foreach (var item in FindPhoto)
            {
                imageMangementService.DeleteImageAsync(item.ImageName);
            }
            context.Photos.RemoveRange(FindPhoto);
            var ImagePath = await imageMangementService.AddImageAsync(updateProductDto.Photo, updateProductDto.Name);
            // mapping with photo
            var photo = ImagePath.Select(path => new Photo
            {
                ImageName = path,
                ProductId = updateProductDto.Id,
            }).ToList();
            await context.Photos.AddRangeAsync(photo);
            await context.SaveChangesAsync();
            return true;
        }
    }
}
