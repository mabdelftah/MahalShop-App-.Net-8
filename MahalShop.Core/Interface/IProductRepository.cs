using MahalShop.Core.Dtos;
using MahalShop.Core.Entities;

namespace MahalShop.Core.Interface
{
    public interface IProductRepository : IGenricRepository<Product>
    {
        Task<bool> AddAsync(AddProductDto productDto);
        Task<bool> UpdateAsync(UpdateProductDto updateProductDto);
    }
}
