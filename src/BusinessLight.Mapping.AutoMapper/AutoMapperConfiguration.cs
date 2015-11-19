using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using AutoMapper;

namespace BusinessLight.Mapping.AutoMapper
{
    public class AutoMapperConfiguration
    {
        public static void Configure()
        {
            Mapper.Initialize(x => GetConfiguration(Mapper.Configuration));
        }

        private static void GetConfiguration(IConfiguration configuration)
        {
            GetConfiguration(configuration, Assembly.GetExecutingAssembly());
        }

        private static void GetConfiguration(IConfiguration configuration, Assembly assembly)
        {
            GetConfiguration(configuration, new[] { assembly });
        }

        private static void GetConfiguration(IConfiguration configuration, IEnumerable<Assembly> assemblies)
        {
            foreach (var assembly in assemblies)
            {
                var profiles = assembly.GetTypes().Where(x => typeof(Profile).IsAssignableFrom(x));
                foreach (var profile in profiles)
                {
                    configuration.AddProfile(Activator.CreateInstance(profile) as Profile);
                } 
            }
        }
    }
}
