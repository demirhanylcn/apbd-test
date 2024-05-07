using Microsoft.AspNetCore.Mvc;
using test_1.Exceptions;

using test_1.Service;

namespace test_1.Controller;


[Route("api/[controller]")]
[ApiController]
public class TasksController : ControllerBase
{

    public ITaskService _TaskService;

    public TasksController(TaskService taskService)
    {
        _TaskService = taskService;
    }
    [HttpGet]
    public  IActionResult GetDataAboutTeamMemberWithTasks(int idTeamMember)
    {

        try
        {
            var result = _TaskService.GetDataAboutTeamMemberWithTasks(idTeamMember);
            return Ok(result);

        }
        catch (NoTaskException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (NoTeamMemberException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (NullReferenceException ex)
        {
            return BadRequest(ex.Message);
        }
    }
}