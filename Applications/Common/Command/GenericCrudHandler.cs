using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Applications.Common.Command
{
    public class GenericCrudHandler<TEntity> :
           IRequestHandler<CreateCommand<TEntity>, TEntity>,
           IRequestHandler<ReadQuery<TEntity>, TEntity>,
           IRequestHandler<UpdateCommand<TEntity>, TEntity>,
           IRequestHandler<DeleteCommand, bool>
           where TEntity : class
    {
        private readonly DbContext _dbContext;

        public GenericCrudHandler(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<TEntity> Handle(CreateCommand<TEntity> request, CancellationToken cancellationToken)
        {
            _dbContext.Set<TEntity>().Add(request.Entity);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return request.Entity;
        }

        public async Task<TEntity> Handle(ReadQuery<TEntity> request, CancellationToken cancellationToken)
        {
            return await _dbContext.Set<TEntity>().FindAsync(new object[] { request.Id }, cancellationToken);
        }

        public async Task<TEntity> Handle(UpdateCommand<TEntity> request, CancellationToken cancellationToken)
        {
            _dbContext.Set<TEntity>().Update(request.Entity);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return request.Entity;
        }

        public async Task<bool> Handle(DeleteCommand request, CancellationToken cancellationToken)
        {
            TEntity entity = await _dbContext.Set<TEntity>().FindAsync(new object[] { request.Id }, cancellationToken);
            if (entity == null) return false;
            _dbContext.Set<TEntity>().Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}
