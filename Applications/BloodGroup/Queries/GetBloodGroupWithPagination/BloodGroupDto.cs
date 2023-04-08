using Applications.Common.Mappings;

namespace Applications.BloodGroup.Queries.GetBloodGroupWithPagination;

public class BloodGroupDto:IMapFrom<Domain.Entities.BloodRegister.BloodGroup>
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Summary { get; set; }
    public DateTime Created { get; set; }
}