using Inventory.Application.AI.Agents;
using Microsoft.Agents.AI;
namespace Inventory.Infrastructure.AI.Agents
{
    public class CustomerSupportAgent : ICustomerSupportAgent
    {
        private readonly AIAgent _aiAgent;
        public CustomerSupportAgent(IAIAgentFactory agentFactory)
        {
            // Create an AI agent using the factory
            var agentType = Environment.GetEnvironmentVariable("AI_AGENT_TYPE") ?? "Ollama";
            var aiAgent = agentFactory.CreateAgent(agentType, "inventory");
            _aiAgent = aiAgent;
        }

        public async Task<string> AskAsync(string question)
        {
            var response = await _aiAgent.RunAsync(question);
            return response.Text;
        }
    }
}