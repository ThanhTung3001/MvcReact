using Applications.Common.Mappings;
using Domain.Entities.Users;

namespace Applications.Users.Queries.GetUserWithPagination;

public class UserQueriesDto:IMapFrom<ApplicationUser>
{
    public string FullName { get; set; }
    
    public DateTime BirthDate { get; set; }
    
    public string Address { get; set; }
    
    public string Avatar { get; set; }
    
    public HospitalDto hospital { get; set; }
    
    public string ICCID { get; set; }
    
    public string PhoneNumber { get; set; }
}

public class HospitalDto : IMapFrom<Hospital>
{
   
    public string Name { get; private set; }
    
    public string Address { get; private set; }
   
    public string Lat { get; private set; }
   
    public string Long { get; private set; }
} 