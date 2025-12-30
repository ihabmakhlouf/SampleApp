using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyApp.Application.Commands;
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
        }
    }
