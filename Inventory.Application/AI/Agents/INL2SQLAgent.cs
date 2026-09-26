using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory.Application.AI.Agents
{
    public interface INL2SQLAgent
    {
        Task<NL2SQLAgentResponse> GetNL2SQLQueryAsync(NL2SQLAgentRequest request);
    }

    public class NL2SQLAgentResponse
    {
        public string? SQLQuery { get; set; }

        public string? Query { get; set; }
    }

    public class NL2SQLAgentRequest
    {
        public string? Question { get; set; }

    }

}
