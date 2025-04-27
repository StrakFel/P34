using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Tcp_Client
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
                TcpClient client = new TcpClient(serverIp, port);
                NetworkStream stream = client.GetStream();

                Console.Write("Enter your message: ");
                string message = Console.ReadLine();
                byte[] data = Encoding.UTF8.GetBytes(message);
                stream.Write(data, 0, data.Length);
                Console.WriteLine("Message sent");

                byte[] buffer = new byte[256];
                int bytesRead = stream.Read(buffer, 0, buffer.Length);
                string responce = Encoding.UTF8.GetString(buffer);
                Console.WriteLine($"Server: {responce}");

                stream.Close();
                client.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            Console.Write("Press Enter to exit");
            Console.ReadLine();
        }
    }
}
