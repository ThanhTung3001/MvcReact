using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Applications.Common.Command
{
    public class DeleteCommand : IRequest<bool>
    {
        public int Id { get; set; }

        public DeleteCommand(int id)
        {
            Id = id;
        }
    }
}
