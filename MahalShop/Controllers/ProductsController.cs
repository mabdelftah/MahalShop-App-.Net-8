using AutoMapper;
using MahalShop.Core.Dtos;
using MahalShop.Core.Interface;
using Microsoft.AspNetCore.Mvc;

namespace MahalShop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : BaseController
    {
        public ProductsController(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }
        [HttpGet("Get-All-products")]
        public async Task<IActionResult> GetAllproducts()
        {
            try
            {
                var product = await _unitOfWork.ProductRepository
               .GetAllAsync(x => x.Category, x => x.Photos);
                var productMap = _mapper.Map<IEnumerable<ProductDto>>(product);
                if (productMap is null) return BadRequest();
                return Ok(productMap);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("Get-By-Id {id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var product = await _unitOfWork.ProductRepository.GetByIdAsync(id, x => x.Category, x => x.Photos);
                var productMap = _mapper.Map<ProductDto>(product);
                if (productMap is null) return BadRequest();
                return Ok(productMap);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Add-Product")]
        public async Task<IActionResult> AddProduct(AddProductDto productDto)
        {
            try
            {
                var product = await _unitOfWork.ProductRepository.AddAsync(productDto);
                return Ok(product);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("update-Product")]
        public async Task<IActionResult> UpdateProduct(UpdateProductDto updateProductDto)
        {
            try
            {
                var product = await _unitOfWork.ProductRepository.UpdateAsync(updateProductDto);
                return Ok(product);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
