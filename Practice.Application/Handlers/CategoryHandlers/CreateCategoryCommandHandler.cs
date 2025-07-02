using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Practice.Application.Features.Category.Commands;
using Practice.Application.Interfaces;
using Practice.Domain.Entities;

namespace Practice.Application.Handlers.CategoryHandlers
{
    public class CreateCategoryCommandHandler:IRequestHandler<CreateCategoryCommand,int>
    {
        private readonly ICategoryRepository _repo;
        private readonly IMapper _mapper;
        public CreateCategoryCommandHandler(ICategoryRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = _mapper.Map<Category>(request.CategoryDto);
            var created = await _repo.AddAsync(category);
            return created.Id;
        }
    }
}
