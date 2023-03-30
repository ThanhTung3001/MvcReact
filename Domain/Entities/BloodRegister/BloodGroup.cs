using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Domain.Common;

namespace Domain.Entities.BloodRegister;

public class BloodGroup:BaseAuditableEntity
{
    [MaxLength(50)]
    public string Name { get; private set; }
    [MaxLength(100)]
    public string Description { get; private set; }
    [JsonIgnore]
    public List<Register> Register { get; set; }

    public BloodGroup(string name, string description)
    {
        //Add();
        Update(name,description);
        Register = new List<Register>();
    }
    public void Update(string name, string description)
    {
       // Update();
        Name = name.Trim();
        Description = description.Trim();
    }
}