using Application.Common.Models;
using Applications.Common.Models;
using Applications.Hospitals.Queries.GetHospitalWithPagination;
using Applications.Registers.Commands.CreateRegisters;
using Applications.Registers.Commands.UpdateRegister;
using Applications.Registers.Queries.GetRegisterWithPagination;
using Microsoft.AspNetCore.Mvc;

namespace WebUi.Controllers;

public class RegisterController:ApiControllerBase
{
    [HttpPost]
    public async Task<ActionResult<ResponseEntity<Result>>> Create([FromBody] CreateRegisterCommand command,CancellationToken cancellationToken)
    {
        try
        {
            var result = await Mediator.Send(command,cancellationToken);
            return new ResponseEntity<Result>(result)
            {
                message = "Register Success"
            };
        }
        catch (Exception e)
        {
         
            return BadRequest(
                new ResponseEntity<object>
                {
                    message = $"Create Item fail have error: {e.Message}"
                });

        }
    }

    [HttpPut("{Id}")]
    public async Task<ActionResult<ResponseEntity<Result>>> Update(
        [FromBody] UpdateRegisterCommand command,
        CancellationToken cancellationToken, int id)
    {
        try
        {
            command.Id = id;
            var result = await Mediator.Send(command, cancellationToken);
            return Ok(new ResponseEntity<object>
            {
                message = "Update success",
                code = 200
            });
        }
        catch (Exception e)
        {
            return BadRequest(new ResponseEntity<object>
            {
                message = e.Message,
                code = 400
            });
        }
       
    }

    [HttpPatch("{Id}")]
    public async Task<ActionResult<ResponseEntity<Result>>> UpdateStatus(
        [FromBody] UpdateStatusRegisterCommand command,
        CancellationToken cancellationToken, int id)
    {
        try
        {
            command.Id = id;
            var result = await Mediator.Send(command,cancellationToken);
            return Ok(new ResponseEntity<object>
            {
                message = "Update success",
                code = 200
            });
        }
        catch (Exception e)
        {
            return BadRequest(new ResponseEntity<object>
            {
                message = e.Message,
                code = 400
            });
        }
    }

    [HttpGet]
    public async Task<ActionResult<ResponseEntity<PaginatedList<RegisterDto>>>> GetAll([FromQuery]QueriesRegisterWithPagination queries, CancellationToken cancellationToken)
    {
        try
        {
            var result = await Mediator.Send(queries,cancellationToken);

            return ResponseEntity<PaginatedList<RegisterDto>>.Success(message:"Get data success",code:200,data:result);
        }
        catch (Exception e)
        {
            return BadRequest(ResponseEntity<object>.Error($"Get data Fail: {e.ToString()}", null, 400));
        }
    }
}