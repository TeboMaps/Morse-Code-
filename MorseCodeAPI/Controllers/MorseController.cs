using System;

using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class MorseController : ControllerBase
{
    private readonly MorseTranslatorService _translator = new();

    [HttpPost("encode")]
    public IActionResult Encode([FromBody] MorseRequest request)
    {
        if (string.IsNullOrWhiteSpace(request.Message))
            return BadRequest("Message cannot be empty.");

        return Ok(_translator.Encode(request.Message));
    }

    [HttpPost("decode")]
    public IActionResult Decode([FromBody] MorseRequest request)
    {
        if (string.IsNullOrWhiteSpace(request.Message))
            return BadRequest("Message cannot be empty.");

        return Ok(_translator.Decode(request.Message));
    }
}

