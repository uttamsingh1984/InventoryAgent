using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory.Application.AI.Agents
{
    public interface IIntentAgent
    {
        Task<IntentAgentResponse> GetIntentAsync(IntentAgentRequest question);
    }

    public class IntentDetails
    {

    }

    public class IntentAgentResponse
    {
        public string? Intent { get; set; }

        public string? Query { get; set; }
    }

    public class IntentAgentRequest
    {
        public string? Question { get; set; }

    }

}
