using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Applications.Common.Mappings;
using Applications.Users.Queries.GetUserWithPagination;
using Domain.Entities.Users;

namespace Applications.Hospitals.Queries.GetHospitalWithPagination
{
    public class HospitalDto:IMapFrom<Hospital>
    {
     
            public string Name { get;  set; }
        
            public string Address { get;  set; }
        
            public string Lat { get;  set; }
        
            public string Long { get;  set; }
        
            public virtual List<UserQueriesDto> Users { get;  set; }
            

    }
}