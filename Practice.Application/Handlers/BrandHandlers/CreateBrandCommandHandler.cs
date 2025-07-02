using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Practice.Application.Features.Brand.Commands;
using Practice.Application.Interfaces;
using Practice.Domain.Entities;

namespace Practice.Application.Handlers.BrandHandlers
{
    public class CreateBrandCommandHandler : IRequestHandler<CreateBrandCommand, int>
    {
        private readonly IBrandRepository _brandRepo;
        private readonly IMapper _mapper;

        public CreateBrandCommandHandler(IBrandRepository brandRepo, IMapper mapper)
        {
            _brandRepo = brandRepo;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateBrandCommand request, CancellationToken cancellationToken)
        {
            var brand = _mapper.Map<Brand>(request.BrandDto);
            var result = await _brandRepo.AddAsync(brand);
            return result.Id;
        }

        
    }
}
