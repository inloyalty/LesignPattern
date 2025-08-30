using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Behavioral.Mediator
{

    public interface IChatMediator
    {
        void Register(User user);
        void Send(string from, string to, string message);
    }

    public class ChatMadiator : IChatMediator
    {
        private Dictionary<string, User> _users = new();
        public void Register(User user)
        {
            _users[user.Name] = user;
        }

        public void Send(string from, string to, string message)
        {
            if (_users.TryGetValue(to, out var receiver))
            {
                receiver.Receive(from, message);
            }
        }
    }

    public class User
    {
        private readonly IChatMediator _chatMadiator;
        public string Name { get; }

        public User(IChatMediator chatMadiator, string name)
        {
            _chatMadiator = chatMadiator;
            Name = name;
            _chatMadiator.Register(this);
        }

        public void Send(string to, string message)
        {
            _chatMadiator.Send(Name, to, message);
        }

        public virtual void Receive(string from, string message)
        {
            Console.WriteLine($"{Name} received from {from} : {message}");
        }
    }

    public class ChatMadiatorClient
    {

        public static void Test()
        {
            var madiator = new ChatMadiator();
            var praveen = new User(madiator, "Praveen");
            var arun = new User(madiator, "Arun");
            var Adam = new User(madiator, "adam");

            praveen.Send("Arun", "Hello arun");
            arun.Send("Praveen", "Hello Praveen");
            Adam.Send("Praveen", "Hello Praveen");


        }
    }
}
