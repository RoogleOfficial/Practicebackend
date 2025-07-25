﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Practice.Application.DTOs;

namespace Practice.Application.Features.Brand.Commands
{
    public class UpdateBrandCommand:IRequest<Unit>
    {
        public int Id { get; set; }
        public CUBrandDto BrandDto { get; set; }
        public UpdateBrandCommand(int id, CUBrandDto brandDto)
        {
            Id = id;
            BrandDto = brandDto;
        }
    }
}
