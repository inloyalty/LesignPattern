using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Creational.Singleton
{
    public class CeoMonoState
    {
        private static string _name;
        private static int _age;
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public int Age
        {
            get { return _age; }
            set { _age = value; }
        }
        public void Display()
        {
            Console.WriteLine($"Name: {_name}, Age: {_age}");
        }
    }

    public class CeoMonoStateClient
    {
        public static void Test()
        {
            var ceo1 = new CeoMonoState();
            ceo1.Name = "Alice";
            ceo1.Age = 50;
            var ceo2 = new CeoMonoState();
            ceo2.Name = "Bob";
            ceo2.Age = 55;
            ceo1.Display(); // Output: Name: Bob, Age: 55
            ceo2.Display(); // Output: Name: Bob, Age: 55
        }
    }
}
