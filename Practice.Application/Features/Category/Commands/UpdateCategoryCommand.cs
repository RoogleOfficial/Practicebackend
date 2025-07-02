using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Practice.Application.DTOs;

namespace Practice.Application.Features.Category.Commands
{
    public class UpdateCategoryCommand:IRequest<Unit>
    {
        public int Id { get; set; }
        public CUCategoryDto CategoryDto { get; set; }
        public UpdateCategoryCommand(int id, CUCategoryDto dto)
        {
            Id = id;
            CategoryDto = dto;
        }
    }
}
