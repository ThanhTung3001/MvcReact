using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net.Mime;
using Domain.Common;
using Domain.Entities.Media;

namespace Domain.Entities.Posts;

public class Blog:BaseAuditableEntity
{
    [MaxLength(50)]
    public string Title { get; private set; }
    [MaxLength(100)]

    public string Description { get; private set; }
    [Column(TypeName = "ntext")]
    [MaxLength]
    public string Content { get; private set; }
    [ForeignKey("Image")]
    public int ImageId { get; private set; }
    public virtual Image? Image { get; private set; }
    public Blog(string title, string description, string content, int imageId)
    {
      //  Add();
        Update(title, description, content, imageId);
    }
    public void Update(string title, string description, string content, int imageId)
    {
     //   Update();
        Title = title.Trim();
        Description = description.Trim();
        Content = content.Trim();
        ImageId = imageId;
    }
}