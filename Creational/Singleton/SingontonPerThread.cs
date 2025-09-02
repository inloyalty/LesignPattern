using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Creational.Singleton
{
    public sealed class SingontonPerThread
    {

        private  static ThreadLocal<SingontonPerThread> threadInstance = new ThreadLocal<SingontonPerThread>(() => new SingontonPerThread());

        public int Id { get; set; }
        private SingontonPerThread()
        {
            Id= System.Threading.Thread.CurrentThread.ManagedThreadId;
        }
        public static SingontonPerThread Instance => threadInstance.Value;
    }

    public class SingontonPerThreadClient
    {

        public static void Test()
        {
            Parallel.For(0, 5, (i) =>
            {
                var instance = SingontonPerThread.Instance;
                Console.WriteLine($"Thread ID: {System.Threading.Thread.CurrentThread.ManagedThreadId}, Singleton ID: {instance.Id}");
            });
        }

    }
}
