using Application.Common.Models;
using Applications.Common.Models;
using Applications.Post.Blogs.Commands.CreateBlogCommand;
using Applications.Post.Blogs.Commands.UpdateBlogCommand;
using Applications.Post.Blogs.Queries.GetBlogWithPagination;
using Microsoft.AspNetCore.Mvc;

namespace WebUi.Controllers;

public class BlogController:ApiControllerBase
{
      [HttpGet]
    public async Task<ActionResult<ResponseEntity<PaginatedList<BlogDto>>>> GetAll([FromQuery]GetBlogWithPaginationQueries queries)
    {
        try
        {
            var result = await Mediator.Send(queries);
            return new ResponseEntity<PaginatedList<BlogDto>>(result)
            {
                message = "Get Blog success"
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
    public async Task<ActionResult<int>> Create([FromBody]CreateBlogCommandRequest command)
    {
        try
        {
            await Mediator.Send(command);
            return Ok(new ResponseEntity<object>
            {
                message = "Create Blog success"
            });
        }
        catch (Exception e)
        {
            return BadRequest(
                new ResponseEntity<object>
                {
                    message = $"Create Blog fail have error: {e.Message}"
                });
        }
    }
    [HttpPut("{id}")]
    public async Task<ActionResult<int>> Update([FromBody]UpdateBlogCommandRequest command,int id)
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
            await Mediator.Send(new DeleteBlogCommandRequest(id));
            return Ok(new ResponseEntity<object>{
                message=$"Delete Blog have id = {id} success",
                code = 200
            });
        }
        catch (System.Exception ex)
        {
            return BadRequest(new ResponseEntity<object>{
                message=$"Delete Blog have id ={id} Faild reason:{ex.Message} ",
                code = 400
            });
            throw;
        }

    }
    
}