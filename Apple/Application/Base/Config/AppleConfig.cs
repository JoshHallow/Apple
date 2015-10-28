namespace Apple.Application.Base.Config
{
    using log4net;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    internal class AppleConfig
    {
        /// <summary>
        /// List of configuration items
        /// </summary>
        private readonly Dictionary<string, string> _configItems;

        /// <summary>
        /// Config file info
        /// </summary>
        private readonly FileInfo _configFile;

        /// <summary>
        /// Log4net logger.
        /// </summary>
        private readonly ILog _log;

        /// <summary>
        /// Checks if class has been initialized.
        /// </summary>
        private readonly bool _initialized;

        /// <summary>
        /// AppleConfig constructor.
        /// </summary>
        /// <param name="filePath"></param>
        public AppleConfig(string filePath)
        {
            if (this._initialized)
                return;

            this._configItems = new Dictionary<string, string>();
            this._configFile = new FileInfo(filePath);
            this._log = LogManager.GetLogger(typeof(AppleConfig));
            this._initialized = this.Initialize();
        }

        /// <summary>
        /// Initializes AppleConfig
        /// </summary>
        private bool Initialize()
        {
            try
            {
                foreach (string line in File.ReadLines(this._configFile.ToString()).Where(IsConfigurationLine))
                {
                    var splittedLine = line.Split('=');

                    const int keyIndex = 0;
                    const int valueIndex = 1;

                    this._configItems[splittedLine[keyIndex]] = splittedLine[valueIndex];
                }

                return true;
            }
            catch (Exception exception)
            {
                _log.Error(exception); // assuming overload that takes an exception.
                return false;
            }
        }

        /// <summary>
        /// Checks for valid config line
        /// </summary>
        /// <param name="Line">String to check</param>
        /// <returns></returns>
        private bool IsConfigurationLine(string Line)
        {
            return (!string.IsNullOrWhiteSpace(Line) && !Line.StartsWith("#") && Line.Contains("="));
        }

        /// <summary>
        /// Returns a config items value by its key.
        /// </summary>
        /// <param name="Key"></param>
        /// <returns></returns>
        public string GetConfigElement(string Key)
        {
            if (!this.IsInitialized)
                return null;

            return this._configItems[Key];
        }

        /// <summary>
        /// Checks if class has been initialized.
        /// </summary>
        public bool IsInitialized
        {
            get { return this._initialized; }
        }

        /// <summary>
        /// Refreshes config
        /// </summary>
        public void RefreshConfig()
        {
            this.Initialize();
        }
    }
}