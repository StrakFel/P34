using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Tcp_Server
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int port = 5000;
            IPAddress localAdress = IPAddress.Parse("127.0.0.1");

            TcpListener server = new TcpListener(localAdress, port);
            server.Start();
            Console.WriteLine("Server start! Wait new client...");

            while (true)
            {
                TcpClient client = server.AcceptTcpClient();
                Console.WriteLine("Client online");

                NetworkStream stream = client.GetStream();
                byte[] buffer = new byte[1024];
                int bytesRead = stream.Read(buffer, 0, buffer.Length);
                string data = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                Console.WriteLine($"Message: {data}");

                string responce = $"{data.ToUpperInvariant()}";
                byte[] responceBytes = Encoding.UTF8.GetBytes(responce);
                stream.Write(responceBytes, 0, responceBytes.Length);

                client.Close();
                Console.WriteLine("Client offline");
            }
        }
    }
}