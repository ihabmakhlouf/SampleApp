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

        [HttpPost]
        public async Task<IActionResult> AddProductAsync([FromBody] Product product)
            {
            var newProduct = await sender.Send(new AddProductCommand(product));
            return Ok(newProduct);
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
