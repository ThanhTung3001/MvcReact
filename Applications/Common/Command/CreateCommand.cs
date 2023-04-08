using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Applications.Common.Interface;

namespace Applications.Common.Command
{
    public class CreateCommand<TEntity> : IRequest<TEntity> where TEntity : class
    {
        public TEntity Entity { get; set; }

        public CreateCommand(TEntity entity)
        {
            Entity = entity ?? throw new ArgumentNullException(nameof(entity));
        }
    }

    public class BaseCreateCommand
    {
        public readonly IApplicationDbContext _context;

        public BaseCreateCommand(IApplicationDbContext context)
        {
            _context = context;
        }
    }
}
