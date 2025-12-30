using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyApp.Application.Commands;
using MyApp.Application.Queries;
using MyApp.Domain.Entities;

namespace MyApp.Api.Controllers
    {
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController(ISender sender) : ControllerBase
        {

        [HttpPost("AddProduct")]
        public async Task<IActionResult> AddProductAsync([FromBody] Product product)
            {
            var newProduct = await sender.Send(new AddProductCommand(product));
            return Ok(newProduct);
            }

        [HttpPost("UpdateProduct")]
        public async Task<IActionResult> UpdateProductAsync([FromBody] Product product, Guid id)
            {
            var result = await sender.Send(new UpdateProductCommand(id, product));
            return Ok(result);
            }

        [HttpPost("DeleteProductById")]
        public async Task<IActionResult> DeleteProductByIdAsync(Guid id)
            {
            var result = await sender.Send(new DeleteProductByIdCommand(id));
            return Ok(result);
            }

        [HttpGet("GetAllProducts")]
        public async Task<IActionResult> GetAllProductsAsync()
            {
            var products = await sender.Send(new GetProductsQuery());
            return Ok(products);
            }

        [HttpGet("GetProductById")]
        public async Task<IActionResult> GetProductByIdAsync(Guid id)
            {
            var product = await sender.Send(new GetProductByIdQuery(id));
            return Ok(product);
            }
        }
    }
