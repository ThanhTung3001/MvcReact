using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Net.Mime;
using Domain.Common;
using Domain.Entities.Media;
using Domain.Entities.Users;
using Domain.Enum;

namespace Domain.Entities.BloodRegister;

public class Register:BaseAuditableEntity
{
    [MaxLength(20)]
    public string Note { get; private set; }
    public Status Status { get; private set; }
    [ForeignKey("BloodGroup")]
    public int BloodId { get; private set; }
    public virtual BloodGroup BloodGroup { get; private set; }
    [MaxLength(450)]
    public string UserId { get; private set; }
    [ForeignKey("UserId")]
    public virtual ApplicationUser User { get; private set; }
    public DateTime TimeSign { get; private set; }
    [ForeignKey("Image")]
    public int QR { get; private set; }
    public virtual Image Image { get; private set; }
    public int HospitalId { get; private set; }
    [ForeignKey("HospitalId")]
    public virtual Hospital Hospital { get; private set; }
    public int Ml { get; private set; }

    public void UpdateRegisterStatus(Status _status)
    {
        Status = _status;
    }
    public Register(string note, Status status, int bloodId, string userId, DateTime timeSign, int qR, int hospitalId, int ml)
    {
        //Add();
        UserId = userId.Trim();
        QR = qR;
        Update(note, status, bloodId,  timeSign, hospitalId,ml);
    }
    public void Update(string note, Status status, int bloodId, DateTime timeSign, int hospitalId,int ml)
    {
        //Update();
        Note = note.Trim();
        Status = status;
        BloodId = bloodId;
        TimeSign = timeSign;
        HospitalId = hospitalId;
        Ml = ml>0?ml:0;
    }
}