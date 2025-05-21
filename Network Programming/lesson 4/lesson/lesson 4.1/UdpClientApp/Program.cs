using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace UdpClientApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            UdpClient client = new UdpClient();
            IPEndPoint serverEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 5000);

            while (true)
            {
                Console.WriteLine("Enter your message");
                string message = Console.ReadLine();
                byte[] data = Encoding.UTF8.GetBytes(message);

                client.Send(data, data.Length, serverEndPoint);

                IPEndPoint remoteEP = null;
                byte[] responceBytes = client.Receive(ref remoteEP);
                string responce = Encoding.UTF8.GetString(responceBytes);
                Console.WriteLine("Server: " + responce);
            }
        }
    }
}