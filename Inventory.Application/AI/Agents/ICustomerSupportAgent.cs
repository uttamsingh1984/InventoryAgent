namespace Inventory.Application.AI.Agents
{
    public interface ICustomerSupportAgent
    {
        Task<string> AskAsync(string question);    
    }
}