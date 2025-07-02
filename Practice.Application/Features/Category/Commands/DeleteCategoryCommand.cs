using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Practice.Application.Features.Category.Commands
{
    public class DeleteCategoryCommand:IRequest<Unit>
    {
        public int Id { get; set; }
        public DeleteCategoryCommand(int id) => Id = id;
    }
}
