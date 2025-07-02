using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Practice.Application.DTOs;
using Practice.Application.Features.Brand.Commands;
using Practice.Application.Features.Brand.Queries;

namespace Practice.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BrandController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/Brand
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetAllBrandsQuery());
            return Ok(result);
        }

        // GET: api/Brand/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _mediator.Send(new GetBrandByIdQuery(id));
            if (result == null)
                return NotFound($"Brand with ID {id} not found.");
            return Ok(result);
        }

        // POST: api/Brand
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CUBrandDto brandDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var id = await _mediator.Send(new CreateBrandCommand(brandDto));
            return CreatedAtAction(nameof(GetById), new { id }, new { id });
        }

        // PUT: api/Brand/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] CUBrandDto brandDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _mediator.Send(new UpdateBrandCommand(id, brandDto));
            return NoContent();
        }

        // DELETE: api/Brand/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _mediator.Send(new DeleteBrandCommand(id));
            return NoContent();
        }
    }
}
