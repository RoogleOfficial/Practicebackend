using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Practice.Application.DTOs;
using Practice.Application.Features.Category.Commands;
using Practice.Application.Features.Category.Queries;

namespace Practice.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CategoryController(IMediator mediator) => _mediator = mediator;

        // GET: api/category
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetAllCategoriesQuery());
            return Ok(result);
        }

        // GET: api/category/{id}
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _mediator.Send(new GetCategoryByIdQuery(id));
            if (result == null) return NotFound();
            return Ok(result);
        }

        // GET: api/category/{categoryName}
        [HttpGet("by-name/{categoryName}")]
        public async Task<IActionResult> GetProductsByCategoryName(string categoryName)
        {
            var result = await _mediator.Send(new GetProductsByCategory(categoryName));
            if (result == null) return NotFound();
            return Ok(result.ProductNames);
        }

        // POST: api/category
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CUCategoryDto dto)
        {
            var id = await _mediator.Send(new CreateCategoryCommand(dto));
            return CreatedAtAction(nameof(GetById), new { id }, new { id });
        }

        // PUT: api/category/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] CUCategoryDto dto)
        {
            await _mediator.Send(new UpdateCategoryCommand(id, dto));
            return NoContent();
        }

        // DELETE: api/category/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _mediator.Send(new DeleteCategoryCommand(id));
            return NoContent();
        }
    }
}
