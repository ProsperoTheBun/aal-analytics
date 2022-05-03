using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace AA.CommoditiesDashboard.Api.Tests.Integration
{
    internal static class Utilities
    {
        /// <summary>
        /// Gets the local DB connection string from the development environment 
        /// settings for the project under test.
        /// </summary>
        /// <returns></returns>
        internal static string GetDevelopmentConnectionString()
        {
            return Program
                .CreateHostBuilder(Array.Empty<string>())
                .UseEnvironment("Development")
                .Build()
                .Services
                .GetRequiredService<IConfiguration>()
                .GetConnectionString("AA.CommoditiesDashboard");
        }
    }
}
