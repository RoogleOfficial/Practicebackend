using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Practice.Application.Features.Category.Commands;
using Practice.Application.Interfaces;

namespace Practice.Application.Handlers.CategoryHandlers
{
    public class DeleteCategoryCommandHandler:IRequestHandler<DeleteCategoryCommand,Unit>
    {
        private readonly ICategoryRepository _repo;
        public DeleteCategoryCommandHandler(ICategoryRepository repo) => _repo = repo;

        public async Task<Unit> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            await _repo.DeleteAsync(request.Id);
            return Unit.Value;
        }
    }
}
