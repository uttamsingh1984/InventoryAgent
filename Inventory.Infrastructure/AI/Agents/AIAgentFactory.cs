using Inventory.Application.AI.Agents;
using Inventory.Infrastructure.AI.Prompts.Models;
using Inventory.Infrastructure.AI.Tools;
using Microsoft.Agents.AI;
using Microsoft.Extensions.AI;
using Microsoft.Extensions.Configuration;
using OllamaSharp;
using System.ComponentModel.DataAnnotations;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;
namespace Inventory.Infrastructure.AI.Agents
{
    public interface IAIAgentFactory
    {
         AIAgent CreateAgent (string agentType, string agentName);
    }
    public class AIAgentFactory: IAIAgentFactory
    {
        private readonly IConfiguration _configuration;
        private readonly InventoryTools _inventoryTools;
        public AIAgentFactory(IConfiguration configuration, InventoryTools inventoryTools)
        {
            _configuration = configuration;
            _inventoryTools = inventoryTools;
        }
        public AIAgent CreateAgent(string agentType, string agentName)
        {
            switch (agentType)
            {
                case "Ollama":
                    return CreateOllamaAgent(agentName);
                case "OpenAI":
                    return CreateOpenAIAgent();
                default:
                    throw new ArgumentException($"Unknown agent type: {agentType}");
            }
        }

        private AIAgent CreateOllamaAgent(string agentName)
        {
            // Read Ollama endpoint and model name
            var endpoint = _configuration["OLLAMA_ENDPOINT"];
            var modelName = _configuration["OLLAMA_MODEL_NAME"];

            var file = Path.Combine(AppContext.BaseDirectory, $"AI\\Prompts\\{agentName}.txt");

            var instructions = File.ReadAllText(file);

            var deserializer = new DeserializerBuilder()
            .Build();

            // Create a chat client for Ollama
            var client = new OllamaApiClient(new Uri(endpoint), modelName);

            // Use Ollama chat client to construct an AIAgent.
            var agent = client.AsAIAgent(
                name: "CustomerSupportAgent",
                description: instructions.Split("\n")[0],
                instructions: instructions,
                tools:
                [
                    AIFunctionFactory.Create(_inventoryTools.GetProductInfoAsync),
                    AIFunctionFactory.Create(_inventoryTools.GetProductAvailabilityAsync)
                ]
            );
            return agent;
        }

        private AIAgent CreateOpenAIAgent()
        {
             // Create and return an OpenAI agent

            return null;
        }

    }
}