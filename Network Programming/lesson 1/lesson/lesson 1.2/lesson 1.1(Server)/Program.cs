using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Lesson1_1_Server
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Налаштування
            int port = 5000;
            IPAddress localAdress = IPAddress.Parse("127.0.0.1");

            //TCP слухач
            TcpListener server = new TcpListener(localAdress, port);
            server.Start();
            Console.WriteLine("Server start! Wait new client...");

            while (true)
            {
                //Приймання клієнтів
                TcpClient client = server.AcceptTcpClient();
                Console.WriteLine("Client online");

                //Приймаємо данні від клієнту
                NetworkStream stream = client.GetStream();
                byte[] buffer = new byte[1024];
                int bytesRead = stream.Read(buffer, 0, buffer.Length);
                string data = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                Console.WriteLine($"Client's name: {data}");

                //Відповідаємо клієнту
                string responce = $"Hello {data}";
                byte[] responceBytes = Encoding.UTF8.GetBytes(responce);
                stream.Write(responceBytes, 0, responceBytes.Length);

                //Завершення
                client.Close();
                Console.WriteLine("Client offline");
            }
        }
    }
}