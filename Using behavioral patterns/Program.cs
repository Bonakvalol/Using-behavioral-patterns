using System;

namespace SmartHomeControl
{
    public interface IDevice
    {
        void On();
        void Off();
        bool IsOn { get; }
    }

    public class Light : IDevice
    {
        public bool IsOn { get; private set; }

        public void On()
        {
            if (!IsOn)
            {
                Console.WriteLine("Свет включен.");
                IsOn = true;
            }
            else
            {
                Console.WriteLine("Свет уже включен.");
            }
        }

        public void Off()
        {
            if (IsOn)
            {
                Console.WriteLine("Свет выключен.");
                IsOn = false;
            }
            else
            {
                Console.WriteLine("Свет уже выключен.");
            }
        }
    }

    public class AC : IDevice
    {
        public bool IsOn { get; private set; }

        public void On()
        {
            if (!IsOn)
            {
                Console.WriteLine("Кондиционер включен.");
                IsOn = true;
            }
            else
            {
                Console.WriteLine("Кондиционер уже включен.");
            }
        }

        public void Off()
        {
            if (IsOn)
            {
                Console.WriteLine("Кондиционер выключен.");
                IsOn = false;
            }
            else
            {
                Console.WriteLine("Кондиционер уже выключен.");
            }
        }
    }

    public class TV : IDevice
    {
        public bool IsOn { get; private set; }

        public void On()
        {
            if (!IsOn)
            {
                Console.WriteLine("Телевизор включен.");
                IsOn = true;
            }
            else
            {
                Console.WriteLine("Телевизор уже включен.");
            }
        }

        public void Off()
        {
            if (IsOn)
            {
                Console.WriteLine("Телевизор выключен.");
                IsOn = false;
            }
            else
            {
                Console.WriteLine("Телевизор уже выключен.");
            }
        }
    }

    public class Remote
    {
        private Action _action;

        public void Set(Action action)
        {
            _action = action;
        }

        public void Press()
        {
            _action?.Invoke();
        }
    }

    class Program
    {
        static void Main()
        {
            var light = new Light();
            var ac = new AC();
            var tv = new TV();
            var remote = new Remote();

            while (true)
            {
                Console.WriteLine("Выберите устройство:");
                Console.WriteLine("1 - Свет");
                Console.WriteLine("2 - Кондиционер");
                Console.WriteLine("3 - Телевизор");
                Console.WriteLine("0 - Выйти");

                string device = Console.ReadLine();
                if (device == "0") break;

                Console.WriteLine("Выберите команду:");
                Console.WriteLine("1 - Включить");
                Console.WriteLine("2 - Выключить");

                string command = Console.ReadLine();
                bool on = command == "1";

                switch (device)
                {
                    case "1":
                        remote.Set(on ? light.On : light.Off);
                        break;
                    case "2":
                        remote.Set(on ? ac.On : ac.Off);
                        break;
                    case "3":
                        remote.Set(on ? tv.On : tv.Off);
                        break;
                    default:
                        Console.WriteLine("Неверный выбор.");
                        continue;
                }

                remote.Press();
                Console.WriteLine();
            }
        }
    }
}
