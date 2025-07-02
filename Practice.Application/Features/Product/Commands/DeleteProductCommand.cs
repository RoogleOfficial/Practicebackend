using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Practice.Application.Features.Product.Commands
{
    public class DeleteProductCommand:IRequest<Unit>
    {
        public int Id { get; set; }
        public DeleteProductCommand(int id) => Id = id;
    }
}
