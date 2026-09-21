
using Inventory.Application.AI.Agents;
using Microsoft.AspNetCore.Mvc;

namespace Inventory.Api.Controllers;

[ApiController]
[Route("api/support")]
public class CustomerSupportController : ControllerBase
{
    private readonly ICustomerSupportAgent _customerSupportAgent;
    public CustomerSupportController(ICustomerSupportAgent customerSupportAgent)
    {
        _customerSupportAgent = customerSupportAgent;
    }

    [Route("ask")]
    [HttpPost]
    public async Task<IActionResult> AskQuestion([FromBody]string question)
    {
        var response = await _customerSupportAgent.AskAsync(question);
        return Ok(response);
    }
}