using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesson_9._3
{
    internal class Program
    {
        class Termometer
        {
            public delegate void TermometerDelegate(double newTermperature);
            public event TermometerDelegate TemperatureChanged;
            private double _temperature;
            public double Temperature
            {
                get => _temperature;
                set
                {
                    if (_temperature != value)
                    {
                        _temperature = value;
                        TemperatureChanged?.Invoke(_temperature);
                    }
                }
            }
        }
        class Display
        {
            public void ShowTemperature(double temperature)
            {
                Console.WriteLine($"Температура {temperature}");
            }
        }
        static void Main(string[] args)
        {
            Termometer t = new Termometer();
            Display d = new Display();

            t.TemperatureChanged += d.ShowTemperature;

            t.Temperature = 25.0;
            t.Temperature = 35.0;
            t.Temperature = 15.0;
        }
    }
}
