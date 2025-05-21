using System;
using System.Net.Sockets;
using System.Text;

namespace tcpClient
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TcpClient tcpClient = new TcpClient("127.0.0.1", 5000);
            //tcpClient.Connect();

            NetworkStream stream = tcpClient.GetStream();

            while (true)
            {
                Console.Write("Enter your message: ");
                string message = Console.ReadLine();

                byte[] data = Encoding.UTF8.GetBytes(message);
                stream.Write(data, 0, data.Length);

                byte[] buffer = new byte[256];
                int bytesRead = stream.Read(buffer, 0, buffer.Length);
                string responce = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                Console.WriteLine($"Server responce: {responce}");
            }
        }
    }
}