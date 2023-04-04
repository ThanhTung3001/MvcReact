using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Domain.Entities.BloodRegister;
using Microsoft.AspNetCore.Identity;

namespace Domain.Entities.Users;

public class ApplicationUser:IdentityUser
{
    [MaxLength(50)]
    [Required(ErrorMessage = "FullName is required")]
    public string FullName { get;  set; }
    public DateTime Birthday{ get;  set; }
    [MaxLength(100)]
    public string Address { get;  set; } = "Unknown";
    [JsonIgnore]
    public virtual List<Register> Register { get; private set; }
    public int? HospitalId { get;  set; }
    [ForeignKey("HospitalId")]
    public virtual Hospital? Hospital { get;  set; }
    
    public long ICCID { get; set; }
    
    public string Avatar { get; set; }
    public ApplicationUser()
    {
    }
    public ApplicationUser(string userName, string fullName, string email, DateTime birthday, int? hospitalId, string address)
    {
        Update(userName,fullName, email??"Unknown@abc.com", birthday,hospitalId, address??"Unknown");
        EmailConfirmed = true;
        Register = new List<Register>();
    }
    
    public void Update(string userName,string fullName, string email,DateTime birthday, int? hospitalId, string address)
    {
        FullName = fullName.Trim();
        UserName = userName.Trim();
        Email = email.Trim();
        Birthday = birthday;
        HospitalId = hospitalId ?? 1;
        Address = address.Trim();

    }
}