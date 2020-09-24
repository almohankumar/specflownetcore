using SpecflowNetCoreDemo.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpecflowNetCoreDemo.Config
{
    public class Settings
    {
      
        public static string TestType { get; set; }

        public static string AUT { get; set; }

        public static string Environment { get; set; }

        public static string DriverPath { get; set; }

        public static BrowserMode browserMode { get; set; }
        

        private static bool _fileCreated = false;
        public static bool FileCreated
        {
            get
            {
                return _fileCreated;
            }
            set
            {
                _fileCreated = value;
            }
        }
    }
}
