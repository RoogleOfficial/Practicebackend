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
    public class GetallBrandsQueryHandler:IRequestHandler<GetAllBrandsQuery,List<BrandDto>>
    {
        private readonly IBrandRepository _brandRepo;
        private readonly IMapper _mapper;

        public GetallBrandsQueryHandler(IBrandRepository brandRepo, IMapper mapper)
        {
            _brandRepo = brandRepo;
            _mapper = mapper;
        }

        public async Task<List<BrandDto>> Handle(GetAllBrandsQuery request, CancellationToken cancellationToken)
        {
            var brands = await _brandRepo.GetAllAsync();
            return _mapper.Map<List<BrandDto>>(brands);
        }
    }
}
