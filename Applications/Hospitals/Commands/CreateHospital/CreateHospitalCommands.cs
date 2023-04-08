using System;
using System.ComponentModel.DataAnnotations;
using Applications.Common.Interface;
using Applications.Common.Models;
using Domain.Entities.Users;
using MediatR;

namespace Applications.Hospitals.Commands.CreateHospital
{
	public class CreateHospitalCommands:IRequest<Result>
    {
		
        public string Name { get;  set; }
   
        public string Address { get;  set; }
     
        public string Lat { get;  set; }
       
        public string Long { get;  set; }
    }

	public class CreateHospitalRequestHandlers : IRequestHandler<CreateHospitalCommands, Result>
	{
		private readonly IApplicationDbContext _context;

		public CreateHospitalRequestHandlers(IApplicationDbContext context)
		{
			_context = context;
		}

		public async Task<Result> Handle(CreateHospitalCommands request, CancellationToken cancellationToken)
		{
			var result = await _context.Hospitals.AddAsync(
				new Hospital(request.Name,request.Address,request.Lat,request.Long
				));
			
			var rs=_context.SaveChangesAsync(cancellationToken);
			 return Result.Success();
		}
	}
}

