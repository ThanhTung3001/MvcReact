using Application.Common.Models;
using Applications.Common.Interface;
using Applications.Common.Mappings;
using Applications.Hospitals.Queries.GetHospitalWithPagination;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.Entities.BloodRegister;
using MediatR;

namespace Applications.Registers.Queries.GetRegisterWithPagination;

public class QueriesRegisterWithPagination:IRequest<PaginatedList<RegisterDto>>
{
    public string? Keyword { get; init; } = "";
    
    public int PageNumber { get; init; } = 1;

    public int PageSize { get; init; } = 20;
}

public  class QueriesHospitalWithPaginationRequestHandler:IRequestHandler<QueriesRegisterWithPagination,PaginatedList<RegisterDto>>
{
    
    private readonly IMapper _mapper;

    private readonly IApplicationDbContext _context;

    public QueriesHospitalWithPaginationRequestHandler(IApplicationDbContext context, IMapper mapper)
    {
        //	_identityService = identityService;
        _context = context;
        _mapper = mapper;
    }
    public Task<PaginatedList<RegisterDto>> Handle(QueriesRegisterWithPagination request, CancellationToken cancellationToken)
    {
        return _context.Registers
        				.OrderBy(e => e.Created)
        				.ProjectTo<RegisterDto>(_mapper.ConfigurationProvider)
        				.PaginatedListAsync(request.PageNumber, request.PageSize);
    }
}