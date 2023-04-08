using FluentValidation;

namespace Applications.Post.Blogs.Commands.UpdateBlogCommand;

public class UpdateBlogCommandValidator:AbstractValidator<UpdateBlogCommandRequest>
{

    public UpdateBlogCommandValidator()
    {
        RuleFor(e => e.title)
            .MinimumLength(20).WithMessage("Min lenght is 20 ")
            .NotNull().WithMessage("Title not null")
            .NotEmpty().WithMessage("Title Not empty");
        RuleFor(e => e.content)
            .NotEmpty().WithMessage("Content is not empty")
            .MinimumLength(200).WithMessage("Content Min Lenght is 200");
        RuleFor(e => e.content)
            .NotEmpty().WithMessage("Description is not empty")
            .MinimumLength(100).WithMessage("Description Min Lenght is 100");
    }
}