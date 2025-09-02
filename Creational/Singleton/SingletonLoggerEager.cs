using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Creational.Singleton
{
    //Static instance (eager)
    internal class SingletonLoggerEager
    {
        public static SingletonLoggerEager Instance = new SingletonLoggerEager();
        private SingletonLoggerEager() { }

        public void LogMessage(string message) => Console.WriteLine(message);
    }

    public class TestSingletonLoggerEager
    {
        public static void LogMessage(string message)
        {
            SingletonLoggerEager.Instance.LogMessage("Message from eager loading");
        }
    }
}
