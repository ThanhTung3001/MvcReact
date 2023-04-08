using System;
using Applications.Common.Interface;
using MediatR;

namespace Applications.Hospitals.Commands.UpdateHospital
{
	public class UpdateHospitalCommands:IRequest<int>
	{
		public int Id { get; set; }
		public string Name { get;  set; }
   
		public string Address { get;  set; }
     
		public string Lat { get;  set; }
       
		public string Long { get;  set; }
	}
	public class UpdateHospitalCommandRequestHandle:IRequestHandler<UpdateHospitalCommands,int>
	{
		private readonly IApplicationDbContext _context;

		public UpdateHospitalCommandRequestHandle(IApplicationDbContext context)
		{
			_context = context;
		}

		public Task<int> Handle(UpdateHospitalCommands request, CancellationToken cancellationToken)
		{ 
			var result = _context.Hospitals.Find(request.Id);
			if (result != null)
			{
				result.Update(request.Name, result.Address, request.Lat, request.Long);
				_context.Hospitals.Update(result);
				
			}
			else
			{
				throw new Exception($" Hospital as Id = {request.Id} not found");
				
			}
			return _context.SaveChangesAsync(cancellationToken);
		}
	}
}

