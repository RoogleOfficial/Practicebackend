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
    public class GetAllCategoriesQueryHandler:IRequestHandler<GetAllCategoriesQuery,List<CategoryDto>>
    {
        private readonly ICategoryRepository _repo;
        private readonly IMapper _mapper;
        public GetAllCategoriesQueryHandler(ICategoryRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<List<CategoryDto>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
        {
            var categories = await _repo.GetAllAsync();
            return _mapper.Map<List<CategoryDto>>(categories);
        }
    }
}
