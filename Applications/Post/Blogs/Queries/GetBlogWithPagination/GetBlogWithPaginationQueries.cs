using Application.Common.Models;
using Applications.Common.Command;
using Applications.Common.Interface;
using Applications.Common.Mappings;
using Applications.Common.Models;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;

namespace Applications.Post.Blogs.Queries.GetBlogWithPagination;

public class GetBlogWithPaginationQueries:IRequest<PaginatedList<BlogDto>>
{
    public string? Keyword { get; init; } = "";
    
    public int PageNumber { get; init; } = 1;

    public int PageSize { get; init; } = 20;
}

public  class GetBlogWithPaginationQueriesHandler:BaseQueriesHandler,IRequestHandler<GetBlogWithPaginationQueries,PaginatedList<BlogDto>>
{
    public GetBlogWithPaginationQueriesHandler(IApplicationDbContext context, IMapper mapper) : base(context, mapper)
    {
    }

    public Task<PaginatedList<BlogDto>> Handle(GetBlogWithPaginationQueries request, CancellationToken cancellationToken)
    {
        return _context.Blogs
            .OrderBy(e => e.Created)
            .ProjectTo<BlogDto>(_mapper.ConfigurationProvider)
            .PaginatedListAsync(request.PageNumber, request.PageSize);
    }


}