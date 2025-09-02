using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Creational.Singleton
{
    // Lazy loading singleton implementation
    public class SingletonLoggerWithLazzyLoading
    {
        private static readonly Lazy<SingletonLoggerWithLazzyLoading> _instance =
                 new Lazy<SingletonLoggerWithLazzyLoading>(() => new());

        public static SingletonLoggerWithLazzyLoading Instance => _instance.Value;

        public   void LogMessage(string message)
        {
            Console.WriteLine(message);
        }
    }

    public class TestSingletonLoggerWithLazzyLoading
    {
        public static void Test(string message)
        {
            SingletonLoggerWithLazzyLoading.Instance.LogMessage(message);
        }
    }
}
