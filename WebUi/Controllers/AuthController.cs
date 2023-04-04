using Application.Common.Models;
using Applications.Common.Models;
using Applications.Users.Commands;
using Applications.Users.Commands.CreateUser;
using Applications.Users.Commands.DeleteUser;
using Applications.Users.Commands.UpdateUser;
using Applications.Users.Commands.ValidatorUser;
using Applications.Users.Queries.GetUserWithPagination;
using Microsoft.AspNetCore.Mvc;

namespace WebUi.Controllers;

public class AuthController:ApiControllerBase
{
    [HttpPost("Register")]
    public async Task<ActionResult<UserCreation>> Create([FromBody] CreateUserCommand userCommand,CancellationToken cancellationToken)
    {
        return await Mediator.Send(userCommand,cancellationToken);
    }

    [HttpPost("Login")]
    public async Task<ActionResult<UserCreation>> Login([FromBody] ValidatorUserCommand userCommand,CancellationToken cancellationToken)
    {
        try
        {
            return await Mediator.Send(userCommand,cancellationToken);
        }
        catch (Exception e)
        {
            return NotFound(new
            {
                message=e.Message,
                code = 404
            });
        }
    }

    [HttpGet]
    public async Task<ActionResult<ResponseEntity<PaginatedList<UserQueriesDto>>>> Get(
        [FromQuery] GetUserWithPaginationQueries queries,CancellationToken cancellationToken)
    {
        var result = await Mediator.Send(queries,cancellationToken);
        return new ResponseEntity<PaginatedList<UserQueriesDto>>()
        {
            message = "Get Data success",
            data = result,
            code = 200
        };
    }

    [HttpDelete("Delete")]
    public async Task<ActionResult<ResponseEntity<Result>>> Delete([FromQuery] DeleteUserCommand userCommand,CancellationToken cancellationToken)
    {
        
        try
        {
            var result = await Mediator.Send(userCommand,cancellationToken);
            return new ResponseEntity<Result>(result);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    [HttpPut("Update")]
    public async Task<ActionResult<ResponseEntity<UpdateUserCommand>>> Update([FromBody] UpdateUserCommand userCommand,CancellationToken cancellationToken)
    {
        try
        {
            var result = await Mediator.Send(userCommand,cancellationToken);
            return new ResponseEntity<UpdateUserCommand>()
            {
                    message = "Update user success",
                    code = 200,
                    data = result,
            };
        }
        catch (Exception e)
        {
            return NotFound(new
            {
                message=e.Message,
                code = 404
            });
        }
    }

}