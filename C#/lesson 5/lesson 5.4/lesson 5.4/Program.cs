using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesson_5._4
{
    class Order
    {
        public string Status { get; private set; }
        private EmailNotifier emailNotifier = new EmailNotifier();
        private SMSNotifier smsNotifier = new SMSNotifier();

        public void StatusChanged()
        {
            Console.WriteLine($"Ваш статус изменился! Нынешний статус вашего заказа: {Status}");
        }
        public void UpdateStatus(string newStatus)
        {
            if (Status != newStatus)
            {
                Status = newStatus;
                StatusChanged();
                emailNotifier.SendEmail(Status);
                smsNotifier.SendSMS(Status);
            }
            else
            {
                Console.WriteLine($"Ваш статус не изменился. Нынешний статус заказа так и остался {Status}");
            }
        }
    }
    class EmailNotifier
    {
        public void SendEmail(string Status)
        {
            Console.WriteLine($"Отправка email: Статус заказа изменен на {Status}");
        }
    }
    class SMSNotifier
    {
        public void SendSMS(string Status)
        {
            Console.WriteLine($"Отправка SMS: Статус заказа изменен на {Status}");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Order order = new Order();

            order.UpdateStatus("В процессе\n");
            order.UpdateStatus("Едет\n");
            order.UpdateStatus("Доставлено\n");
            order.UpdateStatus("Доставлено\n");
        }
    }
}
