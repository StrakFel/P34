using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace tcpServer
{
    internal class Program
    {
        static void HandleClient(object obj)
        {
            TcpClient client = (TcpClient)obj;
            NetworkStream stream = client.GetStream();

            byte[] buffer = new byte[256];
            int bytesRead;

            while ((bytesRead = stream.Read(buffer, 0, buffer.Length)) != 0)
            {
                string data = Encoding.UTF8.GetString(buffer, 0 ,bytesRead);
                Console.WriteLine($"Client writes: {data}");

                string responce = "Received" + data;
                byte[] responceBytes = Encoding.UTF8.GetBytes(responce);
                stream.Write(responceBytes, 0, responceBytes.Length);
            }
            client.Close();
        }
        static void Main(string[] args)
        {
            TcpListener server = new TcpListener(IPAddress.Any, 5000);
            server.Start();
            Console.WriteLine("Server status: Online");

            while (true)
            {
                TcpClient client = server.AcceptTcpClient();
                Console.WriteLine("New client connection");
                Thread thread = new Thread(HandleClient);
                thread.Start(client);
            }
        }
    }
}