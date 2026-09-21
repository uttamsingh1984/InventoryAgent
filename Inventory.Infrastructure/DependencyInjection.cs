using Inventory.Application.AI.Agents;
using Inventory.Application.Data;
using Inventory.Domain.Product;
using Inventory.Infrastructure.AI.Tools;
using Inventory.Infrastructure.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Inventory.Infrastructure.AI.Agents;

namespace Inventory.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<InventoryDbContext>(options =>
                options.UseInMemoryDatabase("InventoryDB"));

            services.AddScoped<IApplicatonDbContext>(
                provider =>
                    provider.GetRequiredService<InventoryDbContext>());

            services.AddScoped<IInventoryRepository, InventoryRepository>();


            services.AddScoped<InventoryTools>();

            services.AddScoped<IAIAgentFactory, AIAgentFactory>();

            services.AddScoped<ICustomerSupportAgent, CustomerSupportAgent>();


            return services;
        }
    }
}
