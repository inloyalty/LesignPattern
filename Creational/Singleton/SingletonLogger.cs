using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Creational.Singleton
{
    // Thread-safe singleton implementation
    public class SingletonLogger
    {
        private static SingletonLogger _instance = null;
        public static SingletonLogger Instance { get { return CreateInstance(); } }
        private static readonly object _lock = new();
        private SingletonLogger() { }
        
        private static SingletonLogger CreateInstance()
        {
            lock (_lock)
            {
                if (_instance is null)
                {
                    _instance = new();
                }
            }
            return _instance;
        }

        public void LogMessage(string message)
        {
            Console.WriteLine(message);
        }
    }


    public class SingletonLoggerClient
    {

        public static void TestSingletonLogger()

        {
            SingletonLogger.Instance.LogMessage("This is a singleton logger message.");
        }
    }
}
