
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
//[Route("/breakfasts")]
public class BreakfastsController : ControllerBase
{

    private readonly IBreakfastService _breakfastService;
    public BreakfastsController(IBreakfastService breakfastService)
    {
        _breakfastService = breakfastService;
    }


    [HttpPost]
    // [HttpPost("/breakfasts")]
    public IActionResult CreateBreakfast(CreateBreakfastRequest inputRequest)
    {
        var breakfast = new Breakfast(
            Guid.NewGuid(),
            inputRequest.Name,
            inputRequest.Description,
            inputRequest.StartDateTime,
            DateTime.UtcNow,
            inputRequest.EndDateTime,
            inputRequest.Savory,
            inputRequest.Sweet
        );

        //Todo: save somewhere
        _breakfastService.CreateBreakfast(breakfast);

        var response = new BreakfastResponse(
            breakfast.Id,
            breakfast.Name,
            breakfast.Description,
            breakfast.StartDateTime,
            breakfast.LastModifiedDateTime,
            breakfast.EndDateTime,
            breakfast.Savory,
            breakfast.Sweet
        );
        return CreatedAtAction(actionName: nameof(GetBreakfast), routeValues: new { id = breakfast.Id }, value: response);
    }
    [HttpGet("{id:guid}")]
    // [HttpGet("/breakfasts/{id:guid}")]
    public IActionResult GetBreakfast(Guid id)
    {
        Breakfast breakfast = _breakfastService.GetBreakfast(id);

        var response = new BreakfastResponse(
            breakfast.Id,
            breakfast.Name,
            breakfast.Description,
            breakfast.StartDateTime,
            breakfast.EndDateTime,
            breakfast.LastModifiedDateTime,
            breakfast.Savory,
            breakfast.Sweet
        );
        return Ok(response);
    }

    [HttpGet]
    public IActionResult GetAllBreakfast(Guid id)
    {
        var response = _breakfastService.GetAllBreakfast();
        return Ok(response);
    }

    // [HttpPut("/breakfasts/{id:guid}")]
    [HttpPut("{id:guid}")]

    public IActionResult UpdateBreakfast(Guid id, UpsertBreakfastRequest inputRequest)
    {
        var request = new Breakfast(
            id,
            inputRequest.Name,
            inputRequest.Description,
            inputRequest.StartDateTime,
            inputRequest.EndDateTime,
            DateTime.UtcNow,
            inputRequest.Savory,
            inputRequest.Sweet
        );
        _breakfastService.UpdateBreakfast(request);

        //Todo:return 201 if a new todo was created
        return NoContent();
    }

    // [HttpDelete("/breakfasts/{id:guid}")]
    [HttpDelete("{id:guid}")]
    public IActionResult DeleteBreakfast(Guid id)
    {
        _breakfastService.DeleteBreakfast(id);
        return NoContent();
    }
}