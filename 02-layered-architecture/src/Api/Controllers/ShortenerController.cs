using Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("[controller]")]
public sealed class ShortenerController : ControllerBase
{
    private readonly ShorteningService _service;

    public ShortenerController(ShorteningService service) => _service = service;

    [HttpPost("shorten")]
    public IActionResult Shorten([FromBody] ShortenRequest request)
    {
        try
        {
            var result = _service.Shorten(request.Url);
            return Ok(new ShortenResponse(result.Code, result.OriginalUrl));
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("{code}")]
    public IActionResult Resolve(string code)
    {
        var url = _service.Resolve(code);
        return url is null ? NotFound() : Redirect(url);
    }
}

public sealed record ShortenRequest(string Url);

public sealed record ShortenResponse(string Code, string Url);
