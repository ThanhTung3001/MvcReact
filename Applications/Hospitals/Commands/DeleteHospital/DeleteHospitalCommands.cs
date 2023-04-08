using System;
using Applications.Common.Interface;
using MediatR;

namespace Applications.Hospitals.Commands.DeleteHospital
{
	public record DeleteHospitalCommands(int Id) : IRequest<int>;


	public class DeleteHospitalCommandRequestHandler : IRequestHandler<DeleteHospitalCommands, int>
	{
		private readonly IApplicationDbContext _context;

		public DeleteHospitalCommandRequestHandler(IApplicationDbContext context)
		{
			_context = context;
		}

		public Task<int> Handle(DeleteHospitalCommands request, CancellationToken cancellationToken)
		{
			var result = _context.Hospitals.Find(request.Id);
			if (result != null)
			{
				_context.Hospitals.Remove(result);
				
			}
			else
			{
				throw new Exception($" Hospital as Id = {request.Id} not found");
				
			}

			return _context.SaveChangesAsync(cancellationToken);
		}
	}
}

