using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Practice.Application.DTOs;
using Practice.Application.Features.Category.Queries;
using Practice.Application.Interfaces;

namespace Practice.Application.Handlers.CategoryHandlers
{
    public class GetCategoryByIdQueryHandler:IRequestHandler<GetCategoryByIdQuery,CategoryDto?>
    {
        private readonly ICategoryRepository _repo;
        private readonly IMapper _mapper;
        public GetCategoryByIdQueryHandler(ICategoryRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<CategoryDto?> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
        {

            var category = await _repo.GetByIdAsync(request.Id);
            Console.WriteLine("Products count: " + category.products.Count);
            foreach (var p in category.products)
            {
                Console.WriteLine("Product: " + p.Name);
            }
            return category == null ? null : _mapper.Map<CategoryDto>(category);
            
        }
    }
}
