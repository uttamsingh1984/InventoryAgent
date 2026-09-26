using Inventory.Application.AI.Agents;
using Inventory.Infrastructure.AI.Tools;
using Inventory.Infrastructure.Models;
using Microsoft.Agents.AI;
using Microsoft.Extensions.AI;
namespace Inventory.Infrastructure.AI.Agents
{
    public class CustomerSupportAgent : ICustomerSupportAgent
    {
        private readonly AIAgent _aiAgent;
        public CustomerSupportAgent(IAIAgentFactory agentFactory, InventoryTools inventoryTools)
        {
            var agentType = Environment.GetEnvironmentVariable("AI_AGENT_TYPE") ?? "Ollama";
            var file = Path.Combine(AppContext.BaseDirectory, $"AI\\Prompts\\{AgentNameEnum.Inventory.ToString()}.txt");
            var instructions = File.ReadAllText(file);
            agentFactory.Instructions = instructions;
            agentFactory.AITools = new List<AITool>
            {
                AIFunctionFactory.Create(inventoryTools.GetProductInfoAsync),
                AIFunctionFactory.Create(inventoryTools.GetProductAvailabilityAsync)
            };
            var _aiAgent = agentFactory.CreateAgent("Ollama");
        }

        public async Task<string> AskAsync(string question)
        {
            var response = await _aiAgent.RunAsync(question);
            return response.Text;
        }
    }
}