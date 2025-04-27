using System;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace tcpClient
{
    class Program
    {
        static void Main()
        {
            TcpClient client = new TcpClient("127.0.0.1", 5000);
            NetworkStream stream = client.GetStream();

            // Потік для отримання повідомлень
            Thread receiveThread = new Thread(() =>
            {
                byte[] buffer = new byte[1024];
                int bytes;
                while ((bytes = stream.Read(buffer, 0, buffer.Length)) != 0)
                {
                    string response = Encoding.UTF8.GetString(buffer, 0, bytes);
                    Console.WriteLine($"\n[Сервер]: {response}");
                    Console.Write("> ");
                }
            });
            receiveThread.Start();

            // Надсилання повідомлень
            Console.WriteLine("Введите сообщение:");
            while (true)
            {
                Console.Write("> ");
                string msg = Console.ReadLine();
                byte[] data = Encoding.UTF8.GetBytes(msg);
                stream.Write(data, 0, data.Length);
            }
        }
    }
}