using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Practice.Application.DTOs;

namespace Practice.Application.Features.Brand.Queries
{
    public class GetBrandByIdQuery:IRequest<BrandDto?>
    {
        public int Id { get; set; }
        public GetBrandByIdQuery(int id)
        {
            Id=id;
        } 
    }
}
