namespace Apple
{
    using log4net.Config;
    using System;

    static class Program
    {
        static void Main(string[] args)
        {
            XmlConfigurator.Configure();
            Apple appleBase = new Apple();
            Console.ReadKey(true);
        }
    }
}