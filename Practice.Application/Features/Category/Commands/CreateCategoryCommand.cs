using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Practice.Application.DTOs;

namespace Practice.Application.Features.Category.Commands
{
    public class CreateCategoryCommand:IRequest<int>
    {
        public CUCategoryDto CategoryDto { get; set; }
        public CreateCategoryCommand(CUCategoryDto dto) { CategoryDto = dto; }
    }
}
