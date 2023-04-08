using Applications.Common.Command;
using Applications.Common.Interface;
using Applications.Common.Models;
using Applications.Exceptions;
using MediatR;

namespace Applications.Post.Blogs.Commands.UpdateBlogCommand;

public class UpdateBlogCommandRequest:IRequest<Result>
{
    public  int Id { get; set; }
    public string title { get; set; }
    public string description { get; set; }
    public string content { get; set; }
    public int imageId { get; set; }
}

public class UpdateBlogCommandRequestHandler:BaseCreateCommand,IRequestHandler<UpdateBlogCommandRequest,Result>
{
    public UpdateBlogCommandRequestHandler(IApplicationDbContext context) : base(context)
    {
    }
    public async Task<Result> Handle(UpdateBlogCommandRequest request, CancellationToken cancellationToken)
    {
        var blog = await _context.Blogs.FindAsync(request.Id);
        if (blog == null)
        {
            throw new NotFoundException($"Blog have id = {request.Id} not found");
        }
        blog.Update(request.title,request.description,request.content,request.imageId);
            await _context.SaveChangesAsync(cancellationToken);
        return Result.Success();
    }

    
}
