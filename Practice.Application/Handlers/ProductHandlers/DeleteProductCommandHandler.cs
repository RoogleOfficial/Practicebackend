using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Practice.Application.Features.Product.Commands;
using Practice.Application.Interfaces;

namespace Practice.Application.Handlers.ProductHandlers
{
    public class DeleteProductCommandHandler:IRequestHandler<DeleteProductCommand,Unit>
    {
        private readonly IProductRepository _repo;
        public DeleteProductCommandHandler(IProductRepository repo) => _repo = repo;

        public async Task<Unit> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            await _repo.DeleteAsync(request.Id);
            return Unit.Value;
        }
    }
}
