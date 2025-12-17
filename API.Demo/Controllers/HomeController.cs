using API.Demo.Filters;
using API.Demo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace API.Demo.Controllers
{
    [ApiController]
    public class HomeController : ControllerBase
    {
        private List<Player> players = new List<Player>(Seeding.Players());
        public HomeController()
        {
        }

        [HttpGet("Players")]
        [ServiceFilter(typeof(LogActionFilter))]
        public IActionResult GetPlayers()
        {
            return Ok(players);
        }
        [HttpGet("Players/{id}")]
        public ActionResult<Player> GetPlayer(string id)
        {
            try
            {
              var player = players.FirstOrDefault(p => p.Id == id) ??
              throw new ArgumentException(nameof(id), "palyer not found!");
              return Ok(player);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Players")]
        public IActionResult InsertPlayer([FromBody] Player player)
        {
            if (!ModelState.IsValid)
                return BadRequest(new ProblemDetails());
            players.Add(player);
            return CreatedAtAction(nameof(GetPlayer),new {id = player.Id},player);
        }

        [HttpPut("Players/{id}")]
        public IActionResult UpdatePlayer([FromRoute] string id, [FromBody] Player updated)
        {
            try
            {
                var ply = players.FirstOrDefault(p => p.Id == id) ??
                       throw new ArgumentException(nameof(id), "palyer not found!");
                players.Remove(ply);
                players.Add(updated);
                return Ok(updated);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
  
        }
    }
}
