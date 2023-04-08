using Application.Common.Models;
using Applications.Common.Models;
using Applications.Hospitals.Commands.CreateHospital;
using Applications.Hospitals.Commands.DeleteHospital;
using Applications.Hospitals.Commands.UpdateHospital;
using Applications.Hospitals.Queries.GetHospitalWithPagination;
using Microsoft.AspNetCore.Mvc;

namespace WebUi.Controllers;

public class HospitalController:ApiControllerBase
{
    [HttpGet]
    public async Task<ActionResult<ResponseEntity<PaginatedList<HospitalDto>>>> GetAll([FromQuery]QueriesHospitalWithPagination queries)
    {
        try
        {
            var result = await Mediator.Send(queries);
            return new ResponseEntity<PaginatedList<HospitalDto>>(result)
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
    public async Task<ActionResult<int>> Create([FromBody]CreateHospitalCommands command)
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
    public async Task<ActionResult<int>> Update([FromBody]UpdateHospitalCommands command,int id)
    {
        try
        {
            //  Console.WriteLine(id);
            //command.Id = id;
            command.Id = id;
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
            await Mediator.Send(new DeleteHospitalCommands(id));
            return Ok(new ResponseEntity<object>{
                message=$"Delete Hospital have id = {id} success",
                code = 200
            });
        }
        catch (System.Exception ex)
        {
            return BadRequest(new ResponseEntity<object>{
                message=$"Delete Hospital have id ={id} Faild reason:{ex.Message} ",
                code = 400
            });
            throw;
        }

    }

}