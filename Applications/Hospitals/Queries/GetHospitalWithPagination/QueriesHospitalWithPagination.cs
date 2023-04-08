using System;
using Application.Common.Models;
using Applications.Common.Interface;
using Applications.Common.Mappings;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;

namespace Applications.Hospitals.Queries.GetHospitalWithPagination
{
	public class QueriesHospitalWithPagination : IRequest<PaginatedList<HospitalDto>>
	{
		public string? Keyword { get; init; } = "";
    
		public int PageNumber { get; init; } = 1;

		public int PageSize { get; init; } = 20;
	}

	public class
		GetHospitalWithPagination :
			IRequestHandler<QueriesHospitalWithPagination,
				PaginatedList<HospitalDto>>
	{


		private readonly IMapper _mapper;

		private readonly IApplicationDbContext _context;

		public GetHospitalWithPagination(IApplicationDbContext context, IMapper mapper)
		{
			//	_identityService = identityService;
			_context = context;
			_mapper = mapper;
		}

		public Task<PaginatedList<HospitalDto>> Handle(QueriesHospitalWithPagination request,
			CancellationToken cancellationToken)
		{
			return _context.Hospitals
				.OrderBy(e => e.Name)
				.ProjectTo<HospitalDto>(_mapper.ConfigurationProvider)
				.PaginatedListAsync(request.PageNumber, request.PageSize);
		}
	}
}

