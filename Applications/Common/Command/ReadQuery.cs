using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Applications.Common.Interface;
using AutoMapper;

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

    public class BaseQueriesHandler
    {
        public IApplicationDbContext _context;

        public IMapper _mapper;

        public BaseQueriesHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
    }
}
