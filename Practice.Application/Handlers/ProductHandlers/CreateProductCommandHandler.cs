using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Practice.Application.Features.Product.Commands;
using Practice.Application.Interfaces;
using Practice.Domain.Entities;

namespace Practice.Application.Handlers.ProductHandlers
{
    public class CreateProductCommandHandler:IRequestHandler<CreateProductCommand,int>
    {
        private readonly IProductRepository _productRepo;
        private readonly ICategoryRepository _categoryRepo;
        private readonly IMapper _mapper;
        public CreateProductCommandHandler(IProductRepository productrepo, ICategoryRepository categoryrepo, IMapper mapper)
        {
            _productRepo = productrepo;
            _categoryRepo = categoryrepo;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {

            // Step 1: Get all categories from DB
            var categories = await _categoryRepo.GetCategoriesByListOfIds(request.ProductDto.CategoryIds);

            // Step 2: Map DTO to Entity
            var product = _mapper.Map<Product>(request.ProductDto);

            // Step 3: Assign categories manually (AutoMapper can’t handle this automatically)
            product.Categories = categories.ToList();

            // Step 4: Save to DB
            var createdProduct = await _productRepo.AddAsync(product);
            return createdProduct.Id;




            //var product = _mapper.Map<Product>(request.ProductDto);
            //var created = await _repo.AddAsync(product);
            //return created.Id;
        }
    }
}
