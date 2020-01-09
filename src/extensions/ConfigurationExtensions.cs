using System;
using CSGOStats.Extensions.Validation;
using Microsoft.Extensions.Configuration;

namespace CSGOStats.Extensions.Extensions
{
    public static class ConfigurationExtensions
    {
        public static TSetting GetFromConfiguration<TSetting>(
            this IConfigurationRoot configuration,
            string sectionName,
            Func<IConfiguration, TSetting> creatingFunctor)
            where TSetting : class
        {
            var section = configuration.NotNull(nameof(configuration)).GetSection(sectionName.NotNull(nameof(sectionName)));
            return creatingFunctor.NotNull(nameof(creatingFunctor)).Invoke(section);
        }
    }
}