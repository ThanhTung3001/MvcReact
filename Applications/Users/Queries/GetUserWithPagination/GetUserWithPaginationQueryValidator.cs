using FluentValidation;

namespace Applications.Users.Queries.GetUserWithPagination;

public class GetUserWithPaginationQueryValidator :AbstractValidator<GetUserWithPaginationQueries>
{
    public GetUserWithPaginationQueryValidator()
    {
      
        RuleFor(x => x.PageNumber)
            .GreaterThanOrEqualTo(1).WithMessage("PageNumber at least greater than or equal to 1.");

        RuleFor(x => x.PageSize)
            .GreaterThanOrEqualTo(1).WithMessage("PageSize at least greater than or equal to 1.");
    }
}