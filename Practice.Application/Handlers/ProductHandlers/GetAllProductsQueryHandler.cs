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
    public class GetAllProductsQueryHandler:IRequestHandler<GetAllProductsQuery,List<ProductDto>>
    {
        private readonly IProductRepository _repo;
        private readonly IMapper _mapper;
        public GetAllProductsQueryHandler(IProductRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<List<ProductDto>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            var products = await _repo.GetAllAsync();
            return _mapper.Map<List<ProductDto>>(products);
        }
    }
}
