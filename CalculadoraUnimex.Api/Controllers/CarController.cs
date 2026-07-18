using Microsoft.AspNetCore.Mvc;

namespace CalculadoraUnimex.Api.Controllers;

[ApiController]
[Route("api/car")]
public sealed class CarController : ControllerBase
{
    private static readonly string[] Cars =
    {
        "https://images.unsplash.com/photo-1494976388531-d1058494cdd8?auto=format&fit=crop&w=900&q=80",
        "https://images.unsplash.com/photo-1503376780353-7e6692767b70?auto=format&fit=crop&w=900&q=80",
        "https://images.unsplash.com/photo-1542362567-b07e54358753?auto=format&fit=crop&w=900&q=80",
        "https://images.unsplash.com/photo-1552519507-da3b142c6e3d?auto=format&fit=crop&w=900&q=80",
        "https://images.unsplash.com/photo-1549924231-f129b911e442?auto=format&fit=crop&w=900&q=80"
    };

    [HttpGet("random")]
    public IActionResult GetRandomCar()
    {
        int index = System.Random.Shared.Next(Cars.Length);
        return Ok(new { imagen = Cars[index] });
    }
}
