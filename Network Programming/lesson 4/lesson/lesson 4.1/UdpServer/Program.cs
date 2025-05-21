using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace UdpServer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            UdpClient server = new UdpClient(5000);
            IPEndPoint clientEndPoint = new IPEndPoint(IPAddress.Any,0);

            Console.WriteLine("UDP Server is start...");

            while (true)
            {
                byte[] data = server.Receive(ref clientEndPoint);
                string message = Encoding.UTF8.GetString(data);
                Console.WriteLine("input ", message);

                string responce = "output data";
                byte[] responceBytes = Encoding.UTF8.GetBytes(responce);
                server.Send(responceBytes, responceBytes.Length, clientEndPoint);
            }
        }
    }
}