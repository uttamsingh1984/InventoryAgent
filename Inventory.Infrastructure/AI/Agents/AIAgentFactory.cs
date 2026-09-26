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
        AIAgent CreateAgent(string agentType);
        string Instructions { get; set; }
        List<AITool> AITools { get; set; }
    }
    public class AIAgentFactory : IAIAgentFactory
    {
        private readonly IConfiguration _configuration;
        public string Instructions { get; set; }
        public List<AITool> AITools { get; set; } = new();
        public AIAgentFactory(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public AIAgent CreateAgent(string agentType)
        {
            switch (agentType)
            {
                case "Ollama":
                    return CreateOllamaAgent();
                case "OpenAI":
                    return CreateOpenAIAgent();
                default:
                    throw new ArgumentException($"Unknown agent type: {agentType}");
            }
        }

        private AIAgent CreateOllamaAgent()
        {
            // Read Ollama endpoint and model name
            var endpoint = _configuration["OLLAMA_ENDPOINT"];
            var modelName = _configuration["OLLAMA_MODEL_NAME"];

            //var deserializer = new DeserializerBuilder().Build();

            var client = new OllamaApiClient(new Uri(endpoint), modelName);

            var agent = client.AsAIAgent(
                 name: "IntentAgent",
                 //description: instructions.Split("\n")[0],
                 instructions: this.Instructions,
                 tools: this.AITools
             );
            return agent;
        }

        private AIAgent CreateOpenAIAgent()
        {
            return null;
        }

    }
}