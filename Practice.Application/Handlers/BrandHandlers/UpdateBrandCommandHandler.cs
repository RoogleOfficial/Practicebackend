using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Practice.Application.Features.Brand.Commands;
using Practice.Application.Interfaces;

namespace Practice.Application.Handlers.BrandHandlers
{
    public class UpdateBrandCommandHandler : IRequestHandler<UpdateBrandCommand, Unit>
    {
        private readonly IBrandRepository _brandRepo;
        private readonly IMapper _mapper;

        public UpdateBrandCommandHandler(IBrandRepository brandRepo, IMapper mapper)
        {
            _brandRepo = brandRepo;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateBrandCommand request, CancellationToken cancellationToken)
        {
            var existing = await _brandRepo.GetByIdAsync(request.Id);
            if (existing == null) throw new KeyNotFoundException("Brand not found");

            _mapper.Map(request.BrandDto, existing);
            await _brandRepo.UpdateAsync(existing);

            return Unit.Value;
        }


    }
}