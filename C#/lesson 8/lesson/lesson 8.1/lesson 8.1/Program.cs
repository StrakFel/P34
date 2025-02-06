using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesson_8._1
{
    //Інтерфейси
    public interface IVehicle
    {
        void Start();
        void Stop();
    }

    public class Car : IVehicle
    {
        public void Start()
        {
            Console.WriteLine("Автомобіль заводиться...");
        }
        public void Stop()
        {
            Console.WriteLine("Автомобіль зупиняєтсья...");
        }
    }
    public class Bike : IVehicle
    {
        public void Start()
        {
            Console.WriteLine("Мотоцикл заводиться...");
        }
        public void Stop()
        {
            Console.WriteLine("Мотоцикл зупиняєтсья...");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            IVehicle car = new Car();
            IVehicle bike = new Bike();

            car.Start();
            car.Stop();

            bike.Start();
            bike.Stop();
        }
    }
}
