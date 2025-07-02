using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Practice.Application.DTOs;

namespace Practice.Application.Features.Brand.Commands
{
    public class CreateBrandCommand:IRequest<int>
    {
        public CUBrandDto BrandDto { get; set; }
        public CreateBrandCommand(CUBrandDto brandDto)
        {
            BrandDto = brandDto;
        } 
    }
}
