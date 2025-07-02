using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Practice.Application.DTOs;

namespace Practice.Application.Features.Category.Queries
{
    public class GetProductsByCategory(string categoryName) : IRequest<CategoryDto>
    {

        public string CategoryName { get; set; }=categoryName;
    }
}
