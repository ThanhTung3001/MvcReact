using Applications.Common.Mappings;
using Domain.Entities.Media;
using Domain.Entities.Posts;

namespace Applications.Post.Blogs.Queries.GetBlogWithPagination;

public class BlogDto:IMapFrom<Blog>
{
      public int Id { get; set; }
      public string Title { get;  set; }
      public string Description { get;  set; }
      public string Content { get;  set; }
      public DateTime Created { get; set; }
      public string? CreatedBy { get; set; }
      public ImageDto Image { get; set; }
}

public class ImageDto : IMapFrom<Image>
{
      public int Id { get; set; }
      public string FileName { get; private set; }
      public string ContentType { get; private set; }
      public string Url { get; private set; }
}