using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesson_7._4
{
    public class Transport
    {
        public double time;
        public double trips = 1;
        public virtual string Name { get; set; }
        public virtual double Speed { get; set; }
        public virtual double Capacity { get; set; }

        public virtual void DeliverGoods(double weight, double distance) { }
    }

    public class Truck : Transport
    {
        public override string Name { get; set; } = "Volvo FH16";
        public override double Speed { get; set; } = 100;
        public override double Capacity { get; set; } = 2000;

        public override void DeliverGoods(double weight, double distance)
        {
            if (Capacity >= weight) time = distance / Speed + trips;
            else
            {
                trips = Math.Ceiling(weight / Capacity);
                time = (distance / Speed) * trips + trips;
            }
            string trip_word = trips == 1 ? "рейс" : "рейсов";
            Console.WriteLine($"Грузовик {Name} со скоростью {Speed} км/ч и максимальным весом {Capacity}, сможет проехать {distance} км за {time} часов в {trips} {trip_word}");
        }
    }
    public class Drone : Transport
    {
        public override string Name { get; set; } = "DJI Phantom 4 Pro";
        public override double Speed { get; set; } = 80;
        public override double Capacity { get; set; } = 5;

        public override void DeliverGoods(double weight, double distance)
        {
            double plus_time = Math.Ceiling(distance / 100);
            if (Capacity >= weight && distance <= 100) time = distance / Speed;
            else
            {
                trips = Math.Max(Math.Ceiling(weight / Capacity), plus_time);
                time = (distance / Speed) * trips + (plus_time * 2);
            }
            string trip_word = trips == 1 ? "рейс" : "рейсов";
            Console.WriteLine($"Дрон {Name} со скоростью {Speed} км/ч и максимальным весом {Capacity}, сможет проехать {distance} км за {time} часов в {trips} {trip_word}");
        }
    }
    public class Ship : Transport
    {
        public override string Name { get; set; } = "Queen Mary 2";
        public override double Speed { get; set; } = 40;
        public override double Capacity { get; set; } = 30000;

        public override void DeliverGoods(double weight, double distance)
        {
            if (Capacity >= weight) time = distance / Speed;
            else
            {
                trips = Math.Ceiling(weight / Capacity);
                time = (distance / Speed) * trips + (trips * 3);
            }
            string trip_word = trips == 1 ? "рейс" : "рейсов";
            Console.WriteLine($"Корабль {Name} со скоростью {Speed} км/ч и максимальным весом {Capacity}, сможет проехать {distance} км за {time} часов в {trips} {trip_word}");
        }
    }

    public class DeliveryManager
    {
        public void PlanDelivery(double weight, double distance)
        {
            Truck truck = new Truck();
            Drone drone = new Drone();
            Ship ship = new Ship();

            truck.DeliverGoods(weight, distance);
            drone.DeliverGoods(weight, distance);
            ship.DeliverGoods(weight, distance);

            double max_time = Math.Min(Math.Min(truck.time, drone.time), ship.time);
            string best_transport = "";

            if (max_time == truck.time)
                best_transport = truck.Name;
            else if (max_time == drone.time)
                best_transport = drone.Name;
            else if (max_time == ship.time)
                best_transport = ship.Name;

            double sum_times = truck.time + drone.time + ship.time;
            Console.WriteLine($"\nЛучший транспорт - {best_transport}");
            Console.WriteLine($"\nОбщее время доставки составляют {sum_times} часов");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            DeliveryManager manager = new DeliveryManager();

            Console.Write("Введите вес груза: ");
            double weight = Convert.ToDouble(Console.ReadLine());

            Console.Write("Введите расстояние для доставки: ");
            double distance = Convert.ToDouble(Console.ReadLine());

            manager.PlanDelivery(weight, distance);
        }
    }
}
