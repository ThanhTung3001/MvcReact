using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net.Mime;
using Domain.Common;
using Domain.Entities.Media;
using Domain.Enum;

namespace Domain.Entities.Posts;

public class Event:BaseAuditableEntity
{
    [MaxLength(50)]
    public string EventName { get; private set; }
    [MaxLength(100)]
    public string Description { get; private set; }
    [Column(TypeName = "ntext")]
    [MaxLength]
    public string Content { get; private set; }
    public DateTime StartTime { get; private set; }
    public DateTime EndTime { get; private set; }
    public EventStatus Status { get; private set; }
    [ForeignKey("Image")]
    public int ImageId { get; private set; }
    public virtual Image Image { get; private set; }
    public Event(string eventName, string description, string content, DateTime startTime, DateTime endTime, EventStatus status, int imageId)
    {
       // Add();
        Update(eventName,description,content,startTime,endTime,status, imageId);
    }
    public void Update(string eventName, string description, string content, DateTime startTime, DateTime endTime, EventStatus status, int imageId)
    {
       // Update();
        EventName = eventName.Trim();
        Description = description.Trim();
        Content = content.Trim();
        StartTime = startTime;
        EndTime = endTime;
        Status = status;
        ImageId = imageId;
    }
}