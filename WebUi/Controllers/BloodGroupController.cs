using Application.Common.Models;
using Applications.BloodGroup.Commands.CreateBloodGroup;
using Applications.BloodGroup.Commands.DeleteBloodGroup;
using Applications.BloodGroup.Commands.UpdateBloodGroup;
using Applications.BloodGroup.Queries.GetBloodGroupWithPagination;
using Applications.Common.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebUi.Controllers;

public class BloodGroupController : ApiControllerBase
{
    [HttpGet]
    public async Task<ActionResult<ResponseEntity<PaginatedList<BloodGroupDto>>>> GetAll(
        [FromQuery] GetBloodGroupWithPaginationQueries queries)
    {
        try
        {
            var result = await Mediator.Send(queries);
            return new ResponseEntity<PaginatedList<BloodGroupDto>>(result)
            {
                message = "Get data success"
            };
        }
        catch (Exception e)
        {
            return BadRequest(new
            {
                message = e.Message
            });
        }
    }

    [HttpPost]
    public async Task<ActionResult<int>> Create([FromBody] CreateBloodGroupCommand command)
    {
        try
        {
            await Mediator.Send(command);
            return Ok(new ResponseEntity<object>
            {
                message = "Create Item success"
            });
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

    [HttpPut("{id}")]
    public async Task<ActionResult<int>> Update([FromBody]UpdateBloodGroupCommand command,int id)
    {
        try
        {
          //  Console.WriteLine(id);
            //command.Id = id;
            await Mediator.Send(command);
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
    
    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id){

        try
        {
             await Mediator.Send(new DeleteBloodGroupCommand(id));
             return Ok(new ResponseEntity<object>{
                message=$"Delete Blood Group have id = {id} success",
                code = 200
             });
        }
        catch (System.Exception ex)
        {
            return BadRequest(new ResponseEntity<object>{
                message=$"Delete Blood Group have id ={id} Faild reason:{ex.Message} ",
                code = 400
             });
            throw;
        }

    }

}