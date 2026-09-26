
using Inventory.Application.AI.Agents;
using Microsoft.AspNetCore.Mvc;

namespace Inventory.Api.Controllers;

[ApiController]
[Route("api/question")]
public class QuestionController : ControllerBase
{
    private readonly IIntentAgent _intentAgent;
    public QuestionController(IIntentAgent intentAgent)
    {
        _intentAgent = intentAgent;
    }

    [Route("post")]
    [HttpPost]
    public async Task<IActionResult> PostQuestion(IntentAgentRequest intentRequest)
    {
        var response = await _intentAgent.GetIntentAsync(intentRequest);
        return Ok(response);
    }
}