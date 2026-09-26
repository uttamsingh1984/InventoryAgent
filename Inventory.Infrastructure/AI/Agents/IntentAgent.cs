using Inventory.Application.AI.Agents;
using Inventory.Infrastructure.Models;
using Microsoft.Agents.AI;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace Inventory.Infrastructure.AI.Agents
{
    public class IntentAgent : IIntentAgent
    {
        private readonly AIAgent _aiAgent;
        private readonly string _agentType;
        public IntentAgent(IAIAgentFactory aIAgentFactory)
        {
            _agentType = Environment.GetEnvironmentVariable("AI_AGENT_TYPE") ?? "Ollama";
            var file = Path.Combine(AppContext.BaseDirectory, $"AI\\Prompts\\{AgentNameEnum.Intent.ToString()}.txt");
            var instructions = File.ReadAllText(file);
            aIAgentFactory.Instructions = instructions;
            
            _aiAgent = aIAgentFactory.CreateAgent(_agentType);
        }
        public async Task<IntentAgentResponse> GetIntentAsync(IntentAgentRequest intentAgentRequest)
        {
            var response = await _aiAgent.RunAsync(intentAgentRequest.Question);
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                AllowTrailingCommas = true,
            };
            return JsonSerializer.Deserialize<IntentAgentResponse>(response.Text, options);
        }
    }
}
