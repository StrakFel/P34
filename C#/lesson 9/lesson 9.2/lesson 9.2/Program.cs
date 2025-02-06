using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesson_9._2
{
    internal class Program
    {
        delegate void Notify(string message);

        class Publisher
        {
            public event Notify OnNotify;
            public void DoSomething()
            {
                OnNotify?.Invoke("Подія сталася!");
            }
        }

        class Subscriber
        {
            public void HendlerEvent(string message)
            {
                Console.WriteLine(message);
            }
        }
        static void Main(string[] args)
        {
            var publisher = new Publisher();
            var subscriber = new Subscriber();

            publisher.OnNotify += subscriber.HendlerEvent;
            publisher.DoSomething();
        }
    }
}
