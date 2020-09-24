using Newtonsoft.Json;
using SpecflowNetCoreDemo.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpecflowNetCoreDemo.Config
{
    [JsonObject("testConfig")]
    public class TestConfig
    {
        [JsonProperty("environment")]
        public string Environment { get; set; }

        [JsonProperty("aut")]
        public string AUT { get; set; }

        [JsonProperty("testType")]
        public string TestType { get; set; }

        [JsonProperty("driverPath")]
        public string DriverPath { get; set; }

        [JsonProperty("browserMode")]
        public BrowserMode Mode { get; set; }
    }
}
