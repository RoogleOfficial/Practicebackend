using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Practice.Application.DTOs;
using Practice.Application.Features.Brand.Queries;
using Practice.Application.Interfaces;

namespace Practice.Application.Handlers.BrandHandlers
{
    public class GetBrandByIdQueryHandler:IRequestHandler<GetBrandByIdQuery,BrandDto?>
    {
        private readonly IBrandRepository _brandRepo;
        private readonly IMapper _mapper;

        public GetBrandByIdQueryHandler(IBrandRepository brandRepo, IMapper mapper)
        {
            _brandRepo = brandRepo;
            _mapper = mapper;
        }

        public async Task<BrandDto?> Handle(GetBrandByIdQuery request, CancellationToken cancellationToken)
        {
            var brand = await _brandRepo.GetBrandWithProductsAsync(request.Id);
            return brand == null ? null : _mapper.Map<BrandDto>(brand);
        }
    }
}
