using System;
using System.Net;
using System.Text;
using System.Net.Sockets;

namespace TcpUnicastServer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TcpListener server = new TcpListener(IPAddress.Any, 8888);
            Console.WriteLine("Server online");

            while (true)
            {
                TcpClient client = server.AcceptTcpClient();
                NetworkStream stream = client.GetStream();

                byte[] buffer = new byte[1024];
                int bytes = stream.Read(buffer, 0, buffer.Length);
                string message = Encoding.UTF8.GetString(buffer, 0, bytes);

                Console.WriteLine($"Clietn messgae: {message}");

                string response = "Response";
                byte[] responseBytes = Encoding.UTF8.GetBytes(response);
                stream.Write(responseBytes, 0, responseBytes.Length);

                client.Close();
            }
        }
    }
}