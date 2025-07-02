using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Practice.Application.Features.Product.Commands;
using Practice.Application.Interfaces;

namespace Practice.Application.Handlers.ProductHandlers
{
    public class UpdateProductCommandHandler:IRequestHandler<UpdateProductCommand,Unit>
    {
        private readonly IProductRepository _repo;
        private readonly IMapper _mapper;
        public UpdateProductCommandHandler(IProductRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var existing = await _repo.GetByIdAsync(request.Id);
            if (existing == null) throw new KeyNotFoundException("Product not found");
            _mapper.Map(request.ProductDto, existing);
            await _repo.UpdateAsync(existing);
            return Unit.Value;
        }
    }
}
