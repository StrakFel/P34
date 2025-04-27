using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Collections.Generic;

namespace tcpServer
{
    class Program
    {
        static List<TcpClient> clients = new List<TcpClient>();
        static object lockObj = new object();

        static void Main()
        {
            TcpListener server = new TcpListener(IPAddress.Parse("127.0.0.1"), 5000);
            server.Start();
            Console.WriteLine("Сервер запущен...");

            while (true)
            {
                TcpClient client = server.AcceptTcpClient();
                lock (lockObj) clients.Add(client);

                Console.WriteLine("Клиент подключился");
                Thread thread = new Thread(HandleClient);
                thread.Start(client);
            }
        }

        static void HandleClient(object obj)
        {
            TcpClient client = (TcpClient)obj;
            NetworkStream stream = client.GetStream();
            byte[] buffer = new byte[1024];
            int bytesRead;

            try
            {
                while ((bytesRead = stream.Read(buffer, 0, buffer.Length)) != 0)
                {
                    string msg = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                    Console.WriteLine($"Клиент: {msg}");

                    // Відповідь клієнту
                    byte[] ack = Encoding.UTF8.GetBytes("Ваше сообщение получено");
                    stream.Write(ack, 0, ack.Length);

                    // Розсилка повідомлення іншим клієнтам
                    BroadcastMessage(msg, client);
                }
            }
            catch { }
            finally
            {
                lock (lockObj) clients.Remove(client);
                client.Close();
            }
        }

        static void BroadcastMessage(string msg, TcpClient sender)
        {
            byte[] messageBytes = Encoding.UTF8.GetBytes($"Сообщение от другого клиента: {msg}");
            lock (lockObj)
            {
                foreach (var client in clients)
                {
                    if (client != sender)
                    {
                        try
                        {
                            NetworkStream stream = client.GetStream();
                            stream.Write(messageBytes, 0, messageBytes.Length);
                        }
                        catch { }
                    }
                }
            }
        }
    }
}