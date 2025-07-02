using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.Application.DTOs
{
    public class CUCategoryDto
    {
        public required string Name { get; set; }

        public string? Description { get; set; }
    }
}
