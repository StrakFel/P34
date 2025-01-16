using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesson_5._5
{
    class SmartHomeController
    {
        private Dictionary<string, SmartDevice> devices = new Dictionary<string, SmartDevice>();

        // Реєстрація пристрою
        public void RegisterDevice(SmartDevice device)
        {
            if (!devices.ContainsKey(device.Name))
            {
                devices.Add(device.Name, device);
                Console.WriteLine($"Пристрій {device.Name} додано до системи.");
            }
            else
            {
                Console.WriteLine($"Пристрій {device.Name} вже зареєстровано.");
            }
        }

        // Надсилання команди конкретному пристрою
        public void SendCommand(string deviceName, string command)
        {
            if (devices.ContainsKey(deviceName))
            {
                devices[deviceName].ProcessCommand(command);
            }
            else
            {
                Console.WriteLine($"Пристрій {deviceName} не знайдено.");
            }
        }

        // Надсилання команди всім пристроям
        public void BroadcastCommand(string command)
        {
            Console.WriteLine($"Надсилання команди всім пристроям: {command}");
            foreach (var device in devices.Values)
            {
                device.ProcessCommand(command);
            }
        }
    }

    class SmartDevice
    {
        public string Name { get; private set; }
        private bool isOn;

        public SmartDevice(string name)
        {
            Name = name;
            isOn = false;
        }

        public void ProcessCommand(string command)
        {
            switch (command.ToLower())
            {
                case "on":
                    if (!isOn)
                    {
                        isOn = true;
                        Console.WriteLine($"{Name} увімкнено.");
                    }
                    else
                    {
                        Console.WriteLine($"{Name} вже увімкнено.");
                    }
                    break;

                case "off":
                    if (isOn)
                    {
                        isOn = false;
                        Console.WriteLine($"{Name} вимкнено.");
                    }
                    else
                    {
                        Console.WriteLine($"{Name} вже вимкнено.");
                    }
                    break;

                default:
                    CustomCommand(command);
                    break;
            }
        }

        protected virtual void CustomCommand(string command)
        {
            Console.WriteLine($"{Name}: команда \"{command}\" не підтримується.");
        }
    }

    class SmartAirConditioner : SmartDevice
    {
        private int temperature;

        public SmartAirConditioner(string name) : base(name)
        {
            temperature = 22; // Температура за замовчуванням
        }

        protected override void CustomCommand(string command)
        {
            if (command.StartsWith("settemperature ", StringComparison.OrdinalIgnoreCase))
            {
                if (int.TryParse(command.Split(' ')[1], out int newTemp))
                {
                    temperature = newTemp;
                    Console.WriteLine($"{Name}: температура встановлена на {temperature}°C.");
                }
                else
                {
                    Console.WriteLine($"{Name}: некоректна температура.");
                }
            }
            else
            {
                base.CustomCommand(command);
            }
        }
    }

    class SmartDoorLock : SmartDevice
    {
        private bool isLocked;

        public SmartDoorLock(string name) : base(name)
        {
            isLocked = true; // Замок за замовчуванням закритий
        }

        protected override void CustomCommand(string command)
        {
            switch (command.ToLower())
            {
                case "lock":
                    if (!isLocked)
                    {
                        isLocked = true;
                        Console.WriteLine($"{Name} зачинено.");
                    }
                    else
                    {
                        Console.WriteLine($"{Name} вже зачинено.");
                    }
                    break;

                case "unlock":
                    if (isLocked)
                    {
                        isLocked = false;
                        Console.WriteLine($"{Name} відчинено.");
                    }
                    else
                    {
                        Console.WriteLine($"{Name} вже відчинено.");
                    }
                    break;

                default:
                    base.CustomCommand(command);
                    break;
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            SmartHomeController controller = new SmartHomeController();

            SmartDevice lamp = new SmartDevice("Лампа");
            SmartAirConditioner airConditioner = new SmartAirConditioner("Кондиціонер");
            SmartDoorLock doorLock = new SmartDoorLock("Дверний замок");

            controller.RegisterDevice(lamp);
            controller.RegisterDevice(airConditioner);
            controller.RegisterDevice(doorLock);

            controller.SendCommand("Лампа", "on");
            controller.SendCommand("Кондиціонер", "settemperature 25");
            controller.SendCommand("Дверний замок", "unlock");
            controller.BroadcastCommand("off");

            controller.SendCommand("Дверний замок", "lock");
        }
    }
} 
