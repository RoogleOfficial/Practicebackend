using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Practice.Application.DTOs;
using Practice.Application.Features.Product.Commands;
using Practice.Application.Features.Product.Queries;

namespace Practice.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ProductController(IMediator mediator) => _mediator = mediator;

        // GET: api/product
        [HttpGet]
        //[Authorize(Roles = "user")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetAllProductsQuery());
            return Ok(result);
        }

        // GET: api/product/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _mediator.Send(new GetProductByIdQuery(id));
            if (result == null) return NotFound();
            return Ok(result);
        }

        // POST: api/product
        [HttpPost]
        //[Authorize(Roles ="admin")]
        public async Task<IActionResult> Create([FromBody] ProductDto dto)
        {
            var id = await _mediator.Send(new CreateProductCommand(dto));
            return CreatedAtAction(nameof(GetById), new { id }, new { id });
        }

        // PUT: api/product/{id}
        [HttpPut("{id}")]
        //[Authorize(Roles = "admin")]
        public async Task<IActionResult> Update(int id, [FromBody] ProductDto dto)
        {
            await _mediator.Send(new UpdateProductCommand(id, dto));
            return NoContent();
        }

        // DELETE: api/product/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _mediator.Send(new DeleteProductCommand(id));
            return NoContent();
        }
    }
}
