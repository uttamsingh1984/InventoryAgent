
using Inventory.Application.AI.Agents;
using Microsoft.AspNetCore.Mvc;

namespace Inventory.Api.Controllers;

[ApiController]
[Route("api/nl2sql")]
public class NL2SQLController : ControllerBase
{
    private readonly INL2SQLAgent _nL2SQLAgent;
    public NL2SQLController(INL2SQLAgent nL2SQLAgent)
    {
        _nL2SQLAgent = nL2SQLAgent;
    }

    [Route("postquestion")]
    [HttpPost]
    public async Task<IActionResult> PostQuestion(NL2SQLAgentRequest nl2sqlRequest)
    {
        var response = await _nL2SQLAgent.GetNL2SQLQueryAsync(nl2sqlRequest);
        return Ok(response);
    }
}