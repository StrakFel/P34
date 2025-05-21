using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace TcpUnicastClient
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TcpClient client = new TcpClient("127.0.0.1", 8888);
            NetworkStream stream = client.GetStream();

            string message = "Hello server";
            byte[] data = Encoding.UTF8.GetBytes(message);
            stream.Write(data, 0, data.Length);

            byte[] response = new byte[1024];
            int bytes = stream.Read(response, 0, response.Length);
            Console.WriteLine($"Response: {Encoding.UTF8.GetString(response, 0, response.Length)}");

            client.Close();
        }
    }
}