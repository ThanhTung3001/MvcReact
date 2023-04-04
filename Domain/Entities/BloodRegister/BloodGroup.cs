using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Domain.Common;

namespace Domain.Entities.BloodRegister;

public class BloodGroup:BaseAuditableEntity
{
    [MaxLength(50)]
    public string Name { get;  set; }
    [MaxLength(100)]
    public string Description { get;  set; }
    
    public string Summary { get; set; }
    [JsonIgnore]
    public List<Register> Register { get; set; }

    public BloodGroup(string name, string description,string summary)
    {
        //Add();
        Update(name,description,summary);
        Register = new List<Register>();
    }
    public void Update(string name, string description,string summary)
    {
       // Update();
        Name = name.Trim();
        Description = description.Trim();
        Summary = summary.Trim();
    }
}