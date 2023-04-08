using Applications.Common.Interface;
using Applications.Common.Models;
using Domain.Entities.BloodRegister;
using Domain.Enum;
using MediatR;

namespace Applications.Registers.Commands.CreateRegisters;

public class CreateRegisterCommand:IRequest<Result>
{
   
        public string Note { get;  set; }
        
        public Status Status { get; set; }

        public int BloodId { get;  set; }

        public string UserId { get;  set; }

        public DateTime TimeSign { get;  set; }
      
        public int QR { get;  set; }

        public int HospitalId { get;  set; }
        
        public int Ml { get;  set; }
}

public class CreateRegisterCommandRequestHandler : IRequestHandler<CreateRegisterCommand, Result>
{

    private readonly IApplicationDbContext _context;

    public CreateRegisterCommandRequestHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Result> Handle(CreateRegisterCommand request, CancellationToken cancellationToken)
    {
        var hospital = await _context.Hospitals.FindAsync(request.HospitalId,cancellationToken);
        
        if (hospital == null)
        {
            throw new Exception($"Hospital have Id {request.HospitalId} Not found");
        }

        var bloodGroup = await _context.BloodGroups.FindAsync(request.BloodId,cancellationToken);
        if (bloodGroup == null)
        {
            throw new Exception($"bloodGroup have Id {request.BloodId} Not found");
        }

        var user = await _context.Users.FindAsync(request.UserId, cancellationToken);
        if (user == null)
        {
            throw new Exception($"User have Id {request.UserId} Not found");
        }
        var register = new Register(request.Note,
                request.Status, 
                request.BloodId, request.UserId, request.TimeSign,
                request.QR, request.HospitalId,request.Ml);
            //string note, Status status, int bloodId, string userId, DateTime timeSign, int qR, int hospitalId, int ml
            await _context.Registers.AddAsync(register,cancellationToken); 
          //  await _context.SaveChangesAsync(cancellationToken);
            return Result.Success();
 
    }
}