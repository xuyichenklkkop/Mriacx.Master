using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Mriacx.Common.Utils;
using Mriacx.Entity.CommonEntity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Loader;
using System.Text;

namespace Mriacx.Master.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services, Action<AssemblyOption> configure = null)
        {
            var location = Assembly.GetEntryAssembly().Location;
            var baseDirectory = Path.GetDirectoryName(location);
            var serviceProvider = services.BuildServiceProvider();

            AssemblyOption assemblyOption = new AssemblyOption();
            assemblyOption = serviceProvider.GetRequiredService<IOptions<AssemblyOption>>().Value;

            var assemblies = new List<Assembly>();
            var dllList = new List<string>();
            assemblyOption.Services?.RemoveEmptySplit(",").ToList().ForEach(service =>
            {
                if (string.IsNullOrEmpty(service))
                {
                    return;
                }

                var dll = Directory.GetFiles(baseDirectory, $"{service}.dll", SearchOption.TopDirectoryOnly)[0];
                dllList.Add(dll);
            });
            assemblyOption.DataAccess?.RemoveEmptySplit(",").ToList().ForEach(dataAccess =>
            {
                if (string.IsNullOrEmpty(dataAccess))
                {
                    return;
                }

                var dll = Directory.GetFiles(baseDirectory, $"{dataAccess}.dll", SearchOption.TopDirectoryOnly)[0];
                dllList.Add(dll);
            });

            foreach (var fileFullPath in dllList)
            {
                var assemblyName = AssemblyLoadContext.GetAssemblyName(fileFullPath);
                var assembly = Assembly.Load(assemblyName);
                assemblies.Add(assembly);
            }
            return services;
        }
    }
}
