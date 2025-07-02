using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Practice.Application.DTOs;
using Practice.Application.Features.Category.Queries;
using Practice.Application.Interfaces;

namespace Practice.Application.Handlers.CategoryHandlers
{
    public class GetProductsByCategoryHandler : IRequestHandler<GetProductsByCategory,CategoryDto>
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public GetProductsByCategoryHandler(IProductRepository productRepository,ICategoryRepository categoryRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<CategoryDto> Handle(GetProductsByCategory request, CancellationToken cancellationToken)
        {
            //var products = await _productRepository.GetAllAsync();
            var category = await _categoryRepository.GetProductsByCategory(request.CategoryName);

            // Filter products where any category has the matching name
            //var filtered = categories.FirstOrDefault(c => c.Name.Equals(request.CategoryName, StringComparison.OrdinalIgnoreCase));
            var result = category;
            
            return _mapper.Map<CategoryDto>(category);
        }
    }
}
