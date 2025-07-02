using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Practice.Application.DTOs;

namespace Practice.Application.Features.Product.Commands
{
    public class CreateProductCommand:IRequest<int>
    {
        public ProductDto ProductDto { get; set; }
        public CreateProductCommand(ProductDto dto) => ProductDto = dto;
    }
}
