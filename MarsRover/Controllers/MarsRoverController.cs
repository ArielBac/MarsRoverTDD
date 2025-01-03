using MarsRover.Requests;
using MarsRover.Responses;
using MarsRover.Services;
using Microsoft.AspNetCore.Mvc;

namespace MarsRover.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MarsRoverController : ControllerBase
    {
        [HttpPost("move")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(MarsRoverMoveResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Move(MarsRoverMoveRequest request)
        {
            try
            {
                var result = MarsRoverService.Move(request.StartPosition, request.Command);

                return Ok(new MarsRoverMoveResponse(result));
            }
            catch
            {
                return BadRequest("Process error. Please verify the input format and try again.");
            }
        }
    }
}
