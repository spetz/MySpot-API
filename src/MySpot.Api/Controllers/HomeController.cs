using Microsoft.AspNetCore.Mvc;

namespace MySpot.Api.Controllers;

[Route("")]
[ApiController]
public class HomeController : ControllerBase
{
    [HttpGet]
    public ActionResult<string> Get()
    {
        return Ok("Hello");
    }
    
    [HttpGet("hello")]
    public ActionResult<string> GetByName([FromQuery] Dummy dummy)
    {
        return Ok($"Hello: {dummy.Name}");
    }

    [HttpPost("dummy")]
    public ActionResult Post(Dummy dummy)
    {
        return NoContent();
    }

    [HttpPut("dummy/{id:int}")]
    public ActionResult Put(int id, Dummy dummy)
    {
        dummy.Id = id;
        return NoContent();
    }
    
    public class Dummy
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}