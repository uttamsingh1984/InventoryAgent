using Inventory.Application.AI.Agents;
using Inventory.Infrastructure.Models;
using Microsoft.Agents.AI;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace Inventory.Infrastructure.AI.Agents
{
    public class NL2SQLAgent : INL2SQLAgent
    {
        private readonly AIAgent _aiAgent;
        private readonly string _agentType;
        public NL2SQLAgent(IAIAgentFactory aIAgentFactory)
        {
            _agentType = Environment.GetEnvironmentVariable("AI_AGENT_TYPE") ?? "Ollama";
            var instructionFile = Path.Combine(AppContext.BaseDirectory, $"AI\\Prompts\\{AgentNameEnum.NL2SQL.ToString()}.prompty");
            var instructions = File.ReadAllText(instructionFile);
            var dbSchemaFile = Path.Combine(AppContext.BaseDirectory, $"AI\\Prompts\\db_schema.json");
            var db_schema = File.ReadAllText(dbSchemaFile);
            aIAgentFactory.Instructions = instructions + "DB Scheam: \n" + db_schema;
            _aiAgent = aIAgentFactory.CreateAgent(_agentType);
        }
        public async Task<NL2SQLAgentResponse> GetNL2SQLQueryAsync(NL2SQLAgentRequest intentAgentRequest)
        {
            var response = await _aiAgent.RunAsync(intentAgentRequest.Question);
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                AllowTrailingCommas = true,
            };
            return JsonSerializer.Deserialize<NL2SQLAgentResponse>(response.Text, options);
        }
    }
}
