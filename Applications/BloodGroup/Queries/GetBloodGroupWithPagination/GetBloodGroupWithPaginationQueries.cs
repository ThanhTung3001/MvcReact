using Application.Common.Models;
using Applications.Common.Interface;
using Applications.Common.Mappings;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;

namespace Applications.BloodGroup.Queries.GetBloodGroupWithPagination;

public class GetBloodGroupWithPaginationQueries:IRequest<PaginatedList<BloodGroupDto>>
{
    public string ? Keyword { get; set; }

    public int PageNumber { get; init; } = 1;

    public int PageSize { get; init; } = 20;
}

public class GetBloodGroupWithPaginationQueriesHandle :
    IRequestHandler<GetBloodGroupWithPaginationQueries, PaginatedList<BloodGroupDto>>
{
    private readonly IApplicationDbContext _context;

    private readonly IMapper _mapper;

    public GetBloodGroupWithPaginationQueriesHandle(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<PaginatedList<BloodGroupDto>> Handle(GetBloodGroupWithPaginationQueries request, CancellationToken cancellationToken)
    {
        return await _context.BloodGroups.Where(e=>e.Name.Contains(string.IsNullOrEmpty(request.Keyword)
                ?e.Name:request.Keyword))
                .OrderBy(e=>e.Created)
                .ProjectTo<BloodGroupDto>(_mapper.ConfigurationProvider)
                .PaginatedListAsync(request.PageNumber,request.PageSize);
    }
}