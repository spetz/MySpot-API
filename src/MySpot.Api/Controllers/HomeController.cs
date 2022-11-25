using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace MySpot.Api.Controllers;

[Route("")]
[ApiController]
public class HomeController : ControllerBase
{
    private readonly IOptions<AppOptions> _appOptions;

    public HomeController(IOptions<AppOptions> appOptions)
    {
        _appOptions = appOptions;
    }

    [HttpGet]
    public ActionResult<string> Get() => throw new InvalidOperationException("oops");
}