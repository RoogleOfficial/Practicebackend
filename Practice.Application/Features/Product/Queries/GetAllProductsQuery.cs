using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Practice.Application.DTOs;

namespace Practice.Application.Features.Product.Queries
{
    public class GetAllProductsQuery: IRequest<List<ProductDto>>
    {
    }
}
