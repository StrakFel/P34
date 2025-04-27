using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace TcpClientApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Налаштування
            int port = 5000;
            string serverIp = "127.0.0.1";

            try
            {
                //Створення клієнту
                TcpClient client = new TcpClient(serverIp, port);
                NetworkStream stream = client.GetStream();

                //Відправка повідомлення
                string message = "Hello server";
                byte[] data = Encoding.UTF8.GetBytes(message);
                stream.Write(data, 0, data.Length);
                Console.WriteLine("Message sent");

                //Отримання відповіді
                byte[] buffer = new byte[256];
                int bytesRead = stream.Read(buffer, 0, buffer.Length);
                string responce = Encoding.UTF8.GetString(buffer);
                Console.WriteLine($"Server: {responce}");

                //Завершення
                stream.Close();
                client.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            Console.ReadLine();
        }
    }
}
