using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Practice.Application.DTOs;
using Practice.Application.Features.Product.Queries;
using Practice.Application.Interfaces;

namespace Practice.Application.Handlers.ProductHandlers
{
    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery,ProductDto?>
    {
        private readonly IProductRepository _repo;
        private readonly IMapper _mapper;
        public GetProductByIdQueryHandler(IProductRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<ProductDto?> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var product = await _repo.GetByIdAsync(request.Id);
            return product == null ? null : _mapper.Map<ProductDto>(product);
        }
    }
}
