using Microsoft.AspNetCore.Http;

namespace MahalShop.Core.IService
{
    public interface IImageMangementService
    {
        Task<List<string>> AddImageAsync(IFormFileCollection files, string src);
        void DeleteImageAsync(string src);

    }
}
