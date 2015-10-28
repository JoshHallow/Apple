namespace Apple.Application.Base.Config
{
    using log4net;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    internal class AppleConfig
    {
        private readonly Dictionary<string, string> _configValues = null;
        private readonly FileInfo _configFile = null;
        private readonly ILog _log = null;
        private readonly bool _initialized;

        public AppleConfig(string filePath)
        {
            if (this._initialized)
                return;

            this._configValues = new Dictionary<string, string>();
            this._configFile = new FileInfo(filePath);
            this._log = LogManager.GetLogger(typeof(AppleConfig));
            this._initialized = this.Initialize();
        }

        private bool Initialize()
        {
            try
            {
                foreach (string line in File.ReadLines(this._configFile.ToString()).Where(IsConfigurationLine))
                {
                    var splittedLine = line.Split('=');

                    const int keyIndex = 0;
                    const int valueIndex = 1;

                    this._configValues[splittedLine[keyIndex]] = splittedLine[valueIndex];
                }
            }
            catch (Exception exception)
            {
                _log.Error(exception); // assuming overload that takes an exception.
                throw new ConfigurationUnavailableException(exception);
            }
        }

        private bool IsConfigurationLine(string Line)
        {
            return (!string.IsNullOrWhiteSpace(Line) && !Line.StartsWith("#") && Line.Contains("="));
        }

        public string GetConfigElement(string Key)
        {
            if (!this.IsInitialized)
                return null;

            return this._configValues[Key];
        }

        public bool IsInitialized
        {
            get { return this._initialized; }
        }
    }
}