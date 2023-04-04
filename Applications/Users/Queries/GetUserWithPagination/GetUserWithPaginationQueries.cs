using Application.Common.Models;
using Applications.Common.Interface;
using Applications.Common.Mappings;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.Entities.Users;
using MediatR;

namespace Applications.Users.Queries.GetUserWithPagination;

public class GetUserWithPaginationQueries:IRequest<PaginatedList<UserQueriesDto>>
{
    public string? Keyword { get; set; }
    
    public int PageSize { get; set; }
    
    public int PageNumber { get; set; }
}

public class
    GetUserWithPaginationQueryHandler :
        IRequestHandler<GetUserWithPaginationQueries,
            PaginatedList<UserQueriesDto>>
{
    private readonly IIdentityService _identityService;

    private readonly IMapper _mapper;

    private readonly IApplicationDbContext _context;
    public GetUserWithPaginationQueryHandler(IIdentityService identityService, IApplicationDbContext context, IMapper mapper)
    {
        _identityService = identityService;
        _context = context;
        _mapper = mapper;
    }
    public Task<PaginatedList<UserQueriesDto>> Handle(GetUserWithPaginationQueries request, CancellationToken cancellationToken)
    {
        return _context.Users.Where(e => 
                (((string.IsNullOrEmpty(request.Keyword )? e.UserName : request.Keyword)!).Contains(e.UserName!)
                 ||
                 (( string.IsNullOrEmpty(request.Keyword)? e.FullName : request.Keyword).Contains(e.FullName!))
                 )
            )
            .OrderBy(e => e.FullName)
            .ProjectTo<UserQueriesDto>(_mapper.ConfigurationProvider)
            .PaginatedListAsync(request.PageNumber, request.PageSize);
    }
}