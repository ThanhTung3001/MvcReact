using Applications.Common.Command;
using Applications.Common.Interface;
using Applications.Exceptions;
using MediatR;

namespace Applications.Post.Blogs.Commands.UpdateBlogCommand;

public record DeleteBlogCommandRequest (int Id):IRequest<int> {}

public class  DeleteBlogCommandRequestHandler: BaseCreateCommand,IRequestHandler<DeleteBlogCommandRequest,int >
{
    public DeleteBlogCommandRequestHandler(IApplicationDbContext context) : base(context)
    {
    }
    public async Task<int> Handle(DeleteBlogCommandRequest request, CancellationToken cancellationToken)
    {

        var blog = await _context.Blogs.FindAsync(request.Id);
        if (blog == null)
        {
            throw new NotFoundException($"Blog have id = {request.Id} is not found ");
        }

        _context.Blogs.Remove(blog);
        return await _context.SaveChangesAsync(cancellationToken);

    }


}