using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Practice.Application.Features.Brand.Commands;
using Practice.Application.Interfaces;

namespace Practice.Application.Handlers.BrandHandlers
{
    public class DeleteBrandCommandHandler:IRequestHandler<DeleteBrandCommand,Unit>
    {
        private readonly IBrandRepository _brandRepo;

        public DeleteBrandCommandHandler(IBrandRepository brandRepo) => _brandRepo = brandRepo;

        public async Task<Unit> Handle(DeleteBrandCommand request, CancellationToken cancellationToken)
        {
            await _brandRepo.DeleteAsync(request.Id);
            return Unit.Value;
        }
    }
}
