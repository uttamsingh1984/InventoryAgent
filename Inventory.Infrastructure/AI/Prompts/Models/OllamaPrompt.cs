using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory.Infrastructure.AI.Prompts.Models
{
    public class OllamaPrompt
    {
        public string Role { get; set; }

        public string Instructions { get; set; }
        public List<Example> Examples { get; set; }
    }

    public class Example
    {
        public string User { get; set; }
        public string Assistant { get; set; }
    }
}
