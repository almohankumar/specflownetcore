using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SpecflowNetCoreDemo.Config
{
    public class ConfigReader
    {

        public static void LoadConfigs()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appConfig.json");

            IConfigurationRoot configurationRoot = builder.Build();

            Settings.AUT = configurationRoot.GetSection("testConfig").Get<TestConfig>().AUT;
            Settings.Environment = configurationRoot.GetSection("testConfig").Get<TestConfig>().Environment;
            Settings.TestType = configurationRoot.GetSection("testConfig").Get<TestConfig>().TestType;
            Settings.browserMode = configurationRoot.GetSection("testConfig").Get<TestConfig>().Mode;
            Settings.DriverPath = configurationRoot.GetSection("testConfig").Get<TestConfig>().DriverPath;
        }
    }
}
