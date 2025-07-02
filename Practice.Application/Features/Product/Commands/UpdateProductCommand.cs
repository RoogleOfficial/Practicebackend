using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Practice.Application.DTOs;

namespace Practice.Application.Features.Product.Commands
{
    public class UpdateProductCommand:IRequest<Unit>
    {
        public int Id { get; set; }
        public ProductDto ProductDto { get; set; }
        public UpdateProductCommand(int id, ProductDto dto)
        {
            Id = id;
            ProductDto = dto;
        }
    }
}
