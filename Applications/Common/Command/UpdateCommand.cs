using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Applications.Common.Command
{
    public class UpdateCommand<TEntity> : IRequest<TEntity> where TEntity : class
    {
        public int Id { get; set; }
        public TEntity Entity { get; set; }

        public UpdateCommand(int id, TEntity entity)
        {
            Id = id;
            Entity = entity ?? throw new ArgumentNullException(nameof(entity));
        }
    }
}
