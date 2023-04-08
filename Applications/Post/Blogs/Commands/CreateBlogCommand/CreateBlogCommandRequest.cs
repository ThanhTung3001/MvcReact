using Applications.Common.Command;
using Applications.Common.Interface;
using Applications.Common.Models;
using Domain.Entities.Posts;
using MediatR;

namespace Applications.Post.Blogs.Commands.CreateBlogCommand;

public class CreateBlogCommandRequest:IRequest<Result>
{
    public CreateBlogCommandRequest(string title, string description, string content, int imageId)
    {
        this.title = title;
        this.description = description;
        this.content = content;
        this.imageId = imageId;
    }

    public string title { get; set; }
   public string description { get; set; }
   public string content { get; set; }
   public int imageId { get; set; }
}

public class CreateBlogCommandRequestHandler: BaseCreateCommand,IRequestHandler<CreateBlogCommandRequest,Result>
{
    public CreateBlogCommandRequestHandler(IApplicationDbContext context) : base(context)
    {
    }
    
    public async Task<Result> Handle(CreateBlogCommandRequest request, CancellationToken cancellationToken)
    {
        var blogs = new Blog(request.title,request.description,request.content,request.imageId);
             var response = await _context.Blogs.AddAsync(blogs,cancellationToken);
        return Result.Success();
    }

   
}