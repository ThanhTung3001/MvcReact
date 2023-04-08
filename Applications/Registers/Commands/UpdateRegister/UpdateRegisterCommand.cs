using Applications.Common.Interface;
using Applications.Common.Models;
using Domain.Entities.BloodRegister;
using Domain.Enum;
using MediatR;

namespace Applications.Registers.Commands.UpdateRegister;

public class UpdateRegisterCommand:IRequest<Result>
{
    public  int Id { get; set; }
    public string Note { get;  set; }
        
    public Status Status { get; set; }

    public int BloodId { get;  set; }



    public DateTime TimeSign { get;  set; }
      
    public int QR { get;  set; }

    public int HospitalId { get;  set; }
        
    public int Ml { get;  set; }
    
}

public  class  UpdateRegisterCommandRequestHandler:IRequestHandler<UpdateRegisterCommand,Result>
{
    private readonly IApplicationDbContext _context;

    public UpdateRegisterCommandRequestHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Result> Handle(UpdateRegisterCommand request, CancellationToken cancellationToken)
    {
        var register = await _context.Registers.FindAsync(request.Id, cancellationToken);
        if (register == null)
        {
            throw new Exception($"Register as id = {request.Id} not found");
        }
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

            //string note, Status status, int bloodId, DateTime timeSign, int hospitalId,int ml
        register.Update(request.Note,register.Status,register.BloodId,request.TimeSign,register.HospitalId,request.Ml);
     
         //_context.Registers.Update(register); 
          await _context.SaveChangesAsync(cancellationToken);
        return Result.Success();
         
    }
}