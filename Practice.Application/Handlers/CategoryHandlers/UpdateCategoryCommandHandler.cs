using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Practice.Application.Features.Category.Commands;
using Practice.Application.Interfaces;

namespace Practice.Application.Handlers.CategoryHandlers
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, Unit>
    {
        private readonly ICategoryRepository _repo;
        private readonly IMapper _mapper;
        public UpdateCategoryCommandHandler(ICategoryRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var existing = await _repo.GetByIdAsync(request.Id);
            if (existing == null) throw new KeyNotFoundException("Category not found");
            _mapper.Map(request.CategoryDto, existing);
            await _repo.UpdateAsync(existing);
            return Unit.Value;
        }
    }
}
