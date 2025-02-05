using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace lesson_7._3
{
    public abstract class Vehicle
    {
        public abstract int Speed { get; set; }
        public abstract int Capacity { get; set; }
        public abstract void Move(); 
    }
    public class Car : Vehicle
    {
        public override int Speed { get; set; } = 120;
        public override int Capacity { get; set; } = 4;
        public override void Move()
        {
            Console.WriteLine($"Машина имеет {Capacity} пасажиров и едет со скоростью {Speed} км/ч");
        }
    }
    public class Bike : Vehicle
    {
        public override int Speed { get; set; } = 40;
        public override int Capacity { get; set; } = 1;
        public override void Move()
        {
            Console.WriteLine($"Велосипед имеет {Capacity} пасажиров и едет со скоростью {Speed} км/ч");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Car car = new Car();
            Bike bike = new Bike();

            car.Move();
            bike.Move();
        }
    }
}
