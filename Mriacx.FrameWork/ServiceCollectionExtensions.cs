using Microsoft.Extensions.DependencyInjection;
using Mriacx.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace Mriacx.FrameWork
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services, Action<AssemblyOption> configure = null)
        {
            var location = Assembly.GetEntryAssembly().Location;
            var baseDirectory = Path.GetDirectoryName(location);
            var serviceProvider = services.BuildServiceProvider();

            AssemblyOption assemblyOption = new AssemblyOption();

            return services;
        }
    }
}
