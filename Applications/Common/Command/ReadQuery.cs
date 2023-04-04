using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Applications.Common.Command
{
    public class ReadQuery<TEntity> : IRequest<TEntity> where TEntity : class
    {
        public Guid Id { get; set; }

        public ReadQuery(Guid id)
        {
            Id = id;
        }
    }
}
