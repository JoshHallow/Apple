using System;
using Apple.Application.Base.Config;

namespace Apple
{
    internal sealed class Apple
    {
        private AppleConfig _appleConfig;

        public Apple()
        {
            this._appleConfig = new AppleConfig("config.ini");
            Console.WriteLine("Hello World.");
        }
    }
}