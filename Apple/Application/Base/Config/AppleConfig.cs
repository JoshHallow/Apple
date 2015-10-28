using log4net;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Apple.Application.Base.Config
{
    internal class AppleConfig
    {
        private Dictionary<string, string> _configItems;
        private readonly ILog _log;
        private readonly object syncRoot = new object();

        public AppleConfig(string filePath)
        {
            _configItems = new Dictionary<string, string>();
            _log = LogManager.GetLogger(typeof(AppleConfig));

            if (!LoadConfig(filePath))
                throw new Exception("Failed to load config data");
        }

        private bool LoadConfig(string file)
        {
            try
            {
                this._configItems.Clear();

                lock (syncRoot)
                {
                    _configItems = File.ReadLines(file)
                    .Where(IsConfigurationLine)
                    .Select(line => line.Split('='))
                    .ToDictionary(line => line[0], line => line[1]);
                }
                return true;
            }
            catch (Exception exception)
            {
                _log.Error(exception); // assuming overload that takes an exception.
                return false;
            }
        }

        private bool IsConfigurationLine(string line)
        {
            return !line.StartsWith("#") && line.Contains("=");
        }

        public string GetConfigElement(string key)
        {
            if (!IsInitialized)
                return null;

            lock (syncRoot)
            {
                return this._configItems[key];
            }
        }

        public bool IsInitialized
        {
            get { return _configItems != null; }
        }
    }
}